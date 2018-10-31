using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace InControls.SerialDevice
{

	/// <summary>
	/// ���пڹ�����
	/// 
	/// ����ȫ���Զ˿ڵ���,���ڴ��ڵĴ򿪡��رա�IO(����/���)�Ĺ���
	/// ÿ�������豸һ���򿪣��򱣳�ȫ��Ψһ���Ա��ֹ�������
	/// </summary>
	public sealed class SerialPortManager
	{
		private static SerialPortManager _Instance;

		public static SerialPortManager Instance
		{
			get
			{
				if (_Instance == null) {
					lock (typeof(SerialPortManager)) {
						if (_Instance == null) {
							_Instance = new SerialPortManager();
						}
					}
				}
				return SerialPortManager._Instance;
			}
		}

		private List<System.IO.Ports.SerialPort> _PortList;
		private int _PortCount = 0;

		private SerialPortManager()
		{
			string[] names;
			names = System.IO.Ports.SerialPort.GetPortNames();

			_PortCount = 2;				// Ĭ������2��
			foreach (string s in names) {
				int ct = Convert.ToInt16(s.Substring(3));
				if (ct > _PortCount) _PortCount = ct;
			}

			_PortList = new List<SerialPort>(Math.Max(8, _PortCount + 1));			// ��ʱ֧������ 8 ���˿�
			for (int i = 0; i < _PortList.Capacity; i++) {
				_PortList.Add(null);
			}
		}

		public int ComPortCount()
		{
			return (_PortCount);
		}

		/// <summary>
		/// �õ�ָ����ŵĶ˿ڵ�����
		/// </summary>
		/// <param name="PortNo">���ںţ���1..Max</param>
		/// <returns>�˿�����</returns>
		public string GetPortName(int portNo)
		{
			string[] names;
			names = System.IO.Ports.SerialPort.GetPortNames();

			foreach (string s in names) {
				if (int.Parse(s.Substring(3, 1)) == portNo) {
					return (s);
				}
			}
			return (null);
		}

		/// <summary>
		/// ���ݴ������ƣ��õ����Ӧ�����
		/// </summary>
		/// <param name="PortNo">�˿����ƣ����硰COM1������COM2��</param>
		/// <returns>������ţ����硰1������2���������Ʋ����ڷ���0</returns>
		public int GetPortNo(string portName)
		{
			string[] names;
			names = System.IO.Ports.SerialPort.GetPortNames();

			foreach (string s in names) {
				if (s == portName) {
					return (int.Parse(s.Substring(3, 1)));
				}
			}
			return (0);
		}

		/// <summary>
		/// �õ�ָ���˿ں����ʵ��
		/// ��ʵ�������ں����Ĳ�����������Ҫ�򿪹����Ķ˿�
		/// </summary>
		/// <param name="PortNo">���ж˿ںţ���Χ 1..Max </param>
		/// <returns></returns>
		public System.IO.Ports.SerialPort GetComPortInstance(int portNo)
		{
			return (GetComPortInstance("COM" + portNo.ToString()));
		}

		/// <summary>
		/// �õ�ָ���˿����Ƶ�ʵ��
		/// ��ʵ�������ں�����IO������������Ҫ�򿪹����Ķ˿�
		/// </summary>
		/// <param name="PortNo">���ж˿��������� ��COM1�� ����Χ 1..Max </param>
		/// <returns></returns>
		public System.IO.Ports.SerialPort GetComPortInstance(string portName)
		{
			int nPortNo;

			nPortNo = GetPortNo(portName);
			if (nPortNo <= 0) return (null);

			System.IO.Ports.SerialPort sp = _PortList[nPortNo];

			if (sp == null) {							// һ�㲻���ܳ����Ҳ����豸�����
				sp = new SerialPort(portName);
				sp.BaudRate = 9600;						// Ĭ�����ʡ�����λ��ֹͣλ��У��λ�Ȳ���
				sp.DataBits = 8;
				sp.StopBits = StopBits.One;
				sp.Parity = Parity.None;
				sp.Handshake = Handshake.RequestToSendXOnXOff;
				_PortList[nPortNo] = sp;
				return (sp);
			}
			return (sp);
		}


	}
}
