/****************************************************
	文件：BagHandler.cs
	作者：JWP
	邮箱: 2604591896@qq.com
	日期：2022/06/14 22:35   	
	功能：
*****************************************************/
using NetProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace UDPClient {
    public class BagHandler {
		public void HandleBagData(RspBagInfo rsp) {
			List<BagItem> itemLst = rsp.itemLst;
            for (int i = 0; i < itemLst.Count; i++) {
				Console.WriteLine("id:"+itemLst[i].id);
				Console.WriteLine("type:"+itemLst[i].type);
				Console.WriteLine("des:"+itemLst[i].des);
				Console.WriteLine("------------------------");
            }
		}
    }
}
