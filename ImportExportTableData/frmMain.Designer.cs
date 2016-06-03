namespace ImportExportTableData
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvDisplayData = new System.Windows.Forms.DataGridView();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cbIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInitialCatalog = new System.Windows.Forms.Label();
            this.cbCompress = new System.Windows.Forms.CheckBox();
            this.cbSelfExtract = new System.Windows.Forms.CheckBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.cbSelectDb = new System.Windows.Forms.ComboBox();
            this.cbDisplayImportButton = new System.Windows.Forms.CheckBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.cbSortExport = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteScript = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpDisplayDeleteScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbWithLobs = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 533);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(93, 533);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvDisplayData
            // 
            this.dgvDisplayData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplayData.Location = new System.Drawing.Point(12, 39);
            this.dgvDisplayData.Name = "dgvDisplayData";
            this.dgvDisplayData.Size = new System.Drawing.Size(639, 334);
            this.dgvDisplayData.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(12, 503);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(639, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // cbIntegratedSecurity
            // 
            this.cbIntegratedSecurity.AutoSize = true;
            this.cbIntegratedSecurity.Location = new System.Drawing.Point(383, 417);
            this.cbIntegratedSecurity.Name = "cbIntegratedSecurity";
            this.cbIntegratedSecurity.Size = new System.Drawing.Size(115, 17);
            this.cbIntegratedSecurity.TabIndex = 4;
            this.cbIntegratedSecurity.Text = "Integrated Security";
            this.cbIntegratedSecurity.UseVisualStyleBackColor = true;
            this.cbIntegratedSecurity.CheckedChanged += new System.EventHandler(this.cbIntegratedSecurity_CheckedChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(423, 443);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(228, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(423, 469);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(362, 446);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(364, 473);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(93, 443);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(220, 20);
            this.txtServer.TabIndex = 9;
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(93, 469);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(220, 20);
            this.txtCatalog.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server";
            // 
            // lblInitialCatalog
            // 
            this.lblInitialCatalog.AutoSize = true;
            this.lblInitialCatalog.Location = new System.Drawing.Point(14, 473);
            this.lblInitialCatalog.Name = "lblInitialCatalog";
            this.lblInitialCatalog.Size = new System.Drawing.Size(73, 13);
            this.lblInitialCatalog.TabIndex = 12;
            this.lblInitialCatalog.Text = "Intitial Catalog";
            // 
            // cbCompress
            // 
            this.cbCompress.AutoSize = true;
            this.cbCompress.Checked = true;
            this.cbCompress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCompress.Location = new System.Drawing.Point(96, 417);
            this.cbCompress.Name = "cbCompress";
            this.cbCompress.Size = new System.Drawing.Size(111, 17);
            this.cbCompress.TabIndex = 13;
            this.cbCompress.Text = "Data compression";
            this.cbCompress.UseVisualStyleBackColor = true;
            this.cbCompress.CheckedChanged += new System.EventHandler(this.cbCompress_CheckedChanged);
            // 
            // cbSelfExtract
            // 
            this.cbSelfExtract.AutoSize = true;
            this.cbSelfExtract.Location = new System.Drawing.Point(213, 417);
            this.cbSelfExtract.Name = "cbSelfExtract";
            this.cbSelfExtract.Size = new System.Drawing.Size(79, 17);
            this.cbSelfExtract.TabIndex = 14;
            this.cbSelfExtract.Text = "Self-extract";
            this.cbSelfExtract.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(576, 533);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 17;
            this.btnEncrypt.Text = "Encryption";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // cbSelectDb
            // 
            this.cbSelectDb.FormattingEnabled = true;
            this.cbSelectDb.Location = new System.Drawing.Point(365, 383);
            this.cbSelectDb.Name = "cbSelectDb";
            this.cbSelectDb.Size = new System.Drawing.Size(286, 21);
            this.cbSelectDb.TabIndex = 18;
            this.cbSelectDb.SelectedIndexChanged += new System.EventHandler(this.cbSelectDb_SelectedIndexChanged);
            // 
            // cbDisplayImportButton
            // 
            this.cbDisplayImportButton.AutoSize = true;
            this.cbDisplayImportButton.Location = new System.Drawing.Point(525, 418);
            this.cbDisplayImportButton.Name = "cbDisplayImportButton";
            this.cbDisplayImportButton.Size = new System.Drawing.Size(126, 17);
            this.cbDisplayImportButton.TabIndex = 19;
            this.cbDisplayImportButton.Text = "Display Import Button";
            this.cbDisplayImportButton.UseVisualStyleBackColor = true;
            this.cbDisplayImportButton.CheckedChanged += new System.EventHandler(this.cbDisplayImportButton_CheckedChanged);
            // 
            // txtMachineName
            // 
            this.txtMachineName.BackColor = System.Drawing.SystemColors.Info;
            this.txtMachineName.Location = new System.Drawing.Point(93, 383);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.ReadOnly = true;
            this.txtMachineName.Size = new System.Drawing.Size(220, 20);
            this.txtMachineName.TabIndex = 20;
            this.txtMachineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMachineName_KeyDown);
            // 
            // cbSortExport
            // 
            this.cbSortExport.AutoSize = true;
            this.cbSortExport.Location = new System.Drawing.Point(15, 417);
            this.cbSortExport.Name = "cbSortExport";
            this.cbSortExport.Size = new System.Drawing.Size(78, 17);
            this.cbSortExport.TabIndex = 21;
            this.cbSortExport.Text = "Sort Export";
            this.cbSortExport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "MachineName";
            // 
            // btnDeleteScript
            // 
            this.btnDeleteScript.Location = new System.Drawing.Point(457, 533);
            this.btnDeleteScript.Name = "btnDeleteScript";
            this.btnDeleteScript.Size = new System.Drawing.Size(113, 23);
            this.btnDeleteScript.TabIndex = 23;
            this.btnDeleteScript.Text = "Display Delete Script";
            this.btnDeleteScript.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(725, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(725, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExitToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dateiToolStripMenuItem.Text = "&File";
            // 
            // FileExitToolStripMenuItem
            // 
            this.FileExitToolStripMenuItem.Name = "FileExitToolStripMenuItem";
            this.FileExitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.FileExitToolStripMenuItem.Text = "&Exit";
            this.FileExitToolStripMenuItem.Click += new System.EventHandler(this.FileExitToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpDisplayDeleteScriptToolStripMenuItem,
            this.HelpAboutToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Help";
            // 
            // HelpDisplayDeleteScriptToolStripMenuItem
            // 
            this.HelpDisplayDeleteScriptToolStripMenuItem.Name = "HelpDisplayDeleteScriptToolStripMenuItem";
            this.HelpDisplayDeleteScriptToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.HelpDisplayDeleteScriptToolStripMenuItem.Text = "Display Delete Script";
            this.HelpDisplayDeleteScriptToolStripMenuItem.Click += new System.EventHandler(this.HelpDisplayDeleteScriptToolStripMenuItem_Click);
            // 
            // HelpAboutToolStripMenuItem
            // 
            this.HelpAboutToolStripMenuItem.Name = "HelpAboutToolStripMenuItem";
            this.HelpAboutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.HelpAboutToolStripMenuItem.Text = "&About";
            this.HelpAboutToolStripMenuItem.Click += new System.EventHandler(this.HelpAboutToolStripMenuItem_Click);
            // 
            // cbWithLobs
            // 
            this.cbWithLobs.AutoSize = true;
            this.cbWithLobs.Location = new System.Drawing.Point(298, 417);
            this.cbWithLobs.Name = "cbWithLobs";
            this.cbWithLobs.Size = new System.Drawing.Size(74, 17);
            this.cbWithLobs.TabIndex = 26;
            this.cbWithLobs.Text = "with LOBs";
            this.cbWithLobs.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 585);
            this.Controls.Add(this.cbWithLobs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnDeleteScript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSortExport);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.cbDisplayImportButton);
            this.Controls.Add(this.cbSelectDb);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.cbSelfExtract);
            this.Controls.Add(this.cbCompress);
            this.Controls.Add(this.lblInitialCatalog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCatalog);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.cbIntegratedSecurity);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.dgvDisplayData);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvDisplayData;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.CheckBox cbIntegratedSecurity;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInitialCatalog;
        private System.Windows.Forms.CheckBox cbCompress;
        private System.Windows.Forms.CheckBox cbSelfExtract;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.ComboBox cbSelectDb;
        private System.Windows.Forms.CheckBox cbDisplayImportButton;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.CheckBox cbSortExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteScript;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpDisplayDeleteScriptToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbWithLobs;
    }
}

