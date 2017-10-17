using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCCommunication
{
    public class Item_Simulation : IOPCItem
    {
        public const string RUN = "Bucket Brigade.Boolean";//起停状态
        public const string SET_SPEED = "Bucket Brigade.Real4";
        public const string REAL_SPEED = "Random.Real4";
        public const string TRIGGER = "Random.Boolean";

        public List<string> GetItemList()
        {
            List<string> itemList = new List<string>();
            itemList.Add(RUN);
            itemList.Add(SET_SPEED);
            itemList.Add(REAL_SPEED);
            itemList.Add(TRIGGER);
            return itemList;
        }

        public List<string> GetRealTimeItemList()
        {
            List<string> itemList = new List<string>();
            itemList.Add(RUN);
            itemList.Add(REAL_SPEED);
            itemList.Add(TRIGGER);
            return itemList;
        }

    }
}
