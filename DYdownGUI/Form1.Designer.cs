namespace DYdownGUI
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
            this.lstViewMain = new System.Windows.Forms.ListView();
            this.btnAlys = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cH1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cH2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewMain
            // 
            this.lstViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewMain.CheckBoxes = true;
            this.lstViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cH1,
            this.cH2});
            this.lstViewMain.FullRowSelect = true;
            this.lstViewMain.GridLines = true;
            this.lstViewMain.HideSelection = false;
            this.lstViewMain.Location = new System.Drawing.Point(12, 98);
            this.lstViewMain.Name = "lstViewMain";
            this.lstViewMain.Size = new System.Drawing.Size(1008, 343);
            this.lstViewMain.TabIndex = 0;
            this.lstViewMain.UseCompatibleStateImageBehavior = false;
            this.lstViewMain.View = System.Windows.Forms.View.Details;
            // 
            // btnAlys
            // 
            this.btnAlys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlys.Location = new System.Drawing.Point(721, 28);
            this.btnAlys.Name = "btnAlys";
            this.btnAlys.Size = new System.Drawing.Size(121, 31);
            this.btnAlys.TabIndex = 1;
            this.btnAlys.Text = "解析";
            this.btnAlys.UseVisualStyleBackColor = true;
            this.btnAlys.Click += new System.EventHandler(this.btnAlys_Click);
            // 
            // txtB
            // 
            this.txtB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB.Location = new System.Drawing.Point(154, 28);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(561, 31);
            this.txtB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "主页短地址：";
            // 
            // cH1
            // 
            this.cH1.Text = "标题";
            this.cH1.Width = 353;
            // 
            // cH2
            // 
            this.cH2.Text = "实际地址";
            this.cH2.Width = 638;
            // 
            // btnDA
            // 
            this.btnDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDA.Location = new System.Drawing.Point(899, 28);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(121, 31);
            this.btnDA.TabIndex = 4;
            this.btnDA.Text = "下载全部";
            this.btnDA.UseVisualStyleBackColor = true;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 453);
            this.Controls.Add(this.btnDA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.btnAlys);
            this.Controls.Add(this.lstViewMain);
            this.Name = "Form1";
            this.Text = "DY Downloader v0.1 Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewMain;
        private System.Windows.Forms.Button btnAlys;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader cH1;
        private System.Windows.Forms.ColumnHeader cH2;
        private System.Windows.Forms.Button btnDA;
    }
}

