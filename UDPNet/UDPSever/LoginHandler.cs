/****************************************************
	文件：LoginHandler.cs
	作者：Jwp
	邮箱: 2604591896@qq.com
	日期：2022/06/13 18:25   	
	功能：
*****************************************************/
using NetProtocol;
using System;
using System.Collections.Generic;
using System.Net;

namespace UDPSever {
    public class LoginHandler {
        public void ReqLogin(Body reqBody, IPEndPoint pt) {
            ReqLogicLogin req = reqBody.reqLogicLogin;
            Console.WriteLine("Client:{0} REqLogin,Acct:{1} Pass{2}", pt.ToString(), req.acct, req.pass);
            Body body = new Body {
                rspLogicLogin = new RspLogicLogin {
                    userData = new UserData {
                        uid = 7,
                        name = "Plane",
                        level = 17,
                        exp = 27,
                    }
                }
            };
            SeverRoot.Instance.SendMsg(CMD.LogicLogin, body, pt);
        }
    }
}
