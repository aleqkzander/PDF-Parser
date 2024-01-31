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
            this.DataSourceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSourceGroup
            // 
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
            this.DataSourceTextBox.Location = new System.Drawing.Point(6, 19);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(448, 20);
            this.DataSourceTextBox.TabIndex = 0;
            // 
            // DataSourceContentBox
            // 
            this.DataSourceContentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataSourceContentBox.FormattingEnabled = true;
            this.DataSourceContentBox.Location = new System.Drawing.Point(12, 70);
            this.DataSourceContentBox.Name = "DataSourceContentBox";
            this.DataSourceContentBox.Size = new System.Drawing.Size(460, 379);
            this.DataSourceContentBox.TabIndex = 1;
            this.DataSourceContentBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataSourceContentBox_MouseDoubleClick);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.DataSourceContentBox);
            this.Controls.Add(this.DataSourceGroup);
            this.Name = "Welcome";
            this.Text = "PDF-Parser";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.DataSourceGroup.ResumeLayout(false);
            this.DataSourceGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DataSourceGroup;
        private System.Windows.Forms.TextBox DataSourceTextBox;
        private System.Windows.Forms.ListBox DataSourceContentBox;
    }
}

