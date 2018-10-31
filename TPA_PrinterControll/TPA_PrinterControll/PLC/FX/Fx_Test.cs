﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using InControls.Common;
using InControls.PLC;
using InControls.PLC.FX;
using InControls.Common;


namespace InControls.PLC.FX
{
	/// <summary>
	/// Fx功能测试类
	/// 可以直接调用本类内部的函数测试相应功能
	/// </summary>
	public class Fx_Test
	{
		private FxSerialDeamon _FxSerial;

		public void OpenPort ()
		{
			if(_FxSerial == null) {
				_FxSerial = new FxSerialDeamon();
				_FxSerial.Start(1);
			}
		}

		public void ClosePort ()
		{
			if(_FxSerial != null) {
				_FxSerial.Dispose();
			}
			_FxSerial = null;
		}

		public void Test_ReadAllPoints ()
		{
			List<AcquireRawValue> rawValues =
				_FxSerial.ReadAllPoints(null, TimeSpan.FromSeconds(3));
		}

		public void Test_All ()
		{
			string cmd;
			FxCommandResponse res;
			Random _Random = new Random();

			//// 置位
			//response = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn, new FxAddress("S1"));
			//res = _FxSerial.SendCmdToQnCPU(0, response);

			//// 复位
			//response = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff, new FxAddress("S1"));
			//res = _FxSerial.SendCmdToQnCPU(0, response);


			#region 读取所有 X/Y/M/ ,并计算其耗时

			Stopwatch sw = new Stopwatch();
			sw.Start();
			for(int ct = 0; ct < 10; ct++) {

				// 一次性读取多个字节的 X，例如 16 字节:：必须采用 AddressLayoutBin 方式
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("X0", ControllerTypeConst.ctPLC_Fx), 16);
				res = _FxSerial.Send(0, cmd);
				//Debug.WriteLine(string.Format("成批读X0..X177 \t{0}", res.ToString()));
				//System.Threading.Thread.Sleep(1000);

				// 一次性读取多个字节的 Y，例如 16 字节:：必须采用 AddressLayoutBin 方式
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("Y0", ControllerTypeConst.ctPLC_Fx), 16);
				res = _FxSerial.Send(0, cmd);
				//Debug.WriteLine(string.Format("成批读Y0..Y177 \t{0}", res.ToString()));
				//System.Threading.Thread.Sleep(1000);

				// 一次性读取多个字节的 M，每次读取128个单元:：必须采用 AddressLayoutBin 方式
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("M0", ControllerTypeConst.ctPLC_Fx), 128);
				res = _FxSerial.Send(0, cmd);
				//Debug.WriteLine(string.Format("成批读M{0}..M{1} \t{2}", result, result + 128, res.ToString()));

				Debug.Print("=====================> {0}", sw.ElapsedMilliseconds);

			}

			System.Threading.Thread.Sleep(1000);

			#endregion

			#region 针对 X/Y 的设置、读取

			// 置位与复位：必须采用 AddressLayoutByte 方式
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn, new FxAddress("Y20", FxAddressLayoutType.AddressLayoutByte));
			res = _FxSerial.Send(0, cmd);
			Debug.WriteLine(res.ToString());
			System.Threading.Thread.Sleep(1000);

			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff, new FxAddress("Y20", FxAddressLayoutType.AddressLayoutByte));
			res = _FxSerial.Send(0, cmd);
			Debug.WriteLine(res.ToString());
			System.Threading.Thread.Sleep(1000);

			// 针对 Y001..Y177 设置与读取
			for(int i = 0; i < 128; i++) {
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff,
										new FxAddress(string.Format("Y{0}", Convert.ToString(i, 8)), FxAddressLayoutType.AddressLayoutByte));
				res = _FxSerial.Send(0, cmd);
			}

			// 针对 Y001..Y077 设置与读取
			for(int i = 0; i < 128; i++) {
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn,
										new FxAddress(string.Format("Y{0}", Convert.ToString(i, 8)), FxAddressLayoutType.AddressLayoutByte));
				res = _FxSerial.Send(0, cmd);
				//Debug.WriteLine(res.ToString());
				System.Threading.Thread.Sleep(100);

				if((i - 8) >= 0) {
					cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff,
											new FxAddress(string.Format("Y{0}", Convert.ToString(i - 8, 8)), FxAddressLayoutType.AddressLayoutByte));
					res = _FxSerial.Send(0, cmd);
					Debug.WriteLine(string.Format("Y{0}\t{1}", Convert.ToString(i, 8), res.ToString()));
				}

				//System.Threading.Thread.Sleep(1000);
			}

			// 一次性读取多个字节的 X，例如 16 字节:：必须采用 AddressLayoutBin 方式
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("X0", ControllerTypeConst.ctPLC_Fx), 16);
			res = _FxSerial.Send(0, cmd);
			Debug.WriteLine(string.Format("成批读X0..X177 \t{0}", res.ToString()));
			System.Threading.Thread.Sleep(1000);

			// 一次性读取多个字节的 Y，例如 16 字节:：必须采用 AddressLayoutBin 方式
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("Y0", ControllerTypeConst.ctPLC_Fx), 16);
			res = _FxSerial.Send(0, cmd);
			Debug.WriteLine(string.Format("成批读Y0..Y177 \t{0}", res.ToString()));
			System.Threading.Thread.Sleep(1000);

			#endregion


			#region 针对 M 类型的读写
			// 针对 M001..M077 设置与读取
			for(int i = 0; i < 64; i++) {
				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn,
										new FxAddress(string.Format("M{0}", i), FxAddressLayoutType.AddressLayoutByte));
				res = _FxSerial.Send(0, cmd);
				Debug.WriteLine(res.ToString());

				//response = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff,
				//                        new FxAddress(string.Format("M{0}", Convert.ToString(result, 8)), FxAddressLayoutType.AddressLayoutByte));
				//res = _FxSerial.SendCmdToQnCPU(0, response);
				//Debug.WriteLine(res.ToString());

				//System.Threading.Thread.Sleep(100);
			}

			// 一次性读取多个字节的 M，例如 16 字节:：必须采用 AddressLayoutBin 方式
			cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("M0", ControllerTypeConst.ctPLC_Fx), 64);
			res = _FxSerial.Send(0, cmd);
			Debug.WriteLine(string.Format("成批读M0..M77 \t{0}", res.ToString()));
			System.Threading.Thread.Sleep(1000);

			#endregion


			#region 循环设置与读取 Dxxx 的数据
			for(int i = 0; i < 1; i++) {

				List<uint> lst = new List<uint>() { (uint)i };
				for(int k = 0; k < 10; k++)
					lst.Add((uint)_Random.Next());

				cmd = FxCommandHelper.Make<UInt32DataType>(FxCommandConst.FxCmdWrite, new FxAddress("D1", ControllerTypeConst.ctPLC_Fx), lst);
				res = _FxSerial.Send(0, cmd);
				Debug.WriteLine(res.ToString());

				cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("D1", ControllerTypeConst.ctPLC_Fx), lst.Count * 4);
				res = _FxSerial.Send(0, cmd, UInt32DataType.Default);
				Debug.WriteLine(res.ToString());

				if(res.ResponseValue != null && res.ResponseValue.Count > 0) {
					Debug.WriteLine("");
					Debug.Write(DateTime.Now.ToString());
					Debug.Write("\t");
					for(int j = 0; j < res.ResponseValue.Count; j++) {
						Debug.Write(res.ResponseValue[j]);
						Debug.Write(',');
					}
				} else {
					Debug.WriteLine("没有收到FX PLC响应。");
				}
			}
			#endregion


			Debug.Assert(false, "运行暂停！！！");
		}
	}
}
