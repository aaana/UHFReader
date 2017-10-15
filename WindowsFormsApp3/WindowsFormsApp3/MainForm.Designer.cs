namespace WindowsFormsApp3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.bindCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.bindBtn = new System.Windows.Forms.Button();
            this.startDressLineBtn = new System.Windows.Forms.Button();
            this.stopDressLineBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bindListView = new System.Windows.Forms.ListView();
            this.epc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entries = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearBindBtn = new System.Windows.Forms.Button();
            this.logListView = new System.Windows.Forms.ListView();
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TAG";
            // 
            // bindCheckedListBox
            // 
            this.bindCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bindCheckedListBox.FormattingEnabled = true;
            this.bindCheckedListBox.Items.AddRange(new object[] {
            "自动线1号位",
            "自动线2号位",
            "自动线3号位"});
            this.bindCheckedListBox.Location = new System.Drawing.Point(96, 116);
            this.bindCheckedListBox.Name = "bindCheckedListBox";
            this.bindCheckedListBox.Size = new System.Drawing.Size(177, 84);
            this.bindCheckedListBox.TabIndex = 2;
            // 
            // bindBtn
            // 
            this.bindBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bindBtn.Location = new System.Drawing.Point(277, 128);
            this.bindBtn.Name = "bindBtn";
            this.bindBtn.Size = new System.Drawing.Size(75, 29);
            this.bindBtn.TabIndex = 3;
            this.bindBtn.Text = "绑定";
            this.bindBtn.UseVisualStyleBackColor = true;
            this.bindBtn.Click += new System.EventHandler(this.bindBtn_Click);
            // 
            // startDressLineBtn
            // 
            this.startDressLineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startDressLineBtn.Location = new System.Drawing.Point(516, 59);
            this.startDressLineBtn.Name = "startDressLineBtn";
            this.startDressLineBtn.Size = new System.Drawing.Size(102, 29);
            this.startDressLineBtn.TabIndex = 4;
            this.startDressLineBtn.Text = "服装线启动";
            this.startDressLineBtn.UseVisualStyleBackColor = true;
            this.startDressLineBtn.Click += new System.EventHandler(this.startDressLineBtn_Click);
            // 
            // stopDressLineBtn
            // 
            this.stopDressLineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopDressLineBtn.Location = new System.Drawing.Point(648, 59);
            this.stopDressLineBtn.Name = "stopDressLineBtn";
            this.stopDressLineBtn.Size = new System.Drawing.Size(95, 29);
            this.stopDressLineBtn.TabIndex = 5;
            this.stopDressLineBtn.Text = "服装线停止";
            this.stopDressLineBtn.UseVisualStyleBackColor = true;
            this.stopDressLineBtn.Click += new System.EventHandler(this.stopDressLineBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(779, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "运行频率";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(850, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 26);
            this.textBox2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(904, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "日志";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(277, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "读取";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bindListView
            // 
            this.bindListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.epc,
            this.entries});
            this.bindListView.Location = new System.Drawing.Point(56, 195);
            this.bindListView.Name = "bindListView";
            this.bindListView.Size = new System.Drawing.Size(355, 329);
            this.bindListView.TabIndex = 12;
            this.bindListView.UseCompatibleStateImageBehavior = false;
            this.bindListView.View = System.Windows.Forms.View.Details;
            this.bindListView.SelectedIndexChanged += new System.EventHandler(this.bindListView_SelectedIndexChanged);
            // 
            // epc
            // 
            this.epc.Text = "EPC";
            this.epc.Width = 175;
            // 
            // entries
            // 
            this.entries.Text = "分拣口";
            this.entries.Width = 175;
            // 
            // clearBindBtn
            // 
            this.clearBindBtn.Location = new System.Drawing.Point(310, 530);
            this.clearBindBtn.Name = "clearBindBtn";
            this.clearBindBtn.Size = new System.Drawing.Size(101, 32);
            this.clearBindBtn.TabIndex = 13;
            this.clearBindBtn.Text = "清除绑定";
            this.clearBindBtn.UseVisualStyleBackColor = true;
            this.clearBindBtn.Click += new System.EventHandler(this.clearBindBtn_Click);
            // 
            // logListView
            // 
            this.logListView.Location = new System.Drawing.Point(516, 155);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(398, 346);
            this.logListView.TabIndex = 14;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(827, 530);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(87, 32);
            this.clearLogBtn.TabIndex = 15;
            this.clearLogBtn.Text = "清除日志";
            this.clearLogBtn.UseVisualStyleBackColor = true;
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(96, 60);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(144, 26);
            this.tagTextBox.TabIndex = 16;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(96, 92);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(56, 24);
            this.selectAllCheckBox.TabIndex = 17;
            this.selectAllCheckBox.Text = "全选";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(969, 717);
            this.Controls.Add(this.selectAllCheckBox);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.clearLogBtn);
            this.Controls.Add(this.logListView);
            this.Controls.Add(this.clearBindBtn);
            this.Controls.Add(this.bindListView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stopDressLineBtn);
            this.Controls.Add(this.startDressLineBtn);
            this.Controls.Add(this.bindBtn);
            this.Controls.Add(this.bindCheckedListBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox bindCheckedListBox;
        private System.Windows.Forms.Button bindBtn;
        private System.Windows.Forms.Button startDressLineBtn;
        private System.Windows.Forms.Button stopDressLineBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView bindListView;
        private System.Windows.Forms.Button clearBindBtn;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.ColumnHeader epc;
        private System.Windows.Forms.ColumnHeader entries;
    }
}