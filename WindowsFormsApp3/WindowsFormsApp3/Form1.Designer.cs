namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.OpenPort = new System.Windows.Forms.Button();
            this.Edit_CmdComAddr = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ComboBox_COM = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ListView1_EPC = new System.Windows.Forms.ListView();
            this.listViewCol_Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCol_Times = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_COM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboBox_baud2 = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.ComboBox_AlreadyOpenCOM = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClosePort = new System.Windows.Forms.Button();
            this.Timer_Test_ = new System.Windows.Forms.Timer(this.components);
            this.ListView3_EPC = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EPC_LEN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboBox_baud3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBox3_AlreadyOpenCOM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.OpenPort3 = new System.Windows.Forms.Button();
            this.Edit3_CmdComAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBox3_COM = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Timer_Test_3 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "查询标签";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OpenPort
            // 
            this.OpenPort.Location = new System.Drawing.Point(5, 66);
            this.OpenPort.Name = "OpenPort";
            this.OpenPort.Size = new System.Drawing.Size(125, 23);
            this.OpenPort.TabIndex = 4;
            this.OpenPort.Text = "打开端口";
            this.OpenPort.UseVisualStyleBackColor = true;
            this.OpenPort.Click += new System.EventHandler(this.OpenPort_Click);
            // 
            // Edit_CmdComAddr
            // 
            this.Edit_CmdComAddr.BackColor = System.Drawing.SystemColors.Window;
            this.Edit_CmdComAddr.Location = new System.Drawing.Point(98, 39);
            this.Edit_CmdComAddr.MaxLength = 2;
            this.Edit_CmdComAddr.Name = "Edit_CmdComAddr";
            this.Edit_CmdComAddr.Size = new System.Drawing.Size(32, 21);
            this.Edit_CmdComAddr.TabIndex = 3;
            this.Edit_CmdComAddr.Text = "FF";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 12);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "读写器地址:";
            // 
            // ComboBox_COM
            // 
            this.ComboBox_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_COM.FormattingEnabled = true;
            this.ComboBox_COM.Location = new System.Drawing.Point(63, 12);
            this.ComboBox_COM.Name = "ComboBox_COM";
            this.ComboBox_COM.Size = new System.Drawing.Size(65, 20);
            this.ComboBox_COM.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "端口：";
            // 
            // ListView1_EPC
            // 
            this.ListView1_EPC.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.ListView1_EPC.AutoArrange = false;
            this.ListView1_EPC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListView1_EPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewCol_Number,
            this.listViewCol_ID,
            this.listViewCol_Length,
            this.listViewCol_Times,
            this.listview_COM});
            this.ListView1_EPC.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListView1_EPC.FullRowSelect = true;
            this.ListView1_EPC.GridLines = true;
            this.ListView1_EPC.Location = new System.Drawing.Point(0, 0);
            this.ListView1_EPC.Name = "ListView1_EPC";
            this.ListView1_EPC.Size = new System.Drawing.Size(936, 72);
            this.ListView1_EPC.TabIndex = 45;
            this.ListView1_EPC.UseCompatibleStateImageBehavior = false;
            this.ListView1_EPC.View = System.Windows.Forms.View.Details;
            // 
            // listViewCol_Number
            // 
            this.listViewCol_Number.Text = "序号";
            this.listViewCol_Number.Width = 40;
            // 
            // listViewCol_ID
            // 
            this.listViewCol_ID.Text = "EPC号";
            this.listViewCol_ID.Width = 150;
            // 
            // listViewCol_Length
            // 
            this.listViewCol_Length.Text = "EPC长度";
            this.listViewCol_Length.Width = 150;
            // 
            // listViewCol_Times
            // 
            this.listViewCol_Times.Text = "次数";
            // 
            // listview_COM
            // 
            this.listview_COM.Text = "COM";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ComboBox_baud2);
            this.GroupBox1.Controls.Add(this.label47);
            this.GroupBox1.Controls.Add(this.ComboBox_AlreadyOpenCOM);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.ClosePort);
            this.GroupBox1.Controls.Add(this.OpenPort);
            this.GroupBox1.Controls.Add(this.Edit_CmdComAddr);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.ComboBox_COM);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 78);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(136, 206);
            this.GroupBox1.TabIndex = 44;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "通讯";
            // 
            // ComboBox_baud2
            // 
            this.ComboBox_baud2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_baud2.FormattingEnabled = true;
            this.ComboBox_baud2.Items.AddRange(new object[] {
            "9600bps",
            "19200bps",
            "38400bps",
            "57600bps",
            "115200bps"});
            this.ComboBox_baud2.Location = new System.Drawing.Point(7, 110);
            this.ComboBox_baud2.Name = "ComboBox_baud2";
            this.ComboBox_baud2.Size = new System.Drawing.Size(121, 20);
            this.ComboBox_baud2.TabIndex = 12;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 95);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(47, 12);
            this.label47.TabIndex = 9;
            this.label47.Text = "波特率:";
            // 
            // ComboBox_AlreadyOpenCOM
            // 
            this.ComboBox_AlreadyOpenCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_AlreadyOpenCOM.FormattingEnabled = true;
            this.ComboBox_AlreadyOpenCOM.Location = new System.Drawing.Point(5, 153);
            this.ComboBox_AlreadyOpenCOM.Name = "ComboBox_AlreadyOpenCOM";
            this.ComboBox_AlreadyOpenCOM.Size = new System.Drawing.Size(125, 20);
            this.ComboBox_AlreadyOpenCOM.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "已打开端口:";
            // 
            // ClosePort
            // 
            this.ClosePort.Location = new System.Drawing.Point(5, 177);
            this.ClosePort.Name = "ClosePort";
            this.ClosePort.Size = new System.Drawing.Size(125, 23);
            this.ClosePort.TabIndex = 5;
            this.ClosePort.Text = "关闭端口";
            this.ClosePort.UseVisualStyleBackColor = true;
            // 
            // Timer_Test_
            // 
            this.Timer_Test_.Tick += new System.EventHandler(this.Timer_Test__Tick_1);
            // 
            // ListView3_EPC
            // 
            this.ListView3_EPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.EPC,
            this.EPC_LEN,
            this.Count,
            this.COM});
            this.ListView3_EPC.GridLines = true;
            this.ListView3_EPC.Location = new System.Drawing.Point(0, 290);
            this.ListView3_EPC.Name = "ListView3_EPC";
            this.ListView3_EPC.Size = new System.Drawing.Size(936, 97);
            this.ListView3_EPC.TabIndex = 46;
            this.ListView3_EPC.UseCompatibleStateImageBehavior = false;
            this.ListView3_EPC.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "序号";
            // 
            // EPC
            // 
            this.EPC.Text = "EPC号";
            // 
            // EPC_LEN
            // 
            this.EPC_LEN.Text = "EPC长度";
            // 
            // Count
            // 
            this.Count.Text = "次数";
            // 
            // COM
            // 
            this.COM.Text = "COM";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 411);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 47;
            this.button3.Text = "查询标签";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboBox_baud3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ComboBox3_AlreadyOpenCOM);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.OpenPort3);
            this.groupBox2.Controls.Add(this.Edit3_CmdComAddr);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ComboBox3_COM);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 398);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 206);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通讯";
            // 
            // ComboBox_baud3
            // 
            this.ComboBox_baud3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_baud3.FormattingEnabled = true;
            this.ComboBox_baud3.Items.AddRange(new object[] {
            "9600bps",
            "19200bps",
            "38400bps",
            "57600bps",
            "115200bps"});
            this.ComboBox_baud3.Location = new System.Drawing.Point(7, 110);
            this.ComboBox_baud3.Name = "ComboBox_baud3";
            this.ComboBox_baud3.Size = new System.Drawing.Size(121, 20);
            this.ComboBox_baud3.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "波特率:";
            // 
            // ComboBox3_AlreadyOpenCOM
            // 
            this.ComboBox3_AlreadyOpenCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox3_AlreadyOpenCOM.FormattingEnabled = true;
            this.ComboBox3_AlreadyOpenCOM.Location = new System.Drawing.Point(5, 153);
            this.ComboBox3_AlreadyOpenCOM.Name = "ComboBox3_AlreadyOpenCOM";
            this.ComboBox3_AlreadyOpenCOM.Size = new System.Drawing.Size(125, 20);
            this.ComboBox3_AlreadyOpenCOM.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "已打开端口:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "关闭端口";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OpenPort3
            // 
            this.OpenPort3.Location = new System.Drawing.Point(5, 66);
            this.OpenPort3.Name = "OpenPort3";
            this.OpenPort3.Size = new System.Drawing.Size(125, 23);
            this.OpenPort3.TabIndex = 4;
            this.OpenPort3.Text = "打开端口";
            this.OpenPort3.UseVisualStyleBackColor = true;
            this.OpenPort3.Click += new System.EventHandler(this.OpenPort3_Click);
            // 
            // Edit3_CmdComAddr
            // 
            this.Edit3_CmdComAddr.BackColor = System.Drawing.SystemColors.Window;
            this.Edit3_CmdComAddr.Location = new System.Drawing.Point(98, 39);
            this.Edit3_CmdComAddr.MaxLength = 2;
            this.Edit3_CmdComAddr.Name = "Edit3_CmdComAddr";
            this.Edit3_CmdComAddr.Size = new System.Drawing.Size(32, 21);
            this.Edit3_CmdComAddr.TabIndex = 3;
            this.Edit3_CmdComAddr.Text = "FF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "读写器地址:";
            // 
            // ComboBox3_COM
            // 
            this.ComboBox3_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox3_COM.FormattingEnabled = true;
            this.ComboBox3_COM.Location = new System.Drawing.Point(63, 12);
            this.ComboBox3_COM.Name = "ComboBox3_COM";
            this.ComboBox3_COM.Size = new System.Drawing.Size(65, 20);
            this.ComboBox3_COM.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "端口：";
            // 
            // Timer_Test_3
            // 
            this.Timer_Test_3.Tick += new System.EventHandler(this.Timer_Test_3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 616);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ListView3_EPC);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ListView1_EPC);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button OpenPort;
        internal System.Windows.Forms.TextBox Edit_CmdComAddr;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox ComboBox_COM;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ListView ListView1_EPC;
        private System.Windows.Forms.ColumnHeader listViewCol_Number;
        private System.Windows.Forms.ColumnHeader listViewCol_ID;
        private System.Windows.Forms.ColumnHeader listViewCol_Length;
        private System.Windows.Forms.ColumnHeader listViewCol_Times;
        private System.Windows.Forms.ColumnHeader listview_COM;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ComboBox ComboBox_baud2;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox ComboBox_AlreadyOpenCOM;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button ClosePort;
        private System.Windows.Forms.Timer Timer_Test_;
        private System.Windows.Forms.ListView ListView3_EPC;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader EPC;
        private System.Windows.Forms.ColumnHeader EPC_LEN;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.ColumnHeader COM;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ComboBox_baud3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboBox3_AlreadyOpenCOM;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button OpenPort3;
        internal System.Windows.Forms.TextBox Edit3_CmdComAddr;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox ComboBox3_COM;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer Timer_Test_3;
    }
}

