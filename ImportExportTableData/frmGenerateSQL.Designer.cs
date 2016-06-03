namespace ImportExportTableData
{
    partial class frmGenerateSQL
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
            this.btnGenerateSQL = new System.Windows.Forms.Button();
            this.txtSQLoutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerateSQL
            // 
            this.btnGenerateSQL.Location = new System.Drawing.Point(12, 359);
            this.btnGenerateSQL.Name = "btnGenerateSQL";
            this.btnGenerateSQL.Size = new System.Drawing.Size(93, 23);
            this.btnGenerateSQL.TabIndex = 0;
            this.btnGenerateSQL.Text = "GenerateSQL";
            this.btnGenerateSQL.UseVisualStyleBackColor = true;
            this.btnGenerateSQL.Click += new System.EventHandler(this.btnGenerateSQL_Click);
            // 
            // txtSQLoutput
            // 
            this.txtSQLoutput.Location = new System.Drawing.Point(12, 12);
            this.txtSQLoutput.Multiline = true;
            this.txtSQLoutput.Name = "txtSQLoutput";
            this.txtSQLoutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSQLoutput.Size = new System.Drawing.Size(666, 331);
            this.txtSQLoutput.TabIndex = 1;
            this.txtSQLoutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQLoutput_KeyDown);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 394);
            this.Controls.Add(this.txtSQLoutput);
            this.Controls.Add(this.btnGenerateSQL);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateSQL;
        private System.Windows.Forms.TextBox txtSQLoutput;
    }
}