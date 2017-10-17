using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc;
using Opc.Da;
using OpcCom;


namespace OPCCommunication
{
    public class OPCControl
    {

        //定义数据存取服务器
        private Opc.Da.Server m_server = null;
        //定义组对象（订阅者）
        private Opc.Da.Subscription subscription = null;
        //定义组（订阅者）状态，相当于OPC规范中组的参数
        private Opc.Da.SubscriptionState state = null;
        //定义枚举基于COM服务器的接口，用来搜索所有的此类服务器。
        private Opc.IDiscovery m_discovery = new OpcCom.ServerEnumerator();
        //记录ITEM在组内的序号
        private Dictionary<string, int> itemIndexDic = new Dictionary<string, int>();
        //item数据变化监听事件
        public delegate void OPCDataChangeEventHandler(Dictionary<string, object> itemsDic);
        public event OPCDataChangeEventHandler OPCDataChange;
        //读取item监听事件
        public delegate void OPCReadCompleteEventHandler(Dictionary<string, object> itemsDic);
        public event OPCReadCompleteEventHandler OPCReadComplete;

        public void OnDataChange(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            //gaoxm
            foreach (ItemValueResult item in values)
            {
                if (!dic.Keys.Contains(item.ItemName))
                {
                    dic.Add(item.ItemName, item.Value);
                }
            }
            OPCDataChange(dic);
        }

        /// <summary>
        /// 搜索指定地址的所有OPC服务器， 
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <returns>可用的OPC服务器</returns>
        private Opc.Server[] SearchOPCServer(string url)
        {
            //Specification表示数据存取规范版本，Specification.COMDA_20等于2.0版本,null表示不需要任何网络安全认证。     
            return m_discovery.GetAvailableServers(Specification.COM_DA_20, url, null);
        }

        /// <summary>
        /// 连接OPC服务器
        /// </summary>
        /// <param name="host">地址</param>
        /// <param name="serverName">服务器名称</param>
        /// <returns>是否连接成功</returns>
        public bool Conect(string host, string serverName)
        {
            Opc.Server[] servers = m_discovery.GetAvailableServers(Specification.COM_DA_20, host, null);
            if (servers != null)
            {
                foreach (Opc.Da.Server server in servers)
                {
                    if (String.Compare(server.Name, serverName, true) == 0)
                    {
                        m_server = server;
                        break;
                    }
                }

                if (m_server != null)
                {
                    m_server.Connect();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 断开与OPC服务连接，并释放资源
        /// </summary>
        public void Disconect()
        {
            itemIndexDic.Clear();
            //移除组内item
            subscription.RemoveItems(subscription.Items);
            //通知服务器要求删除组。  
            m_server.CancelSubscription(subscription);
            subscription.Dispose();
            m_server.Disconnect();
        }

        /// <summary>
        /// 设定组（订阅者）状态
        /// </summary>
        public void SetGroup()
        {
            state = new Opc.Da.SubscriptionState();
            //组名
            state.Name = "IOTPLC";
            //服务器给该组分配的句柄。
            state.ServerHandle = null;
            //客户端给该组分配的句柄。
            state.ClientHandle = Guid.NewGuid().ToString();
            //激活该组。
            state.Active = true;
            //刷新频率为1秒。
            state.UpdateRate = 100;
            // 死区值，设为0时，服务器端该组内任何数据变化都通知组。
            state.Deadband = 0;
            //不设置地区值。
            state.Locale = null;

            //添加组
            subscription = (Opc.Da.Subscription)m_server.CreateSubscription(state);
        }

        /// <summary>
        /// 设置绑定数据项（Item）
        /// </summary>
        /// <param name="itemTags"></param>
        public void SetItems(string[] itemTags)
        {
            Item[] items = new Item[itemTags.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item();
                //客户端给该数据项分配的句柄。
                items[i].ClientHandle = Guid.NewGuid().ToString();
                //该数据项在服务器中的路径。
                items[i].ItemPath = null;
                //该数据项在服务器中的名字。
                items[i].ItemName = itemTags[i];
                //记录数据项对应的数组编号
                itemIndexDic.Add(items[i].ItemName, i);
            }
           ItemResult[] r= subscription.AddItems(items);
           Console.WriteLine(r.Length);
            Console.WriteLine(subscription.Items.Length.ToString() + "------count");
            addDataChangedListening();
        }

        /// <summary>
        /// 添加数据项内容变化监听
        /// </summary>
        public void addDataChangedListening()
        {
            subscription.DataChanged += new Opc.Da.DataChangedEventHandler(this.OnDataChange);
        }

        /// <summary>
        /// 移除数据项内容变化监听
        /// </summary>
        public void removeDateChangeListending()
        {
            subscription.DataChanged -= new Opc.Da.DataChangedEventHandler(this.OnDataChange);
        }

        /// <summary>
        /// 同步方式读取指定item名称的数据内容,不能有重名的数据项
        /// </summary>
        /// <param name="itemNameList">需要读取的数据项名称列表</param>
        /// <returns>ItemValueResult</returns>
        public ItemValueResult[] ReadSynchronization(List<string> itemNameList)
        {
            List<Item> itemList = new List<Item>();
            foreach (string itemName in itemNameList)
            {
                if (itemIndexDic.ContainsKey(itemName))
                {
                    itemList.Add(subscription.Items[itemIndexDic[itemName]]);
                }
            }
            return subscription.Read(itemList.ToArray());
        }

        /// <summary>
        /// 同步方式向指定item名称的数据项写入内容
        /// </summary>
        /// <param name="writeItemDataDic">写入的数据项Dictionary</param>
        public void WriteSynchronization(Dictionary<string, object> writeItemDataDic)
        {
            List<ItemValue> itemValueList = new List<ItemValue>();
            foreach (string itemName in writeItemDataDic.Keys)
            {
                if (itemIndexDic.ContainsKey(itemName))
                {
                    ItemValue item = new ItemValue((ItemIdentifier)subscription.Items[itemIndexDic[itemName]]);
                    item.Value = writeItemDataDic[itemName];
                    itemValueList.Add(item);
                }
            }
            subscription.Write(itemValueList.ToArray());
        }

        /// <summary>
        /// 同步方式读取全部数据项内容
        /// </summary>
        /// <returns></returns>
        public ItemValueResult[] ReadAllSynchronization()
        {
            return subscription.Read(subscription.Items);
        }

        /// <summary>
        /// 异步方式读取指定数据项（item）
        /// </summary>
        /// <param name="itemNameList">数据项名称列表</param>
        public void ReadAsynchronous(List<string> itemNameList)
        {

            List<Item> itemList = new List<Item>();
            foreach (string itemName in itemNameList)
            {
                
                if (itemIndexDic.ContainsKey(itemName))
                {
                    itemList.Add(subscription.Items[itemIndexDic[itemName]]);
                }
            }
            IRequest quest = null;
            subscription.Read(itemList.ToArray(), 1, this.OnReadComplete, out quest);
        }          

        /// <summary>
        /// 异步方式读取所有数据项
        /// </summary>
        /// <param name="items"></param>
        public void ReadAllAsynchronous()
        {
            IRequest quest = null;
            subscription.Read(subscription.Items, 1, this.OnReadComplete, out quest);
        }

        /// <summary>
        /// 异步方式向指定数据项写入数据
        /// </summary>
        /// <param name="writeItemDataDic">指定写入数据项的Dictionary</param>
        public void WriteAsynchronous(Dictionary<string, object> writeItemDataDic)
        {
            IRequest quest = null;
            List<ItemValue> itemValueList = new List<ItemValue>();
            foreach (string itemName in writeItemDataDic.Keys)
            {
                if (itemIndexDic.ContainsKey(itemName))
                {
                    ItemValue item = new ItemValue((ItemIdentifier)subscription.Items[itemIndexDic[itemName]]);
                    item.Value = writeItemDataDic[itemName];
                    itemValueList.Add(item);
                }
            }
            subscription.Write(itemValueList.ToArray(), 1, this.OnWriteComplete, out quest);
        }


        /*未实现*/
        //ReadComplete回调 
        public void OnReadComplete(object requestHandle, Opc.Da.ItemValueResult[] values)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
          
            foreach (ItemValueResult item in values)
            {
                if (!dic.Keys.Contains(item.ItemName))
                {
                    dic.Add(item.ItemName, item.Value);
                }
            }
            OPCReadComplete(dic);


            //Console.WriteLine("发生异步读name:{0},value:{1}", values[0].ItemName, values[0].Value);
            //if ((int)requestHandle == 1)
            //    Console.WriteLine("事件信号句柄为{0}", requestHandle);
        }

        //WriteComplete回调
        public void OnWriteComplete(object requestHandle, Opc.IdentifiedResult[] values)
        {
            /*Console.WriteLine("发生异步写name:{0},value:{1}", values[0].ItemName, values[0].GetType());
            if ((int)requestHandle == 2)
                Console.WriteLine("事件信号句柄为{0}", requestHandle);*/
        }

    }
}
