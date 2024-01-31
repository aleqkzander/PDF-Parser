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
            this.DataSourceGroup = new System.Windows.Forms.GroupBox();
            this.DataSourceTextBox = new System.Windows.Forms.TextBox();
            this.DataSourceContentBox = new System.Windows.Forms.ListBox();
            this.LoadingAnimation = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataSourceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSourceGroup
            // 
            this.DataSourceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceGroup.Controls.Add(this.DataSourceTextBox);
            this.DataSourceGroup.Location = new System.Drawing.Point(12, 12);
            this.DataSourceGroup.Name = "DataSourceGroup";
            this.DataSourceGroup.Size = new System.Drawing.Size(460, 52);
            this.DataSourceGroup.TabIndex = 0;
            this.DataSourceGroup.TabStop = false;
            this.DataSourceGroup.Text = "Datasource";
            // 
            // DataSourceTextBox
            // 
            this.DataSourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceTextBox.Location = new System.Drawing.Point(6, 19);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(448, 20);
            this.DataSourceTextBox.TabIndex = 0;
            // 
            // DataSourceContentBox
            // 
            this.DataSourceContentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceContentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataSourceContentBox.FormattingEnabled = true;
            this.DataSourceContentBox.Location = new System.Drawing.Point(6, 19);
            this.DataSourceContentBox.Name = "DataSourceContentBox";
            this.DataSourceContentBox.Size = new System.Drawing.Size(447, 353);
            this.DataSourceContentBox.TabIndex = 1;
            this.DataSourceContentBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataSourceContentBox_MouseDoubleClick);
            // 
            // LoadingAnimation
            // 
            this.LoadingAnimation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoadingAnimation.Image = global::PDF_Parser.Properties.Resources.loading;
            this.LoadingAnimation.Location = new System.Drawing.Point(141, 105);
            this.LoadingAnimation.Name = "LoadingAnimation";
            this.LoadingAnimation.Size = new System.Drawing.Size(176, 169);
            this.LoadingAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingAnimation.TabIndex = 2;
            this.LoadingAnimation.TabStop = false;
            this.LoadingAnimation.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LoadingAnimation);
            this.groupBox1.Controls.Add(this.DataSourceContentBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 378);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DataSourceGroup);
            this.Name = "Welcome";
            this.Text = "PDF-Parser";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.DataSourceGroup.ResumeLayout(false);
            this.DataSourceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DataSourceGroup;
        private System.Windows.Forms.TextBox DataSourceTextBox;
        private System.Windows.Forms.ListBox DataSourceContentBox;
        private System.Windows.Forms.PictureBox LoadingAnimation;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

