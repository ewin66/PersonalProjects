namespace ForumHelper
{
    partial class ToastForm
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
            this.pageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // pageLinkLabel
            // 
            this.pageLinkLabel.AutoSize = true;
            this.pageLinkLabel.Location = new System.Drawing.Point(12, 9);
            this.pageLinkLabel.Name = "pageLinkLabel";
            this.pageLinkLabel.Size = new System.Drawing.Size(77, 13);
            this.pageLinkLabel.TabIndex = 0;
            this.pageLinkLabel.TabStop = true;
            this.pageLinkLabel.Text = "pageLinkLabel";
            this.pageLinkLabel.Click += new System.EventHandler(this.pageLinkLabelClick);
            // 
            // ToastForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 91);
            this.Controls.Add(this.pageLinkLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToastForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ToastForm_Load);
            this.Click += new System.EventHandler(this.ToastForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel pageLinkLabel;
    }
}