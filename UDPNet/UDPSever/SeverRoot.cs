/****************************************************
	文件：SeverRoot.cs
	作者：Jwp
	邮箱: 2604591896@qq.com
	日期：2022/06/13 12:21   	
	功能：服务器根节点
*****************************************************/
using NetProtocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPSever {
    public class SeverRoot {

        UdpClient udp;
        LoginHandler loginHandler;
        BagHandler bagHandler;
        private static SeverRoot instance;
        public static SeverRoot Instance {
            get {
                if (instance == null) {
                    instance = new SeverRoot();
                }
                return instance;
            }
        }
        public void Init() {
            loginHandler = new LoginHandler();
            bagHandler = new BagHandler();
            udp = new UdpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 17666));
            Task.Run(SeverRecive);
        }

        async void SeverRecive() {
            UdpReceiveResult result;
            while (true) {
                result = await udp.ReceiveAsync();
                byte[] data = result.Buffer;

                //客户端IP
                IPEndPoint remotePoint = result.RemoteEndPoint;
                Console.WriteLine("Rcv CLient Data From :"+remotePoint.ToString());

                Pkg pkg = ProtocolTool.DeSerialize(data);
                switch (pkg.head.cmd) {
                    case CMD.LogicLogin:
                        loginHandler.ReqLogin(pkg.body,remotePoint);
                        break;
                    case CMD.BagInfo:
                        bagHandler.ReqBagInfo(pkg.body,remotePoint);
                        break;
                    case CMD.None:
                        break;
                    default:
                        break;
                }
            }
        }

        public void SendMsg(CMD cmd,Body body,IPEndPoint pt) {
            Pkg pkg = new Pkg {
                head = new Head {
                    cmd = cmd,
                    seq = 6,
                    error = 0
                },
                body = body,
            };
            byte[] bytes = ProtocolTool.Serialize(pkg);
            udp.Send(bytes,bytes.Length,pt);//同步发送
        }
    }



}
