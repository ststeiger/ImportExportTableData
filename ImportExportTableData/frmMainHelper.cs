
namespace ImportExportTableData
{


    public partial class frmMain
    {


        public class LargeTable
        {
            public string TableSchema;
            public string TableName;
        }


        public System.Collections.Generic.List<LargeTable> GetLargeFiles()
        {
            System.Collections.Generic.List<LargeTable> ls = new System.Collections.Generic.List<LargeTable>();
            // SQL\MS_SQL\TableSizeInfo.sql

            if (!this.cbWithLobs.Checked)
            {
                // ls.Add(new LargeTable() { TableSchema = "dbo", TableName = "T_File" });
                // ls.Add(new LargeTable() { TableSchema = "dbo", TableName = "T_AP_Dokumente" });
                // ls.Add(new LargeTable() { TableSchema = "dbo", TableName = "T_COR_Log" });
                // ls.Add(new LargeTable() { TableSchema = "dbo", TableName = "T_COR_Error" });
                // ls.Add(new LargeTable() { TableSchema = "dbo", TableName = "T_AP_Raum_History" });

                try
                {
                    ls = JsonHelpers.DeserializeFromJsonFile<System.Collections.Generic.List<LargeTable>>("large_tables.json.txt");
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Minor error trying to load the large_tables.json.txt file: ");
                    System.Console.WriteLine(System.Environment.NewLine);
                    System.Console.WriteLine(ex.Message);
                    // System.Console.WriteLine(ex.StackTrace);
                }

            } // End if (!this.cbWithLobs.Checked) 

            // JsonHelpers.SerializeToFile("large_tables.json.txt", ls);
            return ls;
        } // End Function GetLargeFiles 


        public bool IsLargeTable(System.Collections.Generic.List<LargeTable> lsLargeFiles, string strTableSchema, string strTableName)
        {

            foreach (LargeTable thisLargeTable in lsLargeFiles)
            {
                if (string.Equals(thisLargeTable.TableSchema, strTableSchema, System.StringComparison.InvariantCultureIgnoreCase)
                        && string.Equals(thisLargeTable.TableName, strTableName, System.StringComparison.InvariantCultureIgnoreCase)
                        )
                    return true;

            } // Next thisLargeTable 

            return false;
        } // End Function IsLargeTable 


        public void MsgBox(object obj)
        {
            MsgBox(obj, null);
        } // End Sub MsgBox


        public void MsgBox(object obj, string strTitle)
        {
            if (string.IsNullOrEmpty(strTitle))
            {
                if (obj != null)
                    System.Windows.Forms.MessageBox.Show(obj.ToString());
                else
                    System.Windows.Forms.MessageBox.Show("MsgBox: obj is NULL");
            }
            else
            {
                if (obj != null)
                    System.Windows.Forms.MessageBox.Show(obj.ToString(), strTitle);
                else
                    System.Windows.Forms.MessageBox.Show("MsgBox: obj is NULL", strTitle);
            }
        } // End Sub MsgBox


    } // End partial class frmMain


} // End Namespace ImportExportTableData
