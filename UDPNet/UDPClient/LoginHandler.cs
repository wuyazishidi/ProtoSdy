/****************************************************
	文件：LoginHandler.cs
	作者：JWP
	邮箱: 2604591896@qq.com
	日期：2022/06/14 22:35   	
	功能：处理登陆回应数据
*****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NetProtocol;

namespace UDPClient {
    public class LoginHandler {
		public void HandleLoginData(RspLogicLogin rsp) {
			Console.WriteLine("Uid:"+rsp.userData.uid);
			Console.WriteLine("Name:"+rsp.userData.name);
			Console.WriteLine("Level:"+rsp.userData.level);
			Console.WriteLine("Exp："+rsp.userData.exp);
		}
    }
}
