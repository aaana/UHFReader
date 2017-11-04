using OPCCommunication;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class MainForm : Form
    {
        private OPCAPI opc = new OPCAPI();

        //scan读写器
        //UHFReader CardReader = new UHFReader(GetAppConfig("ReaderComScan"),Convert.ToInt32(GetAppConfig("ReadTxPowerScan")));

        //分拣口读写器
        UHFReader sort1Reader;
        UHFReader sort2Reader;
        UHFReader sort3Reader;

        //控制挡板
        private static int DOWN = 1;
        private static int UP = 0;

        //分拣口号
        private static int SORT1 = 1;
        private static int SORT2 = 2;
        private static int SORT3 = 3;

        //用于记录上次触发光电的时间
        long lastTriggerTime1 = 0;
        long lastTriggerTime2 = 0;
        long lastTriggerTime3 = 0;

        //用于记录epc及其绑定的分拣口
        ConcurrentDictionary<string, List<int>> bindingDictionary = new ConcurrentDictionary<string, List<int>>();


        public MainForm()
        {
            InitializeComponent();
        }

        public void addBinding(string epc,List<int> sortEntriesList)
        {
            bindingDictionary[epc] = sortEntriesList;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            bindListView.FullRowSelect = true;
            logListView.FullRowSelect = false;
            //bindingDictionary.TryAdd("E2004106210E005117306119", new List<int>() {1,2,3 });
            //bindingDictionary.TryAdd("E2004106210E005118205882", new List<int>() { 1, 2, 3 });
            //bindingDictionary.TryAdd("E2004106210E00511710625F", new List<int>() { 1, 2, 3 });
            //bindingDictionary.TryAdd("E2004106210E005118505129", new List<int>() { 1, 2, 3 });
            //bindingDictionary.TryAdd("E2004106210E00511750611B", new List<int>() { 1, 2, 3 });
            //bindingDictionary.TryAdd("E2004106210E0051168069CC", new List<int>() { 1, 2, 3 });


        }


        private void startDressLineBtn_Click(object sender, EventArgs e)
        {
            //打开服装线上的三个读写器，并启动三个线程进行监控

            try
            {
                //int dressLineFre = Convert.ToInt32(dressLineFreTextBox.Text);
                sort1Reader = new UHFReader(GetAppConfig("ReaderComSort1"), Convert.ToInt32(GetAppConfig("ReadTxPowerSort1")));
                sort2Reader = new UHFReader(GetAppConfig("ReaderComSort2"), Convert.ToInt32(GetAppConfig("ReadTxPowerSort2")));
                sort3Reader = new UHFReader(GetAppConfig("ReaderComSort3"), Convert.ToInt32(GetAppConfig("ReadTxPowerSort3")));
                logListView.Items.Add(new ListViewItem(DateTime.Now + " Readers Running..."));


                startDressLineBtn.Enabled = false;
                stopDressLineBtn.Enabled = true;
            }
            catch (Exception exception)
            {
                //MessageBox.Show("请输入正确的频率值", "Warning");
                Console.WriteLine(exception);
                logListView.Items.Add(DateTime.Now + " Readers connect fail " + "\n");
                return;
            }
            //todo 打开读写器

            //连接opc

            if (opc.OPCConect())
            {
                opc.SetGroup();
                // todo 启动机器
                opc.SetItems(new Item_SJTUDress());
                opc.ItemDataChange += new OPCAPI.ItemDataChangeEventHandler(DataChange);
                logListView.Items.Add(new ListViewItem(DateTime.Now + " opc connected"));


            }
            else
            {
                logListView.Items.Add(DateTime.Now + " opc connect fail " + "\n");
                MessageBox.Show("opc连接失败", "Warning");
                return;
            }

        }

        private void stopDressLineBtn_Click(object sender, EventArgs e)
        {

            //关闭读写器和线程
            if (MessageBox.Show("停止运行?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
;
                startDressLineBtn.Enabled = true;
                stopDressLineBtn.Enabled = false;
                //断开opc连接
                //todo 停止机器
                opc.ItemDataChange -= new OPCAPI.ItemDataChangeEventHandler(DataChange);
                opc.OPCDisConnect();
                logListView.Items.Add(DateTime.Now + " opc disconnected" + "\n");
                // todo关闭读写器
                stopReaders();
                logListView.Items.Add(DateTime.Now + " Readers stop" + "\n");

            }


        }
        /// <summary>
        /// 
        /// </summary>
        private void stopReaders()
        {
            sort1Reader.disConnect();
            sort2Reader.disConnect();
            sort3Reader.disConnect();

        }

        //绑定epc和分拣口
        private void bindBtn_Click(object sender, EventArgs e)
        {
            string epc = tagTextBox.Text;
            if (epc == "")
            {
                Console.WriteLine("未检测到服装");
                MessageBox.Show("未检测到服装", "Warning");
                return;
            }
            if (bindingDictionary.ContainsKey(epc))
            {
                Console.WriteLine("该服装已绑定");
                MessageBox.Show("该服装已绑定", "Warning");
                return;
            }
            if (!checkEPC(epc))
            {
                Console.WriteLine("EPC格式不正确");
                MessageBox.Show("EPC格式不正确","Warning");
                return;
            }
            new BindingForm(this, epc).ShowDialog();
            if (bindingDictionary.ContainsKey(epc))
            {
                ListViewItem item = new ListViewItem(epc);
                item.SubItems.Add(Utils.listToString(bindingDictionary[epc]));
                bindListView.Items.Add(item);
            }
            
            /*      
       List<int> entries = new List<int>();
       string sortingEntries = "";

       for (int i = 0; i < bindCheckedListBox.Items.Count; i++)
       {
           if (bindCheckedListBox.GetItemChecked(i))
           {
               entries.Add(i + 1);
               sortingEntries = sortingEntries + (i + 1) + ",";
           }

       }
       if (sortingEntries.Length > 0)
       {
           sortingEntries = sortingEntries.Substring(0, sortingEntries.Length - 1);
       }
       else
       {
           Console.WriteLine("请选择分拣口");
           MessageBox.Show("请选择分拣口", "Warning");
           return;
       }
       if (MessageBox.Show("确认绑定#" + epc + "\n到" + sortingEntries + "分拣口吗？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
       {
           bindingDictionary[epc] = entries;
           ListViewItem item = new ListViewItem(epc);
           item.SubItems.Add(sortingEntries);
           bindListView.Items.Add(item);
       }
       /*
       //清空checkbox
       for (int j = 0; j < bindCheckedListBox.Items.Count; j++)
           bindCheckedListBox.SetItemChecked(j, false);
       selectAllCheckBox.Checked = false;*/

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="epc"></param>
        /// <returns></returns>
        private bool checkEPC(string epc)
        {
            string pattern = @"[0-9A-F]{24}";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(epc);
        }


        //清除绑定
        private void clearBindBtn_Click(object sender, EventArgs e)
        {
            if (bindListView.SelectedItems.Count > 0)
            {
                List<string> deletedEpcs = new List<string>();
                string deletedEpcsStr = "";
                for (int i = 0; i < bindListView.SelectedItems.Count; i++)
                {
                    string selectedEpc = bindListView.SelectedItems[i].SubItems[0].Text;
                    if (!deletedEpcs.Contains(selectedEpc))
                    {
                        deletedEpcs.Add(selectedEpc);
                        deletedEpcsStr += selectedEpc + ",";
                    }

                }
                deletedEpcsStr = deletedEpcsStr.Substring(0, deletedEpcsStr.Length - 1);
                if (MessageBox.Show("确定清除绑定#" + deletedEpcsStr + "吗？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Console.WriteLine(deletedEpcsStr);
                    foreach (string epc in deletedEpcs)
                    {
                        List<int> list = null;
                        while (!bindingDictionary.TryRemove(epc, out list))
                        {
                        };
                        foreach (ListViewItem item in bindListView.Items)
                        {
                            if (item.SubItems[0].Text == epc)
                            {
                                item.Remove();
                            }
                        }
                    }

                    //bindListView.SelectedItems[0].Remove();
                    //bindListView.Items.Remove(bindListView.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("请选中一件服装");
            }
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            //打开
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo));

            string epc = "00000000000000000000000A";// = CardReader.readEPC();

                switch (epc)
                {
                    case "OpFaidedException":
                        MessageBox.Show("Option failed", "错误");
                        return;
                    case "ModuleException":
                        MessageBox.Show("Module Exception", "错误");
                        return;
                    case "success":
                        MessageBox.Show("写卡成功", "");
                        break;
                    default:
                        Console.WriteLine(epc);
                        break;
                }
                epc = epc.ToUpper();
                tagTextBox.Text = epc;
              
            
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo));
        }


        /// <summary>
        /// 检查epc在entryNum是否需要分拣
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="entryNum"></param>
        /// <returns>-2=>未读到 
        /// -1=>未绑定
        /// -3 =>分拣结束
        /// 1=>分拣
        /// 0=>不分拣</returns>
        private int checkSort(string epc, int entryNum)
        {
            if (epc.Length == 0)
                return -2;
            if (!bindingDictionary.ContainsKey(epc))
            {
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "未绑定！");
                return -1;
            }
            List<int> entries = bindingDictionary[epc];
            if (bindingDictionary[epc].Count <= 0)
            {
                Console.WriteLine("分拣结束");
                return -3;
            }
            if (bindingDictionary[epc][0] ==entryNum)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //发送opc
        private void writeSortOpc(int sortEntry, int sort)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            switch (sortEntry)
            {
                case 1:
                    {
                        dic.Add(Item_SJTUDress.SORT_1, sort);
                        break;
                    }
                case 2:
                    {
                        dic.Add(Item_SJTUDress.SORT_2, sort);
                        break;
                    }
                case 3:
                    {
                        dic.Add(Item_SJTUDress.SORT_3, sort);
                        break;
                    }
                default:
                    break;
            }

            opc.WriteAsynchronous(dic);
        }
       
        //进行分拣 操作硬件、更新绑定Dictionary、更新界面
        private void doSort(string epc, int entryNum)
        {
            writeSortOpc(entryNum, DOWN);
            Thread.Sleep(30);
            writeSortOpc(entryNum, UP);
            List<int> entries = bindingDictionary[epc];
            entries.Remove(entryNum);
            string sortingEntries = Utils.listToString(entries);
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff  ", DateTimeFormatInfo.InvariantInfo) + "#" + epc + "在分拣口" + entryNum + "进行分拣");

            this.BeginInvoke(method: new Action(() =>
            {
                ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss:fff  ", DateTimeFormatInfo.InvariantInfo) + "#" + epc + "在分拣口" + entryNum + "进行分拣");
                logListView.Items.Add(item);
                foreach (ListViewItem ite in bindListView.Items)
                {
                    if (ite.SubItems[0].Text == epc)
                    {
                        ite.SubItems[1].Text = sortingEntries;
                        if (sortingEntries.Length == 0)
                        {
                            ite.Remove();
                        }
                    }
                }

            }));
        }
        
        //清除日志
        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            logListView.Items.Clear();
        }


        private void clearAllBindingBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空所有绑定吗？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindingDictionary.Clear();
                bindListView.Items.Clear();
            }
        }

        //检测opc事件
        private void DataChange(Dictionary<string, object> itemValues)
        {
            
            foreach (string itemName in itemValues.Keys)
            {                
                switch (itemName)
                {
                    
                    case Item_SJTUDress.TRIGGER_1:
                        {
                            if (Convert.ToInt16( itemValues[itemName] )== 0)
                                break;
                            Console.WriteLine("triger1");
                            long currentTime = CurrentMillis.MicroSeconds;
                            //防止连续两次触发光电
                            if(currentTime - lastTriggerTime1 > 2000)
                            {
                                Console.WriteLine("thread starts");
                                Thread sort1Thread = new Thread(new ParameterizedThreadStart(sortThreadFunc));
                                sort1Thread.Start(SORT1);
                            }
                            lastTriggerTime1 = currentTime;
                            break;
                        }
                    case Item_SJTUDress.TRIGGER_2:
                        {
                            if (Convert.ToInt16(itemValues[itemName]) == 0)
                                break;
                            Console.WriteLine("triger2");
                            long currentTime = CurrentMillis.MicroSeconds;
                            if(currentTime - lastTriggerTime2 > 2000)
                            {
                                Console.WriteLine("thread starts");
                                Thread sort2Thread = new Thread(new ParameterizedThreadStart(sortThreadFunc));
                                sort2Thread.Start(SORT2);
                            }
                            lastTriggerTime2 = currentTime;
                            break;
                        }
                    case Item_SJTUDress.TRIGGER_3:
                        {
                            if (Convert.ToInt16(itemValues[itemName]) == 0)
                                break;
                            Console.WriteLine("triger3");
                            long currentTime = CurrentMillis.MicroSeconds;
                            if (currentTime - lastTriggerTime3 > 2000)
                            {
                                Console.WriteLine("thread starts");
                                Thread sort3Thread = new Thread(new ParameterizedThreadStart(sortThreadFunc));
                                sort3Thread.Start(SORT3);
                            }
                            lastTriggerTime3 = currentTime;
                            break;
                            
                        }
                }
            }


            //
        }

        //检测到光电信号后执行的线程
        private void sortThreadFunc(object entryNum)
        {           
            string epc = "";
           
            switch ((int)entryNum)
            {
                case 1:                
                    epc = sort1Reader.readEPC();                   
                    break;
                case 2:                   
                    epc = sort2Reader.readEPC();
                    break;
                case 3:
                    epc = sort3Reader.readEPC();
                    break;
                default:
                    break;
            }
            switch (checkSort(epc, (int)entryNum))
            {
                case 1:
                    try
                    {
                        doSort(epc, (int)entryNum);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e + "in sortThread" + entryNum);
                    }
                    
                    break;
                case -1:
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "未绑定！");
                    this.BeginInvoke(
                        method: new Action(() =>
                        {
                            ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss:fff  ", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "未绑定！");
                            logListView.Items.Add(item);
                        }));
                    break;
                case 0:
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "不分拣");
                    this.BeginInvoke(
                        method: new Action(() =>
                        {
                            ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss:fff  ", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "不分拣");
                            logListView.Items.Add(item);
                        }));
                    break;
                default:
                    break;
            }
        }

        //获得配置
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        /* For test
        private void button1_Click(object sender, EventArgs e)
        {

            if (opc.OPCConect())
            {
                opc.SetGroup();
                // todo 启动机器
                opc.SetItems(new Item_SJTUDress());
                opc.ItemDataChange += new OPCAPI.ItemDataChangeEventHandler(DataChange);
                logListView.Items.Add(new ListViewItem(DateTime.Now + " opc connected"));
                /*
                doSort(3, 1);
                Thread.Sleep(30);
                doSort(3, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(testSort1));
            Thread thread2 = new Thread(new ThreadStart(testSort2));
            thread1.Start();
            thread2.Start();
        }
        private void testSort1()
        {
            for(int i = 0; i < 5; i++)
            {
                writeSortOpc(1, 1);
                Thread.Sleep(30);
                writeSortOpc(1, 0);
                Thread.Sleep(5000);
            }
            
        }

        private void testSort2()
        {
            for(int j = 0; j < 6; j++)
            {
                writeSortOpc(2, 1);
                Thread.Sleep(30);
                writeSortOpc(2, 0);
                Thread.Sleep(5000);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sort1Reader = new UHFReader(GetAppConfig("ReaderComSort1"), Convert.ToInt32(GetAppConfig("ReadTxPowerSort1")));
            sort2Reader = new UHFReader(GetAppConfig("ReaderComSort2"), Convert.ToInt32(GetAppConfig("ReadTxPowerSort2")));
            //sort3Reader = new UHFReader(GetAppConfig("ReaderComSort3"), Convert.ToInt32(GetAppConfig("ReadTxPowerSort3")));
            Thread thread1 = new Thread(new ParameterizedThreadStart(read));
            Thread thread2 = new Thread(new ParameterizedThreadStart(read));
            //Thread thread3 = new Thread(new ParameterizedThreadStart(read));
            thread1.Start(1);
            thread2.Start(2);
            //thread3.Start(3);
        }

        private void read(object num)
        {
            string epc = "";
            switch ((int)num)
            {
                case 1:
                    while ((epc = sort1Reader.readEPC()).Length == 0)
                    {

                    }
                    break;
                case 2:
                    while ((epc = sort2Reader.readEPC()).Length == 0)
                    {

                    }
                    break;

                case 3:
                    while ((epc = sort3Reader.readEPC()).Length == 0)
                    {

                    }
                    break;
                default:break;

            }
            this.BeginInvoke(method: new Action(() =>
            {
                ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss:fff  ", DateTimeFormatInfo.InvariantInfo)+ num+ "读到" + "#" + epc );
                logListView.Items.Add(item);
            }));
                

        }

        //用于监控各分拣口
        private void sort(object sender, System.Timers.ElapsedEventArgs e, int entryNum)
        {
            //根据各分拣口上的读写器，获取当前读取的衣架上的epc号
            //todo 读取标签
            long start = DateTime.Now.Ticks;
            string epc = "";
            //string epc = CUHFReader.read_com(entryReader[entryNum]);
            switch (entryNum)
            {
                case 1:
                    epc = sort1Reader.readEPC();
                    break;
                case 2:
                    epc = sort2Reader.readEPC();
                    break;
                case 3:
                    epc = sort3Reader.readEPC();
                    break;
                default:
                    break;
            }
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + " 线程" + entryNum + "运行");
            if (epc.Length != 0)
            {
                this.BeginInvoke(method: new Action(() =>
                {
                    ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + ":分拣口" + entryNum + "读到" + epc);
                    logListView.Items.Add(item);
                }));
                switch (checkSort(epc, (int)entryNum))
                {
                    case 1:
                        doSort(epc, (int)entryNum);
                        break;
                    case -1:
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "未绑定！");
                        break;
                    case 0:
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "不分拣");
                        break;
                    default:
                        break;
                }
            }


            
            if (epc.Length!=0)
            {

             
                if (!bindingDictionary.ContainsKey(epc))
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff", DateTimeFormatInfo.InvariantInfo) + "在分拣口" + entryNum + "检测到 #" + epc + "未绑定！");

                    return;
                }
                List<int> entries = bindingDictionary[epc];
                if (entries.Contains(entryNum))
                {// 进行分拣
                 //todo操作硬件
                 
                    writeSortOpc(entryNum, 1);
                    //Thread.Sleep(10);
                    writeSortOpc(entryNum, 0);

                    //更新绑定和界面
                    entries.Remove(entryNum);
                    string sortingEntries = listToString(entries);

                    this.BeginInvoke(method: new Action(() =>
                    {
                        ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss:fff  ", DateTimeFormatInfo.InvariantInfo) + "#" + epc + "在分拣口" + entryNum + "进行分拣");
                        logListView.Items.Add(item);
                        foreach (ListViewItem ite in bindListView.Items)
                        {
                            if (ite.SubItems[0].Text == epc)
                            {
                                ite.SubItems[1].Text = sortingEntries;
                                if (sortingEntries.Length == 0)
                                {
                                    ite.Remove();
                                }
                            }
                        }

                    }));
                    // todo 检测到已下落后将挡板恢复原位 探头的事件？？？

                }
                else
                {//不进行分拣

                }
            }
            long end = DateTime.Now.Ticks;
            Console.WriteLine("time execute time " + (end - start));
        }*/
    }
}
