using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OPCCommunication;
using System.Windows.Forms;

using ReaderDLL;
using System.Collections.Concurrent;
using System.Configuration;
using System.Globalization;
using CUHFReaderNameSpace;

namespace WindowsFormsApp3
{
    public partial class MainForm : Form
    {
        private OPCAPI opc = new OPCAPI();
        UHFReader CardReader = new UHFReader();

        ConcurrentDictionary<string, List<int>> bindingDictionary = new ConcurrentDictionary<string, List<int>>();
        System.Timers.Timer sort1Timer = new System.Timers.Timer();
        System.Timers.Timer sort2Timer = new System.Timers.Timer();
        System.Timers.Timer sort3Timer = new System.Timers.Timer();

        Dictionary<int, int> entryReader = new Dictionary<int, int>();

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            bindListView.FullRowSelect = true;
            logListView.FullRowSelect = false;


            sort1Timer.Interval = 30;
            sort1Timer.Elapsed += new System.Timers.ElapsedEventHandler((s, ev) => sort(s, ev, 1));

            sort2Timer.Interval = 30;
            sort2Timer.Elapsed += new System.Timers.ElapsedEventHandler((s, ev) => sort(s, ev, 2));

            sort3Timer.Interval = 30;
            sort3Timer.Elapsed += new System.Timers.ElapsedEventHandler((s, ev) => sort(s, ev, 3));

        }

        private void startDressLineBtn_Click(object sender, EventArgs e)
        {
            //打开服装线上的三个读写器，并启动三个线程进行监控
            
            try
            {
                int dressLineFre = Convert.ToInt32(dressLineFreTextBox.Text);
                entryReader.Add(1, CUHFReader.open_port(Convert.ToInt32(GetAppConfig("sort1Port"))));
                entryReader.Add(2, CUHFReader.open_port(Convert.ToInt32(GetAppConfig("sort2Port"))));
                entryReader.Add(3, CUHFReader.open_port(Convert.ToInt32(GetAppConfig("sort3Port"))));
                logListView.Items.Add(new ListViewItem("Readers Running..."));
                sort1Timer.Enabled = true;
                sort2Timer.Enabled = true;
                sort3Timer.Enabled = true;
                startDressLineBtn.Enabled = false;
                stopDressLineBtn.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("请输入正确的频率值", "Warning");
                Console.WriteLine(exception);
                return;
            }
            //todo 打开读写器

            //连接opc
            /*
            if (opc.OPCConect())
            {
                opc.SetGroup();
                // todo 启动机器
                opc.SetItems(new Item_ChangZhou());
                opc.ItemDataChange += new OPCAPI.ItemDataChangeEventHandler(DataChange);
                logListView.Items.Add(new ListViewItem("Readers Running..."));
                sort1Timer.Enabled = true;
                sort2Timer.Enabled = true;
                sort3Timer.Enabled = true;
                startDressLineBtn.Enabled = false;
                stopDressLineBtn.Enabled = true;
            }
            else
            {
                logListView.Items.Add(DateTime.Now + " opc connect fail " + "\n");
            }*/
            


        }

        private void stopDressLineBtn_Click(object sender, EventArgs e)
        {
            
            //关闭读写器和线程
            if (MessageBox.Show("停止运行?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sort1Timer.Stop();
                sort2Timer.Stop();
                sort3Timer.Stop();
                entryReader.Clear();
                logListView.Items.Add(new ListViewItem("Readers Stop..."));
                startDressLineBtn.Enabled = true;
                stopDressLineBtn.Enabled = false;
                //断开opc连接
                //todo 停止机器
                //opc.ItemDataChange -= new OPCAPI.ItemDataChangeEventHandler(DataChange);
                //opc.OPCDisConnect();
                logListView.Items.Add(DateTime.Now + "opc disconnected" + "\n");
                // todo关闭读写器
            }


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
            //
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
            //清空checkbox
            for (int j = 0; j < bindCheckedListBox.Items.Count; j++)
                bindCheckedListBox.SetItemChecked(j, false);
            selectAllCheckBox.Checked = false;
        }

        //全选
        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked)
            {
                for (int j = 0; j < bindCheckedListBox.Items.Count; j++)
                    bindCheckedListBox.SetItemChecked(j, true);
            }
            else
            {
                for (int j = 0; j < bindCheckedListBox.Items.Count; j++)
                    bindCheckedListBox.SetItemChecked(j, false);
            }
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

        private void bindListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            //todo打开读写器，读取标签epc并显示到epc
            //打开
            
            string epc = CardReader.readEPC();
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
                    break;
            }
            epc = epc.ToUpper();
            //string epc = "100";
            tagTextBox.Text = epc;

        }


        //用于监控各分拣口
        private void sort(object sender, System.Timers.ElapsedEventArgs e, int entryNum)
        {
            //根据各分拣口上的读写器，获取当前读取的衣架上的epc号
            //todo 读取标签
            string epc = CUHFReader.read_com(entryReader[entryNum]);
            /*
            if (epc != null)
            {
                this.BeginInvoke(method: new Action(() =>
                {
                    ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:MM:ss:fff", DateTimeFormatInfo.InvariantInfo) +":分拣口" + entryNum + "读到" + epc);
                    logListView.Items.Add(item);
                }));
            }*/
        
            if (epc != null)
            { 
                if (!bindingDictionary.ContainsKey(epc))
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:MM:ss:fff", DateTimeFormatInfo.InvariantInfo)+"在分拣口" + entryNum + "检测到 #" + epc + "未绑定！");
                    return;
                }
                List<int> entries = bindingDictionary[epc];
                if (entries.Contains(entryNum))
                {// 进行分拣
                 //todo操作硬件


                    //更新绑定和界面
                    entries.Remove(entryNum);
                    string sortingEntries = listToString(entries);

                    this.BeginInvoke(method: new Action(() =>
                    {
                        ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:MM:ss:fff  ", DateTimeFormatInfo.InvariantInfo) + "#" + epc + "在分拣口" + entryNum + "进行分拣");
                        logListView.Items.Add(item);
                        foreach (ListViewItem ite in bindListView.Items)
                        {
                            if (ite.SubItems[0].Text == epc)
                            {
                                ite.SubItems[1].Text = sortingEntries;
                                if(sortingEntries.Length == 0)
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
        }

        //清除日志
        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            logListView.Items.Clear();
        }

        //helper
        private string listToString(List<int> entries)
        {
            string sortingEntries = "";
            foreach (int i in entries)
            {
                sortingEntries += i + ",";
            }
            if (sortingEntries.Length > 0)
            {
                sortingEntries = sortingEntries.Substring(0, sortingEntries.Length - 1);
            }
            return sortingEntries;
        }

        private void clearAllBindingBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空所有绑定吗？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindingDictionary.Clear();
                bindListView.Items.Clear();
            }
        }

        private void DataChange(Dictionary<string, object> itemValues)
        {
            /*
            foreach (string itemName in itemValues.Keys)
            {
                switch (itemName)
                {
                    case :
                        {

                        }
                }
                */

            //
        }

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

    }
}
