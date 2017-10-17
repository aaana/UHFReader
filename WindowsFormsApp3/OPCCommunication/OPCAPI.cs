using Opc.Da;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OPCCommunication
{
    public class OPCAPI
    {
       
        public const string RUN = "Microwin.NewPLC.group.run";//起停状态
        public const string SET_SPEED = "Microwin.NewPLC.group.speed";//速度设置
        public const string REAL_SPEED = "Microwin.NewPLC.group.realspeed";//实际速度
        public const string ERROR = "Microwin.NewPLC.group.error";//故障状态
        public const string CIRCLE_NUMBER = "Microwin.NewPLC.group.circle";//圈数
        public const string EMERGENCY_STOP = "Microwin.NewPLC.group.stop";//紧急停止状态
        public const string SORT = "Microwin.NewPLC.group.sort";//分拣
        public const string TRIGGER = "Microwin.NewPLC.group.trigger";//光电检测
        //public const string ITEM_1= "Microwin.NewPLC.group.VD96";
        //public const string ITEM_2 = "Microwin.NewPLC.group.VD50";
        //public const string ITEM_3 = "Microwin.NewPLC.group.I3";
        //public const string ITEM_4 = "Microwin.NewPLC.group.M15";
        //public const string ITEM_2 = "Bucket Brigade.Int2";
        //public const string ITEM_3 = "Bucket Brigade.Int4";
        //public const string ITEM_4 = "Bucket Brigade.String";
        //public const string ITEM_5 = "Random.Int1";



        public delegate void ItemDataChangeEventHandler(Dictionary<string, object> itemsDic);
        public event ItemDataChangeEventHandler ItemDataChange;

        public delegate void ItemReadCompleteEventHandler(Dictionary<string, object> itemDic);
        public event ItemReadCompleteEventHandler ItemReadComplete;


        private OPCControl ctrl;
        private List<string> opcItemList;

        public OPCAPI()
        {
            ctrl = new OPCControl();
            opcItemList=new List<string>();
            
        }

        public bool OPCConect()
        {
           return ctrl.Conect(ConfigurationManager.AppSettings["Host"], ConfigurationManager.AppSettings["ServerName"]);
        }

        public void OPCDisConnect()
        {
            ctrl.OPCDataChange -= new OPCControl.OPCDataChangeEventHandler(DataChange);
            ctrl.OPCReadComplete -= new OPCControl.OPCReadCompleteEventHandler(RingItemReadComplete);
            ctrl.Disconect();
        }

        public void SetGroup()
        {
            ctrl.SetGroup();
        }

        public void SetItems(IOPCItem items)
        {
            //ctrl.SetItems(new string[] { ITEM_1, ITEM_2, ITEM_3, ITEM_4, ITEM_5 });
           // ctrl.SetItems(new string[] { ITEM_1,ITEM_2,ITEM_3,ITEM_4});
            ctrl.SetItems(items.GetItemList().ToArray());
            ctrl.OPCDataChange += new OPCControl.OPCDataChangeEventHandler(DataChange);
            ctrl.OPCReadComplete += new OPCControl.OPCReadCompleteEventHandler(RingItemReadComplete);
        }

        public void SetItems(string[] items)
        {
            ctrl.SetItems(items);
            ctrl.OPCDataChange += new OPCControl.OPCDataChangeEventHandler(DataChange);
            ctrl.OPCReadComplete += new OPCControl.OPCReadCompleteEventHandler(RingItemReadComplete);
        }

        public Dictionary<string, object> ReadSynchronization(List<string> itemNameList)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            ItemValueResult[] itemValueResultArray = ctrl.ReadSynchronization(itemNameList);
            foreach (ItemValueResult result in itemValueResultArray)
            {
                dic.Add(result.ItemName, result.Value);
            }
            return dic;
        }

        public Dictionary<string, object> ReadAllSynchronization()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            ItemValueResult[] itemValueResultArray = ctrl.ReadAllSynchronization();
            foreach (ItemValueResult result in itemValueResultArray)
            {
                dic.Add(result.ItemName, result.Value);
            }
            return dic;
        }

        public void WriteSynchronization(Dictionary<string, object> itemDic)
        {
            ctrl.WriteSynchronization(itemDic);
        }

        public void WriteAsynchronous(Dictionary<string, object> itemDic)
        {
            ctrl.WriteAsynchronous(itemDic);
        }

        public void ReadAsynchronous(List<string> itemNameList)
        {
            ctrl.ReadAsynchronous(itemNameList);
        }
        
        public void DataChange(Dictionary<string, object> dic)
        {
            //Dictionary<string, object> filterDic = new Dictionary<string, object>();
           // filterDic.Add(ITEM_5,dic[ITEM_5]);
            //filterDic.Add(ITEM_1, dic[ITEM_1]);
            //ItemDataChange(filterDic);
            ItemDataChange(dic);
        }

        public void RingItemReadComplete(Dictionary<string, object> dic)
        {
            ItemReadComplete(dic);
        }



    }
}
