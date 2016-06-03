
using System.Windows.Forms;


namespace ImportExportTableData
{


    public partial class frmScriptEditor : Form
    {


        public frmScriptEditor()
        {
            InitializeComponent();
        } // End Constructor 


        private void frmScriptEditor_Load(object sender, System.EventArgs e)
        {
            this.txtScriptArea.Text = GetFile("DeleteCmd.sql");
        } // End Sub frmScriptEditor_Load 


        public System.IO.Stream GetEmbeddedFile(string name)
        {
            System.Reflection.Assembly ass = this.GetType().Assembly;
            string resourceName = null;

            foreach (string thisResourceName in ass.GetManifestResourceNames())
            {

                if (thisResourceName.EndsWith(name, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    resourceName = thisResourceName;
                    break;
                } // End if (thisResourceName.EndsWith(name, System.StringComparison.InvariantCultureIgnoreCase)) 

            } // Next thisResourceName

            return ass.GetManifestResourceStream(resourceName);
        } // End Function GetEmbeddedFile 


        public string GetFile(string fileName)
        {
            string retVal = null;

            using (System.IO.Stream strm = GetEmbeddedFile(fileName))
            {
                using(System.IO.StreamReader sr = new System.IO.StreamReader(strm))
                {
                    retVal = sr.ReadToEnd();
                    sr.Close();
                } // End Using xtrReader

                strm.Close();
            } // End Using strm 

            return retVal;
        } // End Function GetFile 


        private void txtScriptArea_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.A)
            {
                if (sender != null)
                    ((System.Windows.Forms.TextBox)sender).SelectAll();
            } // End if (e.Control && e.KeyCode == System.Windows.Forms.Keys.A) 

        } // End Sub txtScriptArea_KeyDown 


    } // End Class frmScriptEditor : Form


} // End Namespace ImportExportTableData
