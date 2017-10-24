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
            this.bindBtn = new System.Windows.Forms.Button();
            this.startDressLineBtn = new System.Windows.Forms.Button();
            this.stopDressLineBtn = new System.Windows.Forms.Button();
            this.readBtn = new System.Windows.Forms.Button();
            this.bindListView = new System.Windows.Forms.ListView();
            this.epc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entries = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearBindBtn = new System.Windows.Forms.Button();
            this.logListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearAllBindingBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TAG";
            // 
            // bindBtn
            // 
            this.bindBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bindBtn.Location = new System.Drawing.Point(500, 46);
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
            this.startDressLineBtn.Location = new System.Drawing.Point(33, 48);
            this.startDressLineBtn.Name = "startDressLineBtn";
            this.startDressLineBtn.Size = new System.Drawing.Size(102, 29);
            this.startDressLineBtn.TabIndex = 4;
            this.startDressLineBtn.Text = "服装线启动";
            this.startDressLineBtn.UseVisualStyleBackColor = true;
            this.startDressLineBtn.Click += new System.EventHandler(this.startDressLineBtn_Click);
            // 
            // stopDressLineBtn
            // 
            this.stopDressLineBtn.Enabled = false;
            this.stopDressLineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopDressLineBtn.Location = new System.Drawing.Point(486, 48);
            this.stopDressLineBtn.Name = "stopDressLineBtn";
            this.stopDressLineBtn.Size = new System.Drawing.Size(95, 29);
            this.stopDressLineBtn.TabIndex = 5;
            this.stopDressLineBtn.Text = "服装线停止";
            this.stopDressLineBtn.UseVisualStyleBackColor = true;
            this.stopDressLineBtn.Click += new System.EventHandler(this.stopDressLineBtn_Click);
            // 
            // readBtn
            // 
            this.readBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readBtn.Location = new System.Drawing.Point(395, 46);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(75, 29);
            this.readBtn.TabIndex = 11;
            this.readBtn.Text = "读取";
            this.readBtn.UseVisualStyleBackColor = false;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // bindListView
            // 
            this.bindListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.epc,
            this.entries});
            this.bindListView.Location = new System.Drawing.Point(28, 105);
            this.bindListView.Name = "bindListView";
            this.bindListView.Size = new System.Drawing.Size(547, 425);
            this.bindListView.TabIndex = 12;
            this.bindListView.UseCompatibleStateImageBehavior = false;
            this.bindListView.View = System.Windows.Forms.View.Details;
            // 
            // epc
            // 
            this.epc.Text = "EPC";
            this.epc.Width = 274;
            // 
            // entries
            // 
            this.entries.Text = "分拣口";
            this.entries.Width = 274;
            // 
            // clearBindBtn
            // 
            this.clearBindBtn.Location = new System.Drawing.Point(474, 537);
            this.clearBindBtn.Name = "clearBindBtn";
            this.clearBindBtn.Size = new System.Drawing.Size(101, 32);
            this.clearBindBtn.TabIndex = 13;
            this.clearBindBtn.Text = "清除绑定";
            this.clearBindBtn.UseVisualStyleBackColor = true;
            this.clearBindBtn.Click += new System.EventHandler(this.clearBindBtn_Click);
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.logListView.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.logListView.Location = new System.Drawing.Point(33, 105);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(548, 426);
            this.logListView.TabIndex = 14;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日志";
            this.columnHeader1.Width = 549;
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(494, 537);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(87, 32);
            this.clearLogBtn.TabIndex = 15;
            this.clearLogBtn.Text = "清空日志";
            this.clearLogBtn.UseVisualStyleBackColor = true;
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(68, 49);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(262, 26);
            this.tagTextBox.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearAllBindingBtn);
            this.groupBox1.Controls.Add(this.tagTextBox);
            this.groupBox1.Controls.Add(this.clearBindBtn);
            this.groupBox1.Controls.Add(this.bindListView);
            this.groupBox1.Controls.Add(this.readBtn);
            this.groupBox1.Controls.Add(this.bindBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 587);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标签读取与绑定";
            // 
            // clearAllBindingBtn
            // 
            this.clearAllBindingBtn.Location = new System.Drawing.Point(357, 536);
            this.clearAllBindingBtn.Name = "clearAllBindingBtn";
            this.clearAllBindingBtn.Size = new System.Drawing.Size(94, 33);
            this.clearAllBindingBtn.TabIndex = 18;
            this.clearAllBindingBtn.Text = "清空绑定";
            this.clearAllBindingBtn.UseVisualStyleBackColor = true;
            this.clearAllBindingBtn.Click += new System.EventHandler(this.clearAllBindingBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clearLogBtn);
            this.groupBox2.Controls.Add(this.logListView);
            this.groupBox2.Controls.Add(this.stopDressLineBtn);
            this.groupBox2.Controls.Add(this.startDressLineBtn);
            this.groupBox2.Location = new System.Drawing.Point(698, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 587);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服装线操作";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bindBtn;
        private System.Windows.Forms.Button startDressLineBtn;
        private System.Windows.Forms.Button stopDressLineBtn;
        private System.Windows.Forms.Button readBtn;
        private System.Windows.Forms.ListView bindListView;
        private System.Windows.Forms.Button clearBindBtn;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.ColumnHeader epc;
        private System.Windows.Forms.ColumnHeader entries;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button clearAllBindingBtn;
    }
}