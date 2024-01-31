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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.DataSourceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSourceGroup
            // 
            this.DataSourceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceGroup.Controls.Add(this.DataSourceTextBox);
            this.DataSourceGroup.Location = new System.Drawing.Point(12, 12);
            this.DataSourceGroup.Name = "DataSourceGroup";
            this.DataSourceGroup.Size = new System.Drawing.Size(604, 52);
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
            this.DataSourceTextBox.Size = new System.Drawing.Size(592, 20);
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
            this.DataSourceContentBox.Size = new System.Drawing.Size(591, 418);
            this.DataSourceContentBox.TabIndex = 1;
            this.DataSourceContentBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataSourceContentBox_MouseDoubleClick);
            // 
            // LoadingAnimation
            // 
            this.LoadingAnimation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoadingAnimation.Image = global::PDF_Parser.Properties.Resources.loading;
            this.LoadingAnimation.Location = new System.Drawing.Point(213, 144);
            this.LoadingAnimation.Name = "LoadingAnimation";
            this.LoadingAnimation.Size = new System.Drawing.Size(176, 169);
            this.LoadingAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingAnimation.TabIndex = 2;
            this.LoadingAnimation.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LoadingAnimation);
            this.groupBox1.Controls.Add(this.DataSourceContentBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 457);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.FilterTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterTextBox.Location = new System.Drawing.Point(6, 19);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(592, 20);
            this.FilterTextBox.TabIndex = 0;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 597);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DataSourceGroup);
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.Text = "PDF-Parser";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.DataSourceGroup.ResumeLayout(false);
            this.DataSourceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAnimation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DataSourceGroup;
        private System.Windows.Forms.TextBox DataSourceTextBox;
        private System.Windows.Forms.ListBox DataSourceContentBox;
        private System.Windows.Forms.PictureBox LoadingAnimation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox FilterTextBox;
    }
}

