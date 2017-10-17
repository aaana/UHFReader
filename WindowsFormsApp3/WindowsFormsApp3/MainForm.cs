using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class MainForm : Form
    {
        Dictionary<string, List<int>> bindingDictionary = new Dictionary<string, List<int>>();
        bool scanReaderStatus = false;
        System.Timers.Timer scanTimer = new System.Timers.Timer();
        System.Timers.Timer sort1Timer = new System.Timers.Timer();
        System.Timers.Timer sort2Timer = new System.Timers.Timer();
        System.Timers.Timer sort3Timer = new System.Timers.Timer();

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            bindListView.FullRowSelect = true;
            logListView.FullRowSelect = false;
            scanTimer.Interval = 20;
            scanTimer.Elapsed += new System.Timers.ElapsedEventHandler(readTag);

            sort1Timer.Interval = 20;
            sort1Timer.Elapsed += new System.Timers.ElapsedEventHandler((s,ev)=>sort(s,ev,1));

            sort2Timer.Interval = 20;
            sort2Timer.Elapsed += new System.Timers.ElapsedEventHandler((s,ev) => sort(s,ev,2));

            sort3Timer.Interval = 20;
            sort3Timer.Elapsed += new System.Timers.ElapsedEventHandler((s,ev) => sort(s,ev,3));

        }

        private void startDressLineBtn_Click(object sender, EventArgs e)
        {
            //打开服装线上的三个读写器，并启动三个线程进行监控
            try
            {
                int dressLineFre = Convert.ToInt32(dressLineFreTextBox.Text);
            }catch(Exception exception)
            {
                MessageBox.Show("请输入正确的频率值","Warning");
                Console.WriteLine(exception);
                return;
            }

            logListView.Items.Add(new ListViewItem("Readers Running..."));
            sort1Timer.Enabled = true;
            sort2Timer.Enabled = true;
            sort3Timer.Enabled = true;
            startDressLineBtn.Enabled = false;
            stopDressLineBtn.Enabled = true;
        }

        private void stopDressLineBtn_Click(object sender, EventArgs e)
        {
            //关闭读写器和线程
            sort1Timer.Stop();
            sort2Timer.Stop();
            sort3Timer.Stop();
            logListView.Items.Add(new ListViewItem("Readers Stop..."));
            startDressLineBtn.Enabled = true;
            stopDressLineBtn.Enabled = false;

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
                bindingDictionary.Add(epc, entries);
                ListViewItem item = new ListViewItem(epc);
                item.SubItems.Add(sortingEntries);
                bindListView.Items.Add(item);
            }
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
                for(int i = 0;i< bindListView.SelectedItems.Count; i++)
                {
                    string selectedEpc = bindListView.SelectedItems[i].SubItems[0].Text;
                    if (!deletedEpcs.Contains(selectedEpc))
                    {
                        deletedEpcs.Add(selectedEpc);
                        deletedEpcsStr += selectedEpc + ",";
                    }
                  
                }
                deletedEpcsStr = deletedEpcsStr.Substring(0, deletedEpcsStr.Length - 1);
                if (MessageBox.Show("确认清除绑定#" + deletedEpcsStr + "吗？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Console.WriteLine(deletedEpcsStr);
                    foreach(string epc in deletedEpcs)
                    {
                        bindingDictionary.Remove(epc);
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
            if (!scanReaderStatus)
            {
                readBtn.Text = "停止";
                //启动计时器
                scanTimer.Enabled = true;
                

            }//停止
            else
            {
                readBtn.Text = "读取";
                scanTimer.Stop();
            }
            scanReaderStatus = !scanReaderStatus;
            //tagTextBox.Text = 

        }

        private void readTag(object sender, System.Timers.ElapsedEventArgs e)
        {
            //获取所读标签的epc号
            string epc = DateTime.Now.Millisecond.ToString();
            this.BeginInvoke(method: new Action(() =>
            {
                tagTextBox.Text = epc;
            }));
        }

        //用于监控各分拣口
        private void sort(object sender, System.Timers.ElapsedEventArgs e,int entryNum)
        {
            //根据各分拣口上的读写器，获取当前读取的衣架上的epc号
            string epc = entryNum+"";
            if (bindingDictionary.ContainsKey(epc))
            {
                List<int> entries = bindingDictionary[epc];
                if (entries.Contains(entryNum))
                {// 进行分拣
                    //todo操作硬件


                    //更新绑定和界面
                    entries.Remove(entryNum);
                    bindingDictionary.Remove(epc);
                    bindingDictionary.Add(epc, entries);
                    string sortingEntries = listToString(entries);
                  
                    this.BeginInvoke(method: new Action(() =>
                    {
                        ListViewItem item = new ListViewItem("#"+epc+"在分拣口"+entryNum+"进行分拣");
                        logListView.Items.Add(item);
                        ListViewItem bindingItem = new ListViewItem(epc);
                        bindingItem.SubItems.Add(sortingEntries);
                        bindListView.Items.Add(bindingItem);
                    }));
                    // todo 检测到已下落后将挡板恢复原位 探头的事件？？？

                }
                else
                {//不进行分拣

                }
            }
            else
            {
                Console.WriteLine("在分拣口"+entryNum+"检测到#"+epc+"未绑定！");
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


        //

    }
}
