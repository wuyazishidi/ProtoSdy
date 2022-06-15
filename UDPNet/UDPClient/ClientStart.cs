using System;

namespace UDPClient {
    class ClientStart {
        static void Main(string[] args) {
            Console.WriteLine("Client Start...");
            GameRoot.Instance.Init();
            while (true) {
                string ipt = Console.ReadLine();
                if (ipt == "login") {
                    GameRoot.Instance.ReqLogin();
                }
                else if (ipt=="bag") {
                    GameRoot.Instance.ReqBag();
                }
                else {
                    Console.WriteLine("command undefined!");
                }
            }
        }
    }
}
