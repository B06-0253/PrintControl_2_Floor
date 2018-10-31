using System;
using System.Threading;
using Vila.Threading.Queue;

using InControls.Common;

namespace InControls.PLC.FX
{
	public sealed class FxCommController
	{

		#region ��ȡʵʱ���ݵļ��/���ڣ���λ���룩
		private readonly int READ_REAL_DATA_INTERNAL = 5;
		#endregion

		#region ͨѶ��������̬ʵ�� Instance ������ʵ�ִ���
		private static FxCommController _Instance;

		public static FxCommController Instance
		{
			get
			{
				if (_Instance == null) {
					lock (typeof(FxCommController)) {
						_Instance = new FxCommController(true);
					}
				}
				return FxCommController._Instance;
			}
		}
		#endregion


		private FxSerialDeamon _SerialDeamon;

		private DataBlockQueue<FxCommandArgs> _DataBlockQueue;

		private System.Threading.Timer _Timer;
		private Thread _Thead;
		private bool _StopTheadFlag;							// ����ֹͣ�̵߳ı�־

		private DateTime _FirstFailtTime;						// �״�ͨѶʧ��ʱ��

		private EventWaitHandle _WaitHandle;                     // ��ʱͬ�����������ͬ�����ã���ʹ�ñ��ȴ�����

		/// <summary>
		/// ��Ĭ�ϴ���������������
		/// ����� COM1 �Զ�����
		/// </summary>
		/// <param name="autoStartFromDefaultSerialPort"></param>
		private FxCommController(bool autoStartFromDefaultSerialPort)
		{
			_WaitHandle = null;

			_DataBlockQueue = new DataBlockQueue<FxCommandArgs>(64, true);

			_SerialDeamon = null;
			_Thead = null;
			_Timer = null;
			_FirstFailtTime = DateTime.MaxValue;
			_StopTheadFlag = false;

			if (autoStartFromDefaultSerialPort) Start(1);
		}

		/// <summary>
		/// ������RS232��ͨѶ�߳�
		/// </summary>
		public void Start(int portNo)
		{
			_SerialDeamon = new FxSerialDeamon();
			_SerialDeamon.Start(portNo);

			_Thead = new Thread(new ThreadStart(this.DealwithCommunicationRoute));
			_Thead.Name = "FxCommController";
			_Thead.IsBackground = true;
			_Thead.Start();

			_Timer = new Timer(new TimerCallback(TimerRoute));
			_Timer.Change(TimeSpan.FromSeconds(10), TimeSpan.FromDays(1));
		}

		/// <summary>
		/// �ر��߳�
		/// </summary>
		public void Stop()
		{
			_SerialDeamon.Dispose();
			_SerialDeamon = null;

			_Timer.Dispose();
			_Timer = null;

			_Thead.Abort();
			_Thead.Join();
			_Thead = null;
		}

		/// <summary>
		/// �첽������������̷���
		/// �����ڲ�ʵ�ַ��Ͷ��С��Լ���ʱ����
		/// </summary>
		/// <param name="response">������</param>
		/// <param name="cmdData">�������ݣ��� 0xAA,0xCC,0x83 ��ͷ��byte[] </param>
		public void PostCall(short cmd, byte[] cmdData)
		{
			FxCommandArgs cmdArgs = new FxCommandArgs(cmd, cmdData);
			_DataBlockQueue.Add(cmdArgs);
		}

		/// <summary>
		/// �첽��������
		/// ���ڷ��ͺ�Ͳ��ܵġ��첽���
		/// </summary>
		/// <param name="cmdArgs">������OnSendHandle��ԱӦ��Ϊ�հ�</param>
		public void PostCall(FxCommandArgs cmdArgs)
		{
			_DataBlockQueue.Add(cmdArgs);
		}

		/// <summary>
		/// �첽��������
		/// ������Ӧ��ʵ���� IDataPackageEvent�������ṩ����
		/// </summary>
		/// <param name="cmdArgs">������OnSendHandle��ԱӦ��Ϊ�հ�</param>
		/// <param name="onSendHandle">������Ҫ���û����ṩ�ص���</param>
		//public void PostCall(CommandEventArgs cmdArgs, IDataPackageEvent onSendHandle)
		//{
		//    System.Diagnostics.Debug.Assert(onSendHandle != null, "�����߱���ʵ��IDataPackageEvent���ҽ����ô��뱾����");

		//    if (cmdArgs.OnSendHandle == null) cmdArgs.OnSendHandle = onSendHandle;
		//    _DataBlockQueue.Add(cmdArgs);
		//}

		/// <summary>
		/// ͬ����������
		/// </summary>
		/// <param name="cmdArgs">������OnSendHandle��Ա���븳ֵΪ����������</param>
		public FxCommandResponse SendCall(FxCommandArgs cmdArgs, TimeSpan timeout)
		{
			if (cmdArgs == null) return (null);

			if (_WaitHandle == null) {
				_WaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
			}

			_DataBlockQueue.Add(cmdArgs);

			_WaitHandle.WaitOne(timeout, true);
			_WaitHandle.Close();
			_WaitHandle = null;

			return (cmdArgs.Result);
		}

		/// <summary>
		/// ͬ������������ȴ�����
		/// �����ڲ�ʵ�ַ��Ͷ��С��Լ���ʱ����
		/// </summary>
		/// <param name="response">������</param>
		/// <param name="channelNo">ͨ���ţ�Ĭ��0</param>
		/// <param name="cmdData">�������ݣ��� 0xAA,0xCC,0x83 ��ͷ��byte[] </param>
		/// <param name="timeout">���ʱ�趨</param>
		public FxCommandResponse SendCall(short cmd, byte channelNo, byte[] cmdData, TimeSpan timeout)
		{
			if (cmdData == null) {              // �������û�й��죬��Ĭ�Ϲ����޲���������
				FxCommandResponse prm = new FxCommandResponse(ResultCodeConst.rcNotSettting, cmdData);
				//cmdData = _CommanderHelper.MakeSmart(response, targetPort, prm);
			}

			FxCommandArgs arg = new FxCommandArgs(cmd, cmdData, channelNo);

			return (SendCall(arg, timeout));
		}


		/// <summary>
		/// �����Է��Ͷ�ʵʱ��������
		/// ���ԣ�
		///     1�������ڿ���ʱ����
		///     2��������Ͷ����������ݣ����ٲ���
		/// </summary>
		private void TimerRoute(Object state)
		{
			if (_DataBlockQueue.QueueLength == 0) {
				// ��������Ͷ�����û�����ݣ�������,1:��ȡʵʱ����
				byte[] cmdbuff = new byte[11];
				_DataBlockQueue.Add(new FxCommandArgs(0, cmdbuff, 0));

				// ��������Ͷ�����û�����ݣ�������,2:�����������ȡʱ�̡�״̬��Ϣ
				_DataBlockQueue.Add(new FxCommandArgs(0, cmdbuff, 0));
			}
			_Timer.Change(TimeSpan.FromSeconds(READ_REAL_DATA_INTERNAL), TimeSpan.FromDays(1));
		}

		/// <summary>
		/// �ڲ����ڴ����շ��Ķ����߳�
		/// �����ڲ�ʵ��ͬ���շ�
		/// </summary>
		private void DealwithCommunicationRoute()
		{
			while (!_StopTheadFlag) {
				if (_DataBlockQueue.QueueLength == 0) {
					Thread.Sleep(20);
					continue;
				}

				FxCommandArgs arg = _DataBlockQueue.Pick();
				if (arg == null) continue;

				FxCommandResponse result = _SerialDeamon.Send(arg.ChannelNo, arg.Data, arg.Data.Length);

				if (result.ResultCode == ResultCodeConst.rcFailt) {
					// �������ʧ�ܣ����ۼ���ʧ��ʱ�䣬���ﳬʱֵ����Ҫ��UI�������з���
					if (DateTime.Now.Subtract(_FirstFailtTime).TotalSeconds > 30) {
						_FirstFailtTime = DateTime.Now;
					} else if (_FirstFailtTime == DateTime.MaxValue) {
						_FirstFailtTime = DateTime.Now;
					}

				} else if (result != null) {
					_FirstFailtTime = DateTime.MaxValue;

					switch (arg.Cmd) {
					case 1:                             // �����...
						break;
					default:
						break;
					}
				} else {
				}

				if (_WaitHandle != null) {
					arg.Result = result;
					_WaitHandle.Set();
				}

				//if (arg.OnSendHandle != null) {
				//    arg.OnSendHandle.OnPackageRecived(result);
				//}

			}
			System.Diagnostics.Debug.Assert(false, "�˳��߳��ˣ���");
			_Thead = null;
		}
	}
}
