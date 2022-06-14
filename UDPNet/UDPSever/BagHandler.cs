using NetProtocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UDPSever {
   public class BagHandler {
        public void ReqBagInfo(Body reqBody,IPEndPoint pt) {
            Console.WriteLine("Client:{0} ReqBagInfo.",pt.ToString());
            Body body = new Body {
                rspBagInfo = new RspBagInfo(),
            };
            body.rspBagInfo.itemLst.Add(new BagItem { id=1,type=0,des="印度神油"});
            body.rspBagInfo.itemLst.Add(new BagItem { id=2,type=0,des="汇仁肾宝"});
            body.rspBagInfo.itemLst.Add(new BagItem { id=3,type=1,des="大力出奇迹"});
            SeverRoot.Instance.SendMsg(CMD.BagInfo,body,pt);
        }
    }
}
