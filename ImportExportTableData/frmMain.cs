
namespace ImportExportTableData
{


    
    public partial class frmMain : System.Windows.Forms.Form
    {
        DB.Abstraction.UniversalConnectionStringBuilder csb;
        DB.Abstraction.cDAL DAL = null;


        public frmMain()
        {
            InitializeComponent();
        } // End Constructor


        public virtual System.Collections.Generic.List<ConnectionInfo> GetMachineConnectionInfoList()
        {
            return null;
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.btnImport.Visible = false;
            this.txtMachineName.Text = System.Environment.MachineName;
            this.txtServer.Text = System.Environment.MachineName;
            this.cbIntegratedSecurity.Checked = true;
            

            System.Collections.Generic.List<string> lsImportMachines = new System.Collections.Generic.List<string>();
            lsImportMachines.Add("COR-W81-101");
            lsImportMachines.Add("COR-W81-102");
            lsImportMachines.Add("COR-W81-103");
            lsImportMachines.Add("COR-W81-104");
            lsImportMachines.Add("COR-W81-105");
            lsImportMachines.Add("COR-W81-106");
            lsImportMachines.Add("COR-W81-107");
            lsImportMachines.Add("COR-W81-108");
            lsImportMachines.Add("COR-W81-109");


            if (ListContains(lsImportMachines, System.Environment.MachineName))
            {
                this.btnImport.Visible = true;
                this.txtLocation.Visible = true;
                this.txtCatalog.Text = "COR_Basic_Wincasa";
                string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                this.txtLocation.Text = System.IO.Path.Combine(dir, "Export_"  + this.txtCatalog.Text);
            } // End if (ListContains(lsImportMachines, Environment.MachineName))

            System.Collections.Generic.List<ConnectionInfo> ls = GetMachineConnectionInfoList();

            if (ls == null || ls.Count == 0)
                return;


            
            int itemCount = 0;
            bool bDefaultNotSet = true;

            foreach (ConnectionInfo ci in ls)
            {
                if (System.StringComparer.InvariantCultureIgnoreCase.Equals(ci.MachineName, System.Environment.MachineName))
                {
                    this.cbSelectDb.Items.Add(ci);
                    if (ci.Default)
                    {
                        if (this.cbSelectDb.Items.Count > 0)
                        {
                            this.cbSelectDb.SelectedIndex = itemCount;
                            bDefaultNotSet = false;
                        }
                            
                    }
                        
                    ++itemCount;
                } // End if (System.StringComparer.InvariantCultureIgnoreCase.Equals(ci.MachineName, System.Environment.MachineName))

            } // Next ci

            if (bDefaultNotSet && this.cbSelectDb.Items.Count > 0)
                this.cbSelectDb.SelectedIndex = 0;
        } // End Sub Form1_Load 


        public DB.Abstraction.cDAL GetDAL()
        {
            csb = DB.Abstraction.UniversalConnectionStringBuilder.CreateInstance(DB.Abstraction.cDAL.DataBaseEngine_t.MS_SQL);
            

            if (this.cbIntegratedSecurity.Checked)
            {
                csb.IntegratedSecurity = true;
            }
            else
            {
                csb.UserName = this.txtUsername.Text;
                
                try
                {
                    csb.Password = DB.Abstraction.Tools.Cryptography.DES.DeCrypt(this.txtPassword.Text);
                }
                catch
                {
                    // DeCrypt fails when password isn't encrypted...
                    csb.Password = this.txtPassword.Text;
                }
                
            }


            csb.Server = this.txtServer.Text;
            csb.DataBase = this.txtCatalog.Text;

            return DB.Abstraction.cDAL.CreateInstance(csb);
        } // End Function GetDAL


        public string GetSaveFileLocation(string strFolder, string strFileName)
        {
            string strDB = csb.DataBase;

            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                strDB = strDB.Replace(c.ToString(), "");
            } // Next c

            strFolder += "_" + strDB;

	        string strPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), strFolder);

	        if ((!System.IO.Directory.Exists(strPath))) 
            {
		        System.IO.Directory.CreateDirectory(strPath);
            } // End if ((!System.IO.Directory.Exists(strPath))) 

            return System.IO.Path.Combine(strPath, strFileName);
        } // End Function GetSaveFileLocation


        public static string StripInvalidPathCharacters(string strFileName)
        {
            string strCleanFileName = "";

            System.Collections.Generic.List<char> ls = new System.Collections.Generic.List<char>();
            ls.AddRange(System.IO.Path.GetInvalidPathChars());
            ls.AddRange(System.IO.Path.GetInvalidFileNameChars());

            foreach (char cThisChar in strFileName)
            {
                if(!ls.Contains(cThisChar))
                    strCleanFileName += cThisChar;
            } // Next cThisChar

            ls.Clear();
            ls = null;

            return strCleanFileName;
        } // End Function StripInvalidPathCharacters


        private void btnExport_Click(object sender, System.EventArgs e)
        {
            Export();
        } // End Sub btnExport_Click


        private void Export()
        {
            DAL = null;
            DAL = GetDAL();


            string strCreateDb = DAL.DatabaseCreateScript(this.txtCatalog.Text, this.txtCatalog.Text);
            string strSaveFileLocation = GetSaveFileLocation("Data", "CreateDB_" + StripInvalidPathCharacters(this.txtCatalog.Text) + ".sql");
            System.IO.File.WriteAllText(strSaveFileLocation, strCreateDb);

            this.dgvDisplayData.DataSource = DAL.GetTables().DefaultView;


            System.Collections.Generic.List<LargeTable> lsLargeFiles = this.GetLargeFiles();

            //DB.Abstraction.cDAL.SerializationFormat_t serializationFormat = DB.Abstraction.cDAL.SerializationFormat_t.XML;
            DB.Abstraction.cDAL.SerializationFormat_t serializationFormat = DB.Abstraction.cDAL.SerializationFormat_t.JSON;

            string exportFileExtension = "." + serializationFormat.ToString().ToLowerInvariant();
            
            foreach (System.Data.DataRow drThisRow in DAL.GetTables().Rows)
            {
                string strTableSchema = drThisRow["TABLE_SCHEMA"].ToString();
                string strTableName = drThisRow["TABLE_NAME"].ToString();

                try
                {
                    if (IsLargeTable(lsLargeFiles, strTableSchema, strTableName)) 
                        continue;

                    DAL.SerializeTable(serializationFormat
                        , GetSaveFileLocation("Data", strTableName + exportFileExtension)
                        , strTableSchema, strTableName
                    );

                    /*
                    using (System.Data.DataTable dt = DAL.GetEntireTable(strTableSchema, strTableName, this.cbSortExport.Checked))
                    {
                        //MsgBox(dt.Rows.Count);
                        dt.TableName = strTableName;

                        //dt.WriteXml(@"c:\temp\testxml.xml");
                        //dt.WriteXml(@"c:\temp\testxml.xml", System.Data.XmlWriteMode.WriteSchema, false);
                        //dt.WriteXml(stringWriter, System.Data.XmlWriteMode.WriteSchema, false);

                        // JsonHelpers.SerializeToFile(GetSaveFileLocation("Data", strTablename + ".json"), dt);
                        dt.WriteXml(GetSaveFileLocation("Data", strTablename + ".xml"), System.Data.XmlWriteMode.WriteSchema, false);

                        //Real-life example:
                        //JSON:
                        //  - plain:  1.04 GB
                        //  - rar:   82.6  MB
                        //  - zip:  142    MB (122 MB WinRar zipped) 


                        //XML:
                        //  - plain: 1.36 GB
                        //  - rar:  86.9  MB
                        //  - zip: 153    MB (129 MB WinRar zipped)
                    } // End Using dt
                    */

                } // End Try
                catch (System.Exception ex)
                {
                    MsgBox("Error exporting data for " + strTableName + ": " + ex.Message);
                } // End Catch

            } // Next drThisRow

            

            if (this.cbCompress.Checked)
            {
                if (this.cbSelfExtract.Checked)
                    CreateSelfExtractZipFile();
                else
                    CreateZipFile();
            } // End if (this.cbCompress.Checked)
            
            MsgBox("Fertig");
        } // End Sub Export


        protected void CreateZipFile()
        {
            //DAL = null;
            //DAL = GetDAL();

            string ZipFileToCreate = System.IO.Path.Combine(System.IO.Directory.GetParent(GetSaveFileLocation("Data", "")).FullName, new System.IO.DirectoryInfo(GetSaveFileLocation("Data", "")).Name + ".zip");

            if (System.IO.File.Exists(ZipFileToCreate))
            {
                MsgBox("ZIP file already exists - please remove it and rerun, or ZIP it manually");
                return;
            } // End if (System.IO.File.Exists(ZipFileToCreate))

            string DirectoryToZip = GetSaveFileLocation("Data", "");

            try
            {

                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    zip.Comment = "This will be embedded into a self-extracting console-based exe";
                    //zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    //zip.Password = "foobar";
                    //zip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256;
                    zip.Save(ZipFileToCreate);
                } // End Using zip
            } // End Try
            catch (System.Exception ex)
            {
                MsgBox("Exception Zipping files: " + System.Environment.NewLine + ex.Message);
            } // End Catch

        } // End Sub CreateZipFile


        protected void CreateSelfExtractZipFile()
        {
            //DAL = null;
            //DAL = GetDAL();

            string ZipFileToCreate = System.IO.Path.Combine(System.IO.Directory.GetParent(GetSaveFileLocation("Data", "")).FullName, new System.IO.DirectoryInfo(GetSaveFileLocation("Data", "")).Name + ".zip");

            if (System.IO.File.Exists(ZipFileToCreate))
            {
                MsgBox("ZIP file already exists - please remove it and rerun, or ZIP it manually");
                return;
            } // End if (System.IO.File.Exists(ZipFileToCreate))

            string DirectoryToZip = GetSaveFileLocation("Data", "");

            try
            {

                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    zip.Comment = "This will be embedded into a self-extracting console-based exe";
                    //zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    //zip.Password = "foobar";
                    //zip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256;
                    //zip.Save(ZipFileToCreate);


                    Ionic.Zip.SelfExtractorSaveOptions options = new Ionic.Zip.SelfExtractorSaveOptions();
                    options.Flavor = Ionic.Zip.SelfExtractorFlavor.ConsoleApplication;
                    //options.DefaultExtractDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), System.IO.Directory.GetParent(ZipFileToCreate).Name);
                    options.DefaultExtractDirectory = "%TEMP%";
                    options.ExtractExistingFile = Ionic.Zip.ExtractExistingFileAction.OverwriteSilently;

                    // http://dotnetzip.codeplex.com/workitem/10682
                    //options.IconFile = System.IO.Path.Combine(Application.StartupPath, "box_software.ico");
                    //options.PostExtractCommandLine = "putty.exe";
                    //options.Quiet = true;
                    //options.RemoveUnpackedFilesAfterExecute = true;

                    zip.SaveSelfExtractor(System.IO.Path.ChangeExtension(ZipFileToCreate, ".exe"), options);
                } // End Using zip
            } // End Try
            catch (System.Exception ex)
            {
                MsgBox("Exception Zipping files: " + System.Environment.NewLine + ex.Message);
            } // End Catch

        } // End Sub CreateSelfExtractZipFile


        private void btnImport_Click(object sender, System.EventArgs e)
        {
            Import();
        } // End Sub btnImport_Click


        private void Import()
        {
            DAL = null;
            DAL = GetDAL();

            string strPath = this.txtLocation.Text;
            string strSQL = DAL.GetEmbeddedSQLscript("foreign_key_dependencies.sql");
            System.Data.DataTable dtTablesToImport = DAL.GetDataTable(strSQL);

            System.Collections.Generic.List<LargeTable> lsLargeFiles = this.GetLargeFiles();


            string strFileName = null;

            foreach (System.Data.DataRow dr in dtTablesToImport.Rows)
            {

                try
                {
                    string strTableSchema = System.Convert.ToString(dr["TableSchema"]);
                    string strTableName = System.Convert.ToString(dr["TableName"]);

                    if (IsLargeTable(lsLargeFiles, strTableSchema, strTableName))
                        continue;


                    // Import JSON Format 
                    {
                        strFileName = System.IO.Path.Combine(strPath, strTableName + ".json");
                        if (System.IO.File.Exists(strFileName))
                        {
                            DAL.InsertJSONFromFile(strTableSchema, strTableName, strFileName);

                            /*
                            using (System.Data.DataTable dt = JsonHelpers.DeserializeFromJsonFile<System.Data.DataTable>(strFileName))
                            {
                                DAL.DebugBulkCopy(strTableSchema, strTableName, dt, true);
                                //DAL.BulkCopy(strTableSchema, strTableName, dt, true);
                            } // End Using dt
                             */
                        } // End if (System.IO.File.Exists(strFileName))
                    }


                    // Import XML Format 
                    {
                        strFileName = System.IO.Path.Combine(strPath, strTableName + ".xml");
                        if (System.IO.File.Exists(strFileName))
                        {
                            using (System.Data.DataTable dt = new System.Data.DataTable())
                            {
                                dt.ReadXml(strFileName);
                                //this.dgvDisplayData.DataSource = dt.DefaultView;
                                DAL.BulkCopy(strTableSchema, strTableName, dt, true);
                            } // End Using dt
                        } // End if (System.IO.File.Exists(strFileName))
                    }
                    

                } // End Try
                catch (System.Exception ex)
                {
                    MsgBox(ex.Message, strFileName);
                } // End Catch

            } // Next dr

            MsgBox("Fertig");
        } // End Sub Import


        public bool ListContains(System.Collections.Generic.List<string> ls, string str)
        {
            foreach (string strThisString in ls)
            {
                if (System.StringComparer.OrdinalIgnoreCase.Equals(strThisString, str))
                    return true;
            } // Next strThisString

            return false;
        } // End Function ListContains


        private void cbCompress_CheckedChanged(object sender, System.EventArgs e)
        {
            cbSelfExtract.Visible = !cbSelfExtract.Visible;
        } // End Sub cbCompress_CheckedChanged 


        private void btnEncrypt_Click(object sender, System.EventArgs e)
        {

            using (frmEncryptDecrypt frm = new frmEncryptDecrypt())
            {
                frm.ShowDialog();
            } // End Using frm 
            
        } // End Sub btnEncrypt_Click 


        private void cbSelectDb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;
            ConnectionInfo ci = (ConnectionInfo)cb.SelectedItem;

            this.txtServer.Text = ci.ServerInstance;
            this.txtCatalog.Text = ci.InitialCatalog;
            this.txtLocation.Text = ci.ImportFolder;

            if (ci.IntegratedSecurity)
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                this.cbIntegratedSecurity.Checked = true;
            }
            else
            {
                this.txtUsername.Text = ci.UserId;
                this.txtPassword.Text = ci.Password;
                this.cbIntegratedSecurity.Checked = false;
            }

        } // End Sub cbSelectDb_SelectedIndexChanged 


        private void cbDisplayImportButton_CheckedChanged(object sender, System.EventArgs e)
        {
            this.btnImport.Visible = this.cbDisplayImportButton.Checked;
        } // End Sub cbDisplayImportButton_CheckedChanged 


        private void cbIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
        {
            this.lblUserName.Visible = !this.cbIntegratedSecurity.Checked;
            this.lblPassword.Visible = !this.cbIntegratedSecurity.Checked;

            this.txtUsername.Visible = !this.cbIntegratedSecurity.Checked;
            this.txtPassword.Visible = !this.cbIntegratedSecurity.Checked;
        } // End Sub cbIntegratedSecurity_CheckedChanged 


        private void txtMachineName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.A)
            {
                if (sender != null)
                    ((System.Windows.Forms.TextBox)sender).SelectAll();
            } // End if (e.Control && e.KeyCode == System.Windows.Forms.Keys.A) 

        } // End Sub txtMachineName_KeyDown 


        private void FileExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        } // End Sub FileExitToolStripMenuItem_Click 


        private void HelpAboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            MsgBox("Copyright © 2010-"
                + System.DateTime.Now.Year.ToString(System.Globalization.CultureInfo.InvariantCulture)
                + " Stefan Steiger" + System.Environment.NewLine 
                + "All rights reserved."
            );
        } // End Sub HelpAboutToolStripMenuItem_Click 


        private void HelpDisplayDeleteScriptToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmScriptEditor editor = new frmScriptEditor();
            editor.ShowDialog();
            editor.Close();
        } // End Sub HelpDisplayDeleteScriptToolStripMenuItem_Click 


    } // End Class frmMain : Form


} // End Namespace ImportExportTableData
