namespace ImportExportTableData
{
    partial class frmEncryptDecrypt
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
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtDecryptedPw = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblWurdeKopiert = new System.Windows.Forms.Label();
            this.lblSprache = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lblAES = new System.Windows.Forms.Label();
            this.lbl3DES = new System.Windows.Forms.Label();
            this.txtAES = new System.Windows.Forms.TextBox();
            this.txt3DES = new System.Windows.Forms.TextBox();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.lblKlartext = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(159, 209);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(364, 20);
            this.txtTime.TabIndex = 41;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(10, 212);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(25, 13);
            this.lblTime.TabIndex = 40;
            this.lblTime.Text = "Zeit";
            // 
            // txtDecryptedPw
            // 
            this.txtDecryptedPw.Location = new System.Drawing.Point(159, 163);
            this.txtDecryptedPw.Name = "txtDecryptedPw";
            this.txtDecryptedPw.Size = new System.Drawing.Size(364, 20);
            this.txtDecryptedPw.TabIndex = 39;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(10, 161);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(94, 23);
            this.btnDecrypt.TabIndex = 38;
            this.btnDecrypt.Text = "Entschlüsseln";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblWurdeKopiert
            // 
            this.lblWurdeKopiert.AutoSize = true;
            this.lblWurdeKopiert.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblWurdeKopiert.Location = new System.Drawing.Point(156, 133);
            this.lblWurdeKopiert.Name = "lblWurdeKopiert";
            this.lblWurdeKopiert.Size = new System.Drawing.Size(229, 13);
            this.lblWurdeKopiert.TabIndex = 37;
            this.lblWurdeKopiert.Text = "Passwort wurde in die Zwischenablage kopiert.";
            this.lblWurdeKopiert.Visible = false;
            // 
            // lblSprache
            // 
            this.lblSprache.AutoSize = true;
            this.lblSprache.Location = new System.Drawing.Point(10, 15);
            this.lblSprache.Name = "lblSprache";
            this.lblSprache.Size = new System.Drawing.Size(47, 13);
            this.lblSprache.TabIndex = 36;
            this.lblSprache.Text = "Sprache";
            // 
            // cbLanguage
            // 
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "Deutsch",
            "English",
            "Español",
            "Français",
            "Italiano",
            "Русский",
            "中文"});
            this.cbLanguage.Location = new System.Drawing.Point(159, 12);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(173, 21);
            this.cbLanguage.TabIndex = 35;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            // 
            // lblAES
            // 
            this.lblAES.AutoSize = true;
            this.lblAES.Location = new System.Drawing.Point(10, 94);
            this.lblAES.Name = "lblAES";
            this.lblAES.Size = new System.Drawing.Size(80, 13);
            this.lblAES.TabIndex = 34;
            this.lblAES.Text = "Passwort (AES)";
            // 
            // lbl3DES
            // 
            this.lbl3DES.AutoSize = true;
            this.lbl3DES.Location = new System.Drawing.Point(10, 68);
            this.lbl3DES.Name = "lbl3DES";
            this.lbl3DES.Size = new System.Drawing.Size(107, 13);
            this.lbl3DES.TabIndex = 33;
            this.lbl3DES.Text = "Passwort (TripleDES)";
            // 
            // txtAES
            // 
            this.txtAES.Location = new System.Drawing.Point(159, 91);
            this.txtAES.Name = "txtAES";
            this.txtAES.Size = new System.Drawing.Size(364, 20);
            this.txtAES.TabIndex = 32;
            // 
            // txt3DES
            // 
            this.txt3DES.Location = new System.Drawing.Point(159, 65);
            this.txt3DES.Name = "txt3DES";
            this.txt3DES.Size = new System.Drawing.Size(364, 20);
            this.txt3DES.TabIndex = 31;
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(159, 39);
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(364, 20);
            this.txtPlainText.TabIndex = 30;
            this.txtPlainText.Validated += new System.EventHandler(this.txtPlainText_TextChanged);
            // 
            // lblKlartext
            // 
            this.lblKlartext.AutoSize = true;
            this.lblKlartext.Location = new System.Drawing.Point(10, 42);
            this.lblKlartext.Name = "lblKlartext";
            this.lblKlartext.Size = new System.Drawing.Size(94, 13);
            this.lblKlartext.TabIndex = 29;
            this.lblKlartext.Text = "Passwort (Klartext)";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(10, 128);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(94, 23);
            this.btnEncrypt.TabIndex = 28;
            this.btnEncrypt.Text = "Verschlüsseln";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // frmEncryptDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 195);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtDecryptedPw);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.lblWurdeKopiert);
            this.Controls.Add(this.lblSprache);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lblAES);
            this.Controls.Add(this.lbl3DES);
            this.Controls.Add(this.txtAES);
            this.Controls.Add(this.txt3DES);
            this.Controls.Add(this.txtPlainText);
            this.Controls.Add(this.lblKlartext);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "frmEncryptDecrypt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Passwortverschlüsselung";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtTime;
        internal System.Windows.Forms.Label lblTime;
        internal System.Windows.Forms.TextBox txtDecryptedPw;
        internal System.Windows.Forms.Button btnDecrypt;
        internal System.Windows.Forms.Label lblWurdeKopiert;
        internal System.Windows.Forms.Label lblSprache;
        internal System.Windows.Forms.ComboBox cbLanguage;
        internal System.Windows.Forms.Label lblAES;
        internal System.Windows.Forms.Label lbl3DES;
        internal System.Windows.Forms.TextBox txtAES;
        internal System.Windows.Forms.TextBox txt3DES;
        internal System.Windows.Forms.TextBox txtPlainText;
        internal System.Windows.Forms.Label lblKlartext;
        internal System.Windows.Forms.Button btnEncrypt;
    }
}