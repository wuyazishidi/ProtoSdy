/****************************************************
	文件：Pkg.cs
	作者：Jwp
	邮箱: 2604591896@qq.com
	日期：2022/06/13 18:26   	
	功能：背包
*****************************************************/
using System;
using System.Collections.Generic;

namespace NetProtocol {
    [Serializable]
    public class Pkg {
        public Head head;
        public Body body;
    }
    [Serializable]
    public class Head {
        public CMD cmd;
        public int seq;
        public int error;
    }
    [Serializable]
    public class Body {
        public ReqLogicLogin reqLogicLogin;
        public RspLogicLogin rspLogicLogin;
        public ReqBagInfo reqBagInfo;
        public RspBagInfo rspBagInfo;
    }
    #region
    public class ReqLogicLogin {
        public string acct;
        public string pass;
    }

    public class RspLogicLogin {
        public UserData userData;
    }

    public class UserData {
        public int uid;//   ID
        public string name;
        public int level;
        public int exp;
    }
    #endregion
    #region BagInfo
    [Serializable]
    public class ReqBagInfo {
        //TOADD
    }

    [Serializable]
    public class RspBagInfo {
        public List<BagItem> itemLst;
    }
    public class BagItem {

        public int id;//物品id
        public int type;//物品类型
        public string des;//物品描述
    }
    #endregion
    [Serializable]
    public enum Error {
        db_data_error = 1,
        acct_data_error = 2001,//贴数据异常
        team_wait_enter = 2002,//排队等待进入队伍

        bag_data_error = 2003,
    }


    public enum CMD {
        None = 0,
        LogicLogin = 1,
        BagInfo = 2,
    }
}
