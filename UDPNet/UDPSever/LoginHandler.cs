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
