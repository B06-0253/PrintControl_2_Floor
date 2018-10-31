using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using InControls.Common;
using InControls.SerialDevice;
using Vila.Common;
using Vila.Extensions;

namespace InControls.PLC.FX
{
	/// <summary>
	/// ���������շ��ػ���
	/// ���ڷ�װ�Զ����λ�������15�����ڵĴ��л���д����
	/// ��Ҫ��;��
	///     1���ط����Ƶ�ʵ��
	///     2����������
	/// </summary>
	public sealed class FxSerialDeamon : ControllerBaseImpl, IControllerAction, IDisposable
	{
		private SerialPortSync _SerialPort;
		private FxRingBuffer _RingBuffer;

		private const int MAX_RETRY_READ_COUNT = 50;

		public FxSerialDeamon()
			: this(ControllerTypeConst.ctPLC_Fx, 0, string.Empty, string.Empty, 0, 128)
		{
		}

		/// <summary>
		/// ����FxSerialDeamon��ʵ��
		/// </summary>
		/// <param name="controllerType">Ŀǰ��֧��ctPLC_Fx</param>
		/// <param name="controllerId"></param>
		/// <param name="controllerName">����������----�����ڲ�һ�㲻��Ҫ</param>
		/// <param name="controllerAddress">��ʾΪ�����ںš�IP��ַ</param>
		/// <param name="controllerAddressPort">��������ַ�Ķ˿ںţ���ʾΪ��TCP/UDP��Port��485���豸ID��</param>
		/// <param name="controllerChannelCount">ͨ����������128��256 ... ...</param>
		public FxSerialDeamon(ControllerTypeConst controllerType, int controllerId, string controllerName, string controllerAddress, short controllerAddressPort, short controllerChannelCount)
			: base(controllerType, controllerId, controllerName, controllerAddress, controllerAddressPort, controllerChannelCount)
		{
			Debug.Assert(controllerType == ControllerTypeConst.ctPLC_Fx, "��ȷ�ϣ��������֧�� ControllerTypeConst.ctPLC_Fx .");

			_SerialPort = null;
			_RingBuffer = new FxRingBuffer();
		}

		~FxSerialDeamon()
		{
			Dispose(false);
		}

		/// <summary>
		/// ��������ͨѶ
		/// 
		///		PLC �� D8120 ����Ϊ 0x0897�����ʾ 19200,7,1,E
		///		PLC �� D8120 ����Ϊ 0x0C8E�����ʾ 9600,7,1,E
		/// </summary>
		/// <returns>����ɹ����� true,���򷵻� false</returns>
		public bool Start(int portNo)
		{
			//return Start(portNo, "115200,E,7,1");
            //return Start(portNo, "9600,E,7,1");
            return Start(portNo, "9600,E,7,1");
        }

		public bool Start(int portNo, string serialParamString)
		{
			if (_SerialPort != null) {
				_SerialPort.Dispose();
			}

			_SerialPort = new SerialPortSync();
			_SerialPort.OpenPort(portNo, serialParamString);

			Debug.Print("\n FxSerialDeamon �� COM{0}: {1},\t{2}\n", portNo, serialParamString, _SerialPort.IsOpen ? "�ɹ�" : "ʧ��");

			return (_SerialPort.IsOpen);
		}

		public bool Start(SerialPortSync serialPortSyncObject)
		{
			if (_SerialPort != null) {
				_SerialPort.Dispose();
			}

			_SerialPort = serialPortSyncObject;

			Debug.Print("\n �� COM{0}: {1} \n", _SerialPort.PortNo, _SerialPort.IsOpen ? "�ɹ�" : "ʧ��");

			return (_SerialPort.IsOpen);
		}


		public FxCommandResponse Send(short channelNo, string data)
		{
			if (string.IsNullOrEmpty(data))
				return (null);

			byte[] buff = ASCIIEncoding.ASCII.GetBytes(data);

			return (Send(channelNo, buff, buff.Length));
		}

		public FxCommandResponse Send(short channelNo, string data, ICellDataType responseDataType)
		{
			if (string.IsNullOrEmpty(data))
				return (null);

			byte[] buff = ASCIIEncoding.ASCII.GetBytes(data);

			return (Send(channelNo, buff, buff.Length, responseDataType));
		}

		public FxCommandResponse Send(short channelNo, byte[] dataBuff, int dataSize)
		{
			return (Send(channelNo, dataBuff, dataSize, UInt8DataType.Default));
		}

		public FxCommandResponse Send(short channelNo, byte[] dataBuff, int dataSize, ICellDataType responseDataType)
		{
			byte[] resultBuff = null;
			FxCommandResponse result = new FxCommandResponse(ResultCodeConst.rcNotSettting, null, responseDataType);

			if (!_SerialPort.IsOpen)
				return (result);

			if (_SerialPort.BytesToWrite > 0) {
				//MyApp._LogWriter.WriteLine("׼��д����ǰ������д�������д�{0}�ֽ�û�з�����", _SerialPort.BytesToWrite);
			}

			int reReadTimes = 0;                                            // �ض�����

			_SerialPort.Write(dataBuff);

			System.Threading.Thread.Sleep(1);

			_RingBuffer.Clear();

			// ��ȡ���ݣ�ֱ���õ��������Ļ�ʱ
			reReadTimes = 0;
			while (reReadTimes < MAX_RETRY_READ_COUNT) {                    // ������ʱָ�����������ٵȴ�
				byte[] data = new byte[256];
				int len = _SerialPort.Read(data, 0, data.Length);

				if (len > 0) {
					reReadTimes = 0;
					_RingBuffer.Append(data, 0, len);

					resultBuff = _RingBuffer.PickPackage();

					if (resultBuff != null) {
						break;
					}

				} else {
					reReadTimes++;
					System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(1));
				}
			}

			// �����յ�������
			if (resultBuff == null) {
				result.ResultCode = ResultCodeConst.rcFailt;
				Debug.Print("�������ʱ����û���յ�FX PLC�ĺϷ���Ӧ.");
			} else if (resultBuff.Length == 1) {
				result.ResultCode = (ResultCodeConst)resultBuff[0];
			} else {
				result.ResultCode = ResultCodeConst.rcSuccess;

				List<int> valuelist;
				FxCommandHelper.ParseSmart(resultBuff, 0, responseDataType, out valuelist);

				result.SetResponseValue(valuelist);
				result.SetRawData(resultBuff);

			}

			return (result);
		}

		#region IControllerAction ��Ա

		public override bool Start()
		{
			if (string.IsNullOrEmpty(base.Param))
				return Start(base.ControllerAddress.ToDbInt());
			else
				return Start(base.ControllerAddress.ToDbInt(), base.Param);
		}

		public override bool Stop()
		{
			return base.Stop();
		}

		/// <summary>
		/// �������ڵ�ġ����ֵ��д���ⲿ�豸��PLC
		/// </summary>
		/// <param name="sourceList">�ڵ��б�</param>
		/// <param name="timeout">���ʱֵ</param>
		/// <returns>���سɹ�д�ĵ���</returns>
		public override int WritePoints(List<AcquirePoint> outputList, TimeSpan timeout)
		{
			int ct = 0;
			string cmd;
			FxCommandResponse res;

			foreach (AcquirePoint ap in outputList) {
				if (ap.ControllerObject.ControllerId != base.ControllerId)
					continue;
				if (ap.AV.Output.IsNull)
					continue;

				if (ap.AV.Output.B)
					cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn, new FxAddress(ap.ChannelNoAlias, FxAddressLayoutType.AddressLayoutByte));
				else
					cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff, new FxAddress(ap.ChannelNoAlias, FxAddressLayoutType.AddressLayoutByte));

				res = Send(0, cmd);

#if DEBUG
				//Logger.Instance.WriteLine("FxPLC���: {0} ", res.ToString());
#endif

				ct++;
			}

			return ct;
		}

		/// <summary>
		/// ��ȡ�豸����IO�����ݣ���������Щ�������ֵ
		/// </summary>
		public override List<AcquireRawValue> ReadAllPoints(List<AcquirePoint> sourceAPList, TimeSpan timeout)
		{
			if (_SerialPort == null || !_SerialPort.IsOpen)
				return null;

			List<AcquireRawValue> vlist = new List<AcquireRawValue>();

			if (sourceAPList != null) {
				sourceAPList.ForEach(o => {
					if (o.ControllerObject.ControllerId == this.ControllerId)
						vlist.Add(new AcquireRawValue(o.Id, o.ControllerObject, o.ChannelNoAlias));
				});
			} else {
				//for(int result = 0; result < 127; result++) {
				//    vlist.Add(new AcquireRawValue(0, 0, string.Format("X{0}", result)));
				//    vlist.Add(new AcquireRawValue(0, 0, string.Format("Y{0}", result)));
				//}
			}

			string cmd;
			FxCommandResponse res;

			// ��ȡ X0..X177,һ���Զ�ȡ����X
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("X0", ControllerTypeConst.ctPLC_Fx), 16);
			res = Send(0, cmd);
			//Debug.Print("X0--X177 = {0}", res.ToString());

			// ����ͨ���ű���������"X001","Y177","Mxxx"�����ݸ���
			if (res.ResultCode == ResultCodeConst.rcSuccess) {
				foreach (AcquireRawValue o in vlist) {
					if (o.PLCAddr != null && o.PLCAddr.AddressType == FxAddressType.X) {
						int byteIndex = (int)(o.PLCAddr.TagOffset / 8);
						int byteOff = (int)(o.PLCAddr.TagOffset % 8);

						if (byteIndex >= 0 && byteIndex < res.ResponseValue.Count) {
							o.Value = new ValueStruct(((res.ResponseValue[byteIndex] >> byteOff) & 0x01) == 0x01);

							//Debug.Print("X{0} <== {1}", Convert.ToString(o.PLCAddr.TagOffset, 8), o.Value);
						} else {
							//Debug.Print("X{0} <== {1}", Convert.ToString(o.PLCAddr.TagOffset, 8), o.Value);
						}
					}
				}
			} else {
				Debug.Print("{0}\t{1} ��ȡʧ��(X001-X177)", DateTime.Now, this.ToString());
			}

			// ��ȡ Y0..Y177,һ���Զ�ȡ����Y
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("Y0", ControllerTypeConst.ctPLC_Fx), 16);
			res = Send(0, cmd);
			//Debug.Print("Y0--Y177 = {0}", res.ToString());
			// ����ͨ���ű���������"Y177"�����ݸ���
			if (res.ResultCode == ResultCodeConst.rcSuccess) {
				foreach (AcquireRawValue o in vlist) {
					if (o.PLCAddr != null && o.PLCAddr.AddressType == FxAddressType.Y) {
						int byteIndex = (int)(o.PLCAddr.TagOffset / 8);
						int byteOff = (int)(o.PLCAddr.TagOffset % 8);

						if (byteIndex >= 0 && byteIndex < res.ResponseValue.Count) {
							o.Value = new ValueStruct(((res.ResponseValue[byteIndex] >> byteOff) & 0x01) == 0x01);
						} else {
							//Debug.Print("Y{0} <== {1}", Convert.ToString(o.PLCAddr.TagOffset, 8), o.Value);
						}
					}
				}
			} else {
				Debug.Print("{0}\t{1} ��ȡʧ��(Y001-Y177)", DateTime.Now, this.ToString());
			}

			// һ���Զ�ȡ M0..M499 
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("M0", ControllerTypeConst.ctPLC_Fx), 64);
			res = Send(0, cmd);

			//Debug.Print("M0--M499 = {0}", res.ToString());
			// ����ͨ���ű���������"M19"�����ݸ���
			if (res.ResultCode == ResultCodeConst.rcSuccess) {
				foreach (AcquireRawValue o in vlist) {
					if (o.PLCAddr != null && o.PLCAddr.AddressType == FxAddressType.M && o.PLCAddr.TagOffset < 1000) {
						int byteIndex = (int)(o.PLCAddr.TagOffset / 8);
						int byteOff = (int)(o.PLCAddr.TagOffset % 8);

						if (byteIndex >= 0 && byteIndex < res.ResponseValue.Count) {
							o.Value = new ValueStruct(((res.ResponseValue[byteIndex] >> byteOff) & 0x01) == 0x01);
						} else {
							//Debug.Print("M{0} <== {1}", Convert.ToString(o.PLCAddr.TagOffset, 8), o.Value);
						}
					}
				}
			} else {
				Debug.Print("{0}\t{1} ��ȡʧ��(M001-M499)", DateTime.Now, this.ToString());
			}

			#region һ���Զ�ȡ M1000-1999 ---- Ŀǰ����ȡ�����Χ�� M ��
			if (false) {
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("M1000", ControllerTypeConst.ctPLC_Fx), 32);
				res = Send(0, cmd);
				//Debug.Print("M1000--M1127 = {0}", res.ToString());
				// ����ͨ���ű���������"M1099"�����ݸ���
				if (res.ResultCode == ResultCodeConst.rcSuccess) {
					foreach (AcquireRawValue o in vlist) {
						if (o.PLCAddr != null && o.PLCAddr.AddressType == FxAddressType.M && o.PLCAddr.TagOffset >= 1000) {
							int byteIndex = (int)((o.PLCAddr.TagOffset - 1000) / 8);
							int byteOff = (int)((o.PLCAddr.TagOffset - 1000) % 8);

							if (byteIndex >= 0 && byteIndex < res.ResponseValue.Count) {
								o.Value = new ValueStruct(((res.ResponseValue[byteIndex] >> byteOff) & 0x01) == 0x01);
							} else {
								//Debug.Print("M{0} <== {1}", o.PLCAddr.TagOffset, o.Value);
							}
						}
					}
				}
			}
			#endregion

			// ��ȡ�������ݣ�C/D/T
			foreach (AcquireRawValue o in vlist) {
				if (o.PLCAddr != null) {
					switch (o.PLCAddr.AddressType) {
					case FxAddressType.C:
						cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, o.PLCAddr, 2);
						break;
					case FxAddressType.D:
						cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, o.PLCAddr, 2);
						break;
					case FxAddressType.T:
						cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, o.PLCAddr, 2);
						break;
					case FxAddressType.S:
						cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, o.PLCAddr, 2);
						break;
					default:
						continue;
					}

					res = Send(0, cmd);
					if (res.ResultCode == ResultCodeConst.rcSuccess) {
						o.Value = new ValueStruct((int)res.ResponseValue[0]);
						//Debug.Print("{0} <== {1}", o.PLCAddr.ToString(), o.Value);
					} else {
						//Debug.Print("{0} <== {1}. Error", o.PLCAddr.ToString(), o.Value);
					}

				}
			}

			return vlist;
		}

		public override string ToString()
		{
			return string.Format("FxSerialDeamon(COM{0}:,{1}),{2},{3},{4},{5}",
									_SerialPort == null ? base.ControllerAddress.ToDbInt() : _SerialPort.PortNo,
									base.Param,
									base.ControllerId, base.ControllerName, base.ControllerType,
									base.Enabled ? "Enabled" : "Disable");
		}

		#endregion

		private void Dispose(bool disposing)
		{
		}

		#region IDisposable ��Ա

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

	}
}
