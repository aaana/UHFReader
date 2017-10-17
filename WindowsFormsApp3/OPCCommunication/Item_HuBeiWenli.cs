using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCCommunication
{
    public class Item_HuBeiWenli: IOPCItem
    {
        public const string RUN = "Microwin.NewPLC.Group.Action";//起停状态
        //public const string SET_SPEED = "Microwin.NewPLC.group.speed";//速度设置
        public const string REAL_SPEED = "Microwin.NewPLC.Group.Speed";//实际速度
        public const string ERROR = "Microwin.NewPLC.Group.Error";//故障状态
        //public const string CIRCLE_NUMBER = "Microwin.NewPLC.group.circle";//圈数
        public const string STATUS = "Microwin.NewPLC.Group.Status";//紧急停止状态
        public const string SORT = "Microwin.NewPLC.Group.Sort";//分拣
        public const string TRIGGER = "Microwin.NewPLC.Group.Trigger";//光电检测

        public List<string> GetItemList()
        {
            List<string> itemList = new List<string>();
            itemList.Add(RUN);
           // itemList.Add(SET_SPEED);
            itemList.Add(REAL_SPEED);
            itemList.Add(ERROR);
           // itemList.Add(CIRCLE_NUMBER);
            itemList.Add(STATUS);
            itemList.Add(SORT);
            itemList.Add(TRIGGER);
            return itemList;
        }

        public List<string> GetRealTimeItemList()
        {
            List<string> itemList = new List<string>();
            itemList.Add(RUN);
            itemList.Add(REAL_SPEED);
            itemList.Add(ERROR);
            //itemList.Add(CIRCLE_NUMBER);
            itemList.Add(STATUS);      
            itemList.Add(TRIGGER);
            return itemList;        
        }
    }
}
