using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace InControls.SerialDevice
{
	/// <summary>
	/// �� .Net �� SerialPort ���м򵥷�װ���γ�ͬ���շ���ר�ð汾
	/// �����Ҫ��ϵͳ�ڲ�ʹ�ô��ڣ�����ʹ������ࣨSerialPortSync��
	/// </summary>
	public class SerialPortSync : IDisposable
	{
		private System.IO.Ports.SerialPort _PortObj;					// �����շ����ݵĴ���
		private int _PortNo;											// �˿ںţ����硰COM1:���� 1 ��ʾ

		private int _BaudRate;
		private int _DataBits;
		private StopBits _StopBites;
		private Parity _Parity;

		private TimeSpan _MaxTimeout;									// ���ʱ�������/д����Ĭ��1��

		#region ���Դ����
		public int PortNo
		{
			get { return _PortNo; }
			set { _PortNo = value; }
		}

		public int DataBits
		{
			get { return _DataBits; }
		}

		public int BytesToRead
		{
			get { return (_PortObj == null ? 0 : _PortObj.BytesToRead); }
		}

		public int BytesToWrite
		{
			get { return (_PortObj == null ? 0 : _PortObj.BytesToWrite); }
		}

		public string NewLine
		{
			get { return (_PortObj == null ? String.Empty : _PortObj.NewLine); }
			set { if (_PortObj != null)_PortObj.NewLine = value; }
		}

		public bool IsOpen
		{
			get
			{
				return (_PortObj == null ? false : _PortObj.IsOpen);
			}
		}

		public TimeSpan MaxTimeout
		{
			get { return _MaxTimeout; }
			set { _MaxTimeout = value; }
		}

		#endregion

		public SerialPortSync()
		{
			_PortNo = 0;
			_PortObj = null;
			_BaudRate = 9600;
			_DataBits = 8;
			_StopBites = StopBits.One;
			_Parity = Parity.None;

			_MaxTimeout = TimeSpan.FromSeconds(1);
		}

		public SerialPortSync(System.IO.Ports.SerialPort existedPort)
		{
			_PortNo = Convert.ToInt16(existedPort.PortName.Substring(3));
			_PortObj = existedPort;
			_BaudRate = existedPort.BaudRate;
			_DataBits = existedPort.DataBits;
			_StopBites = existedPort.StopBits;
			_Parity = existedPort.Parity;

			_PortObj.ReadTimeout = 100;
			_MaxTimeout = TimeSpan.FromSeconds(1);
		}

		/// <summary>
		/// Ĭ�ϲ���Ԥ�貨���ʴ� COM1.
		/// </summary>
		public bool OpenPort()
		{
			try {
				OpenPort(_PortNo, 9600);
			} catch (Exception e) {
				Trace.WriteLine(e.ToString());
			}
			return (IsOpen);
		}

		public bool OpenPort(int portNo, int baudRate)
		{
			return OpenPort(portNo, baudRate, 8, _StopBites, _Parity, Handshake.None);
		}

		/// <summary>
		/// ʹ��ָ�������򿪴���
		/// </summary>
		/// <param name="portNo"></param>
		/// <param name="openParamString">�򿪴��ڵĲ��������硰9600,n,8,1��</param>
		/// <returns></returns>
		public bool OpenPort(int portNo, string openParamString)
		{
			SerialParam sp = new SerialParam(openParamString);
			return (OpenPort(portNo, sp.BaudRate, sp.DataBits, sp.StopBits, sp.Parity, Handshake.None));
		}

		public bool OpenPort(int portNo, int baudRate, int dataBits, StopBits stopBites, Parity parity, Handshake handshake)
		{

			_PortNo = portNo;

			if (_PortNo == 0) {
				Debug.Assert(false, "���������趨���ںţ������޷��򿪣�");
				return (false);										// û���趨�˿ں�
			}

			if (_PortObj == null) {
				_PortObj = SerialPortManager.Instance.GetComPortInstance(_PortNo);
			}
			if (_PortObj == null) {
				Debug.Print("���� COM{0}: ������.�������û����.", portNo);
				return (false);
			} else {

				try {
					if (!_PortObj.IsOpen) {
						_PortObj.BaudRate = baudRate;							// Ĭ�����ʡ�����λ��ֹͣλ��У��λ�Ȳ���
						_PortObj.DataBits = dataBits;
						_PortObj.StopBits = stopBites;
						_PortObj.Parity = parity;
						_PortObj.Handshake = handshake;
						_PortObj.DtrEnable = true;
						_PortObj.ReceivedBytesThreshold = 256;
						//m_PortObj.RtsEnable = false;
						//m_PortObj.DiscardNull = false;
						//m_PortObj.ReadBufferSize = 20480;
						//m_PortObj.WriteBufferSize = 10240;
						//m_PortObj.NewLine = string.Empty;
						_PortObj.ReadTimeout = 10000;
						_PortObj.WriteTimeout = Timeout.Infinite;
						_PortObj.Open();

						_PortObj.ErrorReceived += new SerialErrorReceivedEventHandler(this.OnSerialErrorReceivedEvent);

					} else {
						Debug.Print("���Դ򿪴��� {0}: ʱ�����������Ѵ򿪣�������ϵͳ�еĶ���豸ʹ������ͬ�Ĵ��ںţ�����ϸ��顣���ϵͳʹ�ù���Ĵ����豸�����ٴ��ޡ�", _PortObj.PortName);
					}
				} catch (UnauthorizedAccessException e) {						// ���ڲ����ڻ��Ѿ������������
					Debug.Print("���� {0}: �����ڻ��Ѿ������������", _PortObj.PortName, e.ToString());
					_PortObj.Dispose();
					_PortObj = null;
				} catch (Exception e) {
					Debug.Print("���� {0}: ��ʧ��", _PortObj.PortName, e.ToString());
				}
			}
			return (true);
		}

		public void ClosePort()
		{
			if (_PortObj != null) {
				if (_PortObj.IsOpen) {
					_PortObj.Close();
				}
				_PortObj.Dispose();
				_PortObj = null;
			}
		}

		public void Write(string s)
		{
			_PortObj.Write(s);
		}

		public void Write(byte[] buff)
		{
			Write(buff, 0, buff.Length);
		}

		public void Write(byte[] buff, int offset, int count)
		{
			_PortObj.Write(buff, offset, count);
		}

		public string ReadExisting()
		{
			return (_PortObj.ReadExisting());
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			int bytesToRead = _PortObj.BytesToRead;

			try {
				if (bytesToRead > 0) {
					return (_PortObj.Read(buffer, offset, Math.Min(buffer.Length - offset, count)));
				}
			} catch (IOException e) {
				int errno = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
				if (errno != 997) {
					Debug.Print("{0}\tͬ���������쳣�� COM{1}, Read(buffer size={2},offset={3},count={4}),BytesToRead={5},Win32Error={6} \r\n\t {7}",
								DateTime.Now,
								_PortNo, buffer.Length, offset, count, bytesToRead, errno, e.ToString());
				}

			}
			return (0);
		}

		/// <summary>
		/// ͬ�������ݡ�ֱ����Ϊ��������������ʱ
		/// </summary>
		/// <param name="buffer">���صĻ�����</param>
		/// <param name="offset">��ŵ�����������ʼƫ����</param>
		/// <param name="count">����ֽ���</param>
		/// <param name="timeout">��ʱ</param>
		/// <returns></returns>
		public int ReadSync(byte[] buffer, int offset, int count, TimeSpan timeout)
		{
			return ReadSync(buffer, offset, count, timeout, null);
		}

		/// <summary>
		/// ͬ�������ݡ�ֱ����Ϊ��������������ʱ��������һ�������
		/// ע�⣺�յ��������ʱ�����ܼٶ���ȷ����ǡ�ô��ڻ�������β��
		/// </summary>
		/// <param name="buffer">���صĻ�����</param>
		/// <param name="offset">��ŵ�����������ʼƫ����</param>
		/// <param name="count">����ֽ���</param>
		/// <param name="timeout">��ʱ</param>
		/// <param name="endFlags">��������飬һ�����ջ������з�����һ�������,���ټ�����ȡ</param>
		/// <returns></returns>
		public int ReadSync(byte[] buffer, int offset, int count, TimeSpan timeout, List<byte[]> endFlags)
		{
			DateTime start = DateTime.Now;
			int len = offset;

			while (DateTime.Now.Subtract(start).TotalMilliseconds < timeout.TotalMilliseconds) {                  // ������ʱָ�����������ٵȴ�

				if (_PortObj.BytesToRead == 0) System.Threading.Thread.Sleep(1);
				len = len + _PortObj.Read(buffer, len, count - len);

				// ��ѯ���յ��Ļ��������Ƿ����������
				if (endFlags != null) {
					foreach (byte[] bytsMark in endFlags) {
						for (int i = 0; i < (len - bytsMark.Length); i++) {
							bool found = true;

							for (int k = 0; k < bytsMark.Length; k++) {
								if (buffer[i + k] != bytsMark[k]) {
									found = false;
									break;
								}
							}

							if (found) goto LBL_EXIT;
						}
					}
				}
			}

		LBL_EXIT:
			return (len);
		}

		public void DiscardInBuffer()
		{
			_PortObj.DiscardInBuffer();
		}

		public void DiscardOutBuffer()
		{
			_PortObj.DiscardOutBuffer();
		}

		private void OnSerialErrorReceivedEvent(Object sender, SerialErrorReceivedEventArgs e)
		{
			//Debug.Assert( false, e.ToString( ) );
		}

		#region IDisposable ��Ա
		public void Dispose()
		{
			if (_PortObj != null) {
				ClosePort();
			}
			_PortObj = null;
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
