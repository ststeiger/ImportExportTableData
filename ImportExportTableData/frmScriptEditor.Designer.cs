namespace ImportExportTableData
{
    partial class frmScriptEditor
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
            this.txtScriptArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtScriptArea
            // 
            this.txtScriptArea.Location = new System.Drawing.Point(21, 12);
            this.txtScriptArea.Multiline = true;
            this.txtScriptArea.Name = "txtScriptArea";
            this.txtScriptArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScriptArea.Size = new System.Drawing.Size(569, 483);
            this.txtScriptArea.TabIndex = 0;
            this.txtScriptArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScriptArea_KeyDown);
            // 
            // frmScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 507);
            this.Controls.Add(this.txtScriptArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmScriptEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script Editor";
            this.Load += new System.EventHandler(this.frmScriptEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScriptArea;
    }
}