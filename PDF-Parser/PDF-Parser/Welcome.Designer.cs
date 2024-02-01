namespace PDF_Parser
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.DataSourceContentBox = new System.Windows.Forms.ListBox();
            this.LoadingAnimation = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveDatasourceBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.DataSourceTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.FilterTextBox = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSourceContentBox
            // 
            this.DataSourceContentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceContentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataSourceContentBox.FormattingEnabled = true;
            this.DataSourceContentBox.Location = new System.Drawing.Point(0, 28);
            this.DataSourceContentBox.Name = "DataSourceContentBox";
            this.DataSourceContentBox.Size = new System.Drawing.Size(628, 574);
            this.DataSourceContentBox.TabIndex = 1;
            this.DataSourceContentBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataSourceContentBox_MouseDoubleClick);
            // 
            // LoadingAnimation
            // 
            this.LoadingAnimation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoadingAnimation.Image = global::PDF_Parser.Properties.Resources.loading;
            this.LoadingAnimation.Location = new System.Drawing.Point(258, 244);
            this.LoadingAnimation.Name = "LoadingAnimation";
            this.LoadingAnimation.Size = new System.Drawing.Size(112, 109);
            this.LoadingAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingAnimation.TabIndex = 2;
            this.LoadingAnimation.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveDatasourceBtn,
            this.toolStripLabel1,
            this.DataSourceTextBox,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.FilterTextBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(628, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveDatasourceBtn
            // 
            this.SaveDatasourceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveDatasourceBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveDatasourceBtn.Image")));
            this.SaveDatasourceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveDatasourceBtn.Name = "SaveDatasourceBtn";
            this.SaveDatasourceBtn.Size = new System.Drawing.Size(23, 22);
            this.SaveDatasourceBtn.Text = "Save data source";
            this.SaveDatasourceBtn.Click += new System.EventHandler(this.SaveDatasourceBtn_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel1.Text = "Datasource";
            // 
            // DataSourceTextBox
            // 
            this.DataSourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataSourceTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(100, 25);
            this.DataSourceTextBox.ToolTipText = "Set data source";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel2.Text = "Filter";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(100, 25);
            this.FilterTextBox.ToolTipText = "Set filter";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 597);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LoadingAnimation);
            this.Controls.Add(this.DataSourceContentBox);
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.Text = "PDF-Parser";
            this.Load += new System.EventHandler(this.Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox DataSourceContentBox;
        private System.Windows.Forms.PictureBox LoadingAnimation;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveDatasourceBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox DataSourceTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox FilterTextBox;
    }
}

