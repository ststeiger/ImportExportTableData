
namespace ImportExportTableData
{


    static class Program
    {


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [System.STAThread]
        static void Main()
        {

            if (true)
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                // System.Windows.Forms.Application.Run(new frmMain());
                System.Windows.Forms.Application.Run(new frmMainConfidentialityProtected ());
                //Application.Run(new Form2());
            }
            
            // LargeJsonDeserialization.Test();

            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            try
            {
                System.Console.ReadKey();
            }
            catch (System.Exception WhoCaresAboutWinFormsApplications)
            {
                // We (at least I) don't care
                System.Console.WriteLine(WhoCaresAboutWinFormsApplications.Message);
            }
            
        } // End Sub Main


    } // End Class Program


} // End Namespace ImportExportTableData
