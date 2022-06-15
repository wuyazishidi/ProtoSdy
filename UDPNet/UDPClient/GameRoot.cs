using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NetProtocol;

namespace UDPClient {
    public class GameRoot {
        UdpClient udp;
        LoginHandler loginHandler;
        BagHandler bagHandler;
        //服务器IP
        IPEndPoint remotePoint;
        private static GameRoot instance;
        public static GameRoot Instance {
            get {
                if (instance == null) {
                    instance = new GameRoot();
                }
                return instance;
            }
        }
        public void Init() {
            remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),17666);
            loginHandler = new LoginHandler();
            bagHandler = new BagHandler();
            //设置为0，则客户端发送端口由系统分配
            udp = new UdpClient(0);
            Task.Run(ClientRecive);
        }

        async void ClientRecive() {
            UdpReceiveResult result;
            while (true) {
                result = await udp.ReceiveAsync();
                byte[] data = result.Buffer;

                //服务端IP
                IPEndPoint srvPt = result.RemoteEndPoint;
                Console.WriteLine("Rcv Sever Data From :" + srvPt.ToString());

                Pkg pkg = ProtocolTool.DeSerialize(data);
                switch (pkg.head.cmd) {
                    case CMD.LogicLogin:
                        loginHandler.HandleLoginData(pkg.body.rspLogicLogin);
                        break;
                    case CMD.BagInfo:
                        bagHandler.HandleBagData(pkg.body.rspBagInfo);
                        break;
                    case CMD.None:
                        break;
                    default:
                        break;
                }
            }
        }
        public void ReqLogin() {
            Pkg pkg = new Pkg {
                head = new Head {
                    cmd = CMD.LogicLogin,
                    seq = 6,
                    error = 0
                },
                body = new Body {
                    reqLogicLogin = new ReqLogicLogin {
                        acct = "Plane",
                        pass = "www.qiqiker.com"
                    }
                },
            };
            byte[] bytes = ProtocolTool.Serialize(pkg);
            udp.Send(bytes, bytes.Length, pt);//同步发送
        }

        public void ReqBag() {
            Pkg pkg = new Pkg {
                head = new Head {
                    cmd = CMD.BagInfo,
                    seq = 2,
                    error = 0
                },
            };
            byte[] bytes = ProtocolTool.Serialize(pkg);
            udp.Send(bytes, bytes.Length, remotePoint);//同步发送
        }
    }
}
