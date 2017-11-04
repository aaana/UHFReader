namespace WindowsFormsApp3
{
    partial class BindingForm
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
            this.leftListBox = new System.Windows.Forms.ListBox();
            this.rightListBox = new System.Windows.Forms.ListBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.conformBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.epcLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // leftListBox
            // 
            this.leftListBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leftListBox.FormattingEnabled = true;
            this.leftListBox.ItemHeight = 17;
            this.leftListBox.Items.AddRange(new object[] {
            "分拣口1",
            "分拣口2",
            "分拣口3"});
            this.leftListBox.Location = new System.Drawing.Point(49, 80);
            this.leftListBox.Name = "leftListBox";
            this.leftListBox.Size = new System.Drawing.Size(133, 72);
            this.leftListBox.TabIndex = 0;
            // 
            // rightListBox
            // 
            this.rightListBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rightListBox.FormattingEnabled = true;
            this.rightListBox.ItemHeight = 17;
            this.rightListBox.Location = new System.Drawing.Point(325, 80);
            this.rightListBox.Name = "rightListBox";
            this.rightListBox.Size = new System.Drawing.Size(138, 72);
            this.rightListBox.TabIndex = 1;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(239, 80);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(32, 23);
            this.selectBtn.TabIndex = 2;
            this.selectBtn.Text = "->";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // conformBtn
            // 
            this.conformBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conformBtn.Location = new System.Drawing.Point(388, 198);
            this.conformBtn.Name = "conformBtn";
            this.conformBtn.Size = new System.Drawing.Size(75, 23);
            this.conformBtn.TabIndex = 3;
            this.conformBtn.Text = "确定";
            this.conformBtn.UseVisualStyleBackColor = true;
            this.conformBtn.Click += new System.EventHandler(this.conformBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(239, 128);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(32, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "<-";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "EPC";
            // 
            // epcLabel
            // 
            this.epcLabel.AutoSize = true;
            this.epcLabel.BackColor = System.Drawing.Color.Transparent;
            this.epcLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.epcLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epcLabel.Location = new System.Drawing.Point(90, 18);
            this.epcLabel.Name = "epcLabel";
            this.epcLabel.Padding = new System.Windows.Forms.Padding(2);
            this.epcLabel.Size = new System.Drawing.Size(55, 20);
            this.epcLabel.TabIndex = 6;
            this.epcLabel.Text = "label2";
            // 
            // BindingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(511, 239);
            this.Controls.Add(this.epcLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.conformBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.rightListBox);
            this.Controls.Add(this.leftListBox);
            this.Name = "BindingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服装绑定窗口";
            this.Load += new System.EventHandler(this.BindingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox leftListBox;
        private System.Windows.Forms.ListBox rightListBox;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button conformBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label epcLabel;
    }
}