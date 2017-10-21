using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCCommunication
{
    public class Item_SJTUDress : IOPCItem
    {
        public const string START = "Microwin.SJTU_Dress.Start";//启动
        public const string STOP = "Microwin.SJTU_Dress.Stop";//停止
        public const string RUN = "Microwin.SJTU_Dress.Run";//运行状态
        public const string SPEED = "Microwin.SJTU_Dress.Speed";//实际速度 15-30赋值
        public const string ERROR = "Microwin.SJTU_Dress.Error";//故障状态
        public const string EM = "Microwin.SJTU_Dress.Em";//紧急停止状态
        public const string SORT_1 = "Microwin.SJTU_Dress.Sort_1";//分拣1
        public const string SORT_2 = "Microwin.SJTU_Dress.Sort_2";//分拣2
        public const string SORT_3 = "Microwin.SJTU_Dress.Sort_3";//分拣3
        public const string TRIGGER_1 = "Microwin.SJTU_Dress.Trigger_1";//光电检测
        public const string TRIGGER_2 = "Microwin.SJTU_Dress.Trigger_2";//光电检测
        public const string TRIGGER_3 = "Microwin.SJTU_Dress.Trigger_3";//光电检测
        public const string TIME_1 = "Microwin.SJTU_Dress.Time_1";//分拣时间 40-75百毫秒
        public const string TIME_2 = "Microwin.SJTU_Dress.Time_2";//分拣时间 
        public const string TIME_3 = "Microwin.SJTU_Dress.Time_3";//分拣时间
        public const string PUSH_1 = "Microwin.SJTU_Dress.Push_1";//工位拍打按钮1
        public const string PUSH_2 = "Microwin.SJTU_Dress.Push_2";//工位拍打按钮2
        public const string PUSH_3 = "Microwin.SJTU_Dress.Push_3";//工位拍打按钮3
        public List<string> GetItemList()
        {
            List<string> itemList = new List<string>();
            itemList.Add(START);
            itemList.Add(STOP);
            itemList.Add(RUN);
            itemList.Add(SPEED);
            itemList.Add(ERROR);
            itemList.Add(EM);
            itemList.Add(SORT_1);
            itemList.Add(SORT_2);
            itemList.Add(SORT_3);
            itemList.Add(TRIGGER_1);
            itemList.Add(TRIGGER_2);
            itemList.Add(TRIGGER_3);
            itemList.Add(TIME_1);
            itemList.Add(TIME_2);
            itemList.Add(TIME_3);
            itemList.Add(PUSH_1);
            itemList.Add(PUSH_2);
            itemList.Add(PUSH_3);

            return itemList;
        }

        public List<string> GetRealTimeItemList()
        {
            List<string> itemList = new List<string>();
            itemList.Add(START);
            itemList.Add(STOP);
            itemList.Add(RUN);
            itemList.Add(SPEED);
            itemList.Add(ERROR);
            itemList.Add(EM);
            itemList.Add(SORT_1);
            itemList.Add(SORT_2);
            itemList.Add(SORT_3);
            itemList.Add(TRIGGER_1);
            itemList.Add(TRIGGER_2);
            itemList.Add(TRIGGER_3);
            itemList.Add(TIME_1);
            itemList.Add(TIME_2);
            itemList.Add(TIME_3);
            itemList.Add(PUSH_1);
            itemList.Add(PUSH_2);
            itemList.Add(PUSH_3);
            return itemList;
        }
    }
}
