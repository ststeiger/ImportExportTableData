
namespace ImportExportTableData
{


    public class ConnectionInfo
    {
        public string MachineName;
        public string ServerInstance;
        public string InitialCatalog;
        public bool IntegratedSecurity;
        public string UserId;
        public string Password;
        public string Remark;
        public bool Default;


        public override string ToString()
        {
            return ServerInstance + "==> " + InitialCatalog;
        } // End Function ToString 


        public string ImportFolder
        {
            get
            {

                string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

                return System.IO.Path.Combine(dir, this.InitialCatalog);
            } // End Get
        } // End Property ImportFolder 


    } // End Class ConnectionInfo 


} // End Namespace ImportExportTableData
