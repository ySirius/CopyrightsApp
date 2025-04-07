namespace CopyrightsApp
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.listBoxProgress = new System.Windows.Forms.ListBox();
            this.textBoxSourceDir = new System.Windows.Forms.TextBox();
            this.btnSourceDir = new System.Windows.Forms.Button();
            this.labelSourceDir = new System.Windows.Forms.Label();
            this.labelRule = new System.Windows.Forms.Label();
            this.buttonStartParsing = new System.Windows.Forms.Button();
            this.fbdDir = new System.Windows.Forms.FolderBrowserDialog();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRule = new System.Windows.Forms.ComboBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxProgress
            // 
            this.listBoxProgress.Font = new System.Drawing.Font("宋体", 9F);
            this.listBoxProgress.FormattingEnabled = true;
            this.listBoxProgress.HorizontalScrollbar = true;
            this.listBoxProgress.ItemHeight = 18;
            this.listBoxProgress.Location = new System.Drawing.Point(14, 157);
            this.listBoxProgress.Name = "listBoxProgress";
            this.listBoxProgress.Size = new System.Drawing.Size(600, 256);
            this.listBoxProgress.TabIndex = 0;
            this.listBoxProgress.TabStop = false;
            // 
            // textBoxSourceDir
            // 
            this.textBoxSourceDir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSourceDir.Location = new System.Drawing.Point(80, 15);
            this.textBoxSourceDir.Name = "textBoxSourceDir";
            this.textBoxSourceDir.ReadOnly = true;
            this.textBoxSourceDir.Size = new System.Drawing.Size(300, 30);
            this.textBoxSourceDir.TabIndex = 1;
            // 
            // btnSourceDir
            // 
            this.btnSourceDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(50)))));
            this.btnSourceDir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(50)))));
            this.btnSourceDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSourceDir.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSourceDir.ForeColor = System.Drawing.Color.White;
            this.btnSourceDir.Location = new System.Drawing.Point(386, 15);
            this.btnSourceDir.Name = "btnSourceDir";
            this.btnSourceDir.Size = new System.Drawing.Size(85, 23);
            this.btnSourceDir.TabIndex = 3;
            this.btnSourceDir.Text = "选择目录";
            this.btnSourceDir.UseVisualStyleBackColor = false;
            this.btnSourceDir.Click += new System.EventHandler(this.BtnSourceDir_Click);
            // 
            // labelSourceDir
            // 
            this.labelSourceDir.AutoSize = true;
            this.labelSourceDir.Location = new System.Drawing.Point(11, 18);
            this.labelSourceDir.Name = "labelSourceDir";
            this.labelSourceDir.Size = new System.Drawing.Size(89, 20);
            this.labelSourceDir.TabIndex = 5;
            this.labelSourceDir.Text = "源码目录";
            this.labelSourceDir.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelRule
            // 
            this.labelRule.AutoSize = true;
            this.labelRule.Location = new System.Drawing.Point(11, 47);
            this.labelRule.Name = "labelRule";
            this.labelRule.Size = new System.Drawing.Size(89, 20);
            this.labelRule.TabIndex = 6;
            this.labelRule.Text = "规则文件";
            this.labelRule.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonStartParsing
            // 
            this.buttonStartParsing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(50)))));
            this.buttonStartParsing.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(50)))));
            this.buttonStartParsing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartParsing.ForeColor = System.Drawing.Color.White;
            this.buttonStartParsing.Location = new System.Drawing.Point(483, 15);
            this.buttonStartParsing.Name = "buttonStartParsing";
            this.buttonStartParsing.Size = new System.Drawing.Size(131, 123);
            this.buttonStartParsing.TabIndex = 7;
            this.buttonStartParsing.Text = "开始处理";
            this.buttonStartParsing.UseVisualStyleBackColor = false;
            this.buttonStartParsing.Click += new System.EventHandler(this.BtnStartParsing_Click);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbName.Location = new System.Drawing.Point(80, 81);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(391, 30);
            this.tbName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 40);
            this.label2.TabIndex = 14;
            this.label2.Text = "软件名称\r\n与版本号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbRule
            // 
            this.cbRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRule.FormattingEnabled = true;
            this.cbRule.Items.AddRange(new object[] {
            ".Net",
            "Go",
            "Vue",
            "Python",
            "WeApp",
            "C",
            "C++"});
            this.cbRule.Location = new System.Drawing.Point(80, 49);
            this.cbRule.Name = "cbRule";
            this.cbRule.Size = new System.Drawing.Size(391, 28);
            this.cbRule.TabIndex = 15;
            // 
            // tbOutput
            // 
            this.tbOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOutput.Location = new System.Drawing.Point(80, 115);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.Size = new System.Drawing.Size(300, 30);
            this.tbOutput.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "生成文件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnOutput
            // 
            this.btnOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(50)))));
            this.btnOutput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(50)))));
            this.btnOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutput.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOutput.ForeColor = System.Drawing.Color.White;
            this.btnOutput.Location = new System.Drawing.Point(386, 115);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(85, 23);
            this.btnOutput.TabIndex = 9;
            this.btnOutput.Text = "选择路径";
            this.btnOutput.UseVisualStyleBackColor = false;
            this.btnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.cbRule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.buttonStartParsing);
            this.Controls.Add(this.labelRule);
            this.Controls.Add(this.labelSourceDir);
            this.Controls.Add(this.btnSourceDir);
            this.Controls.Add(this.textBoxSourceDir);
            this.Controls.Add(this.listBoxProgress);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软著源码生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox listBoxProgress;
        private System.Windows.Forms.TextBox textBoxSourceDir;
        private System.Windows.Forms.Button btnSourceDir;
        private System.Windows.Forms.Label labelSourceDir;
        private System.Windows.Forms.Label labelRule;
        private System.Windows.Forms.Button buttonStartParsing;
        private System.Windows.Forms.FolderBrowserDialog fbdDir;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRule;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOutput;
    }
}

