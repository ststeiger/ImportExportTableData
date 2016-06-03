
using System;


namespace ImportExportTableData
{


    public partial class frmGenerateSQL : System.Windows.Forms.Form
    {


        public frmGenerateSQL()
        {
            InitializeComponent();
        } // End Constructor


        private void btnGenerateSQL_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 1; i < 10; ++i)
            {
                int maxval = 9;
                if (i == 1)
                    maxval = 6;

                maxval++;
                string strFL_Name = "HNF";


                if (i == 7)
                    strFL_Name = "NNF";

                if (i == 8)
                    strFL_Name = "FF";

                if (i == 9)
                    strFL_Name = "VF";

                string str1 = @"
,CASE 
	WHEN T_AP_Ref_NutzungsartGruppe.NAG_Code = " + i.ToString() + @" 
		THEN T_ZO_AP_Raum_Flaeche.ZO_RMFlaeche_Flaeche
	ELSE 0.0
END AS CALC_FL_" + strFL_Name + "_" + i.ToString() + " " + Environment.NewLine + Environment.NewLine;

                //sb.AppendLine(str1);
                //continue;


                string str2 = @"
,CASE 
	WHEN T_AP_Ref_NutzungsartGruppe.NAG_Code = " + i.ToString() + @" 
		THEN 1 
	ELSE 0 
END AS CALC_FL_" + strFL_Name + "_" + i.ToString() + "_Anzahl " + Environment.NewLine + Environment.NewLine;


                //sb.AppendLine(str2);
                //continue;

                
                string str2a = @"
,ROUND(SUM(CALC_FL_" + strFL_Name + "_" + i.ToString() + "), 2) AS CALC_FL_" + strFL_Name + "_" + i.ToString() + " ";

                //sb.Append(str2a);
                //continue;



                string str2b = @"
,SUM(CALC_FL_" + strFL_Name + "_" + i.ToString() + "_Anzahl) AS CALC_FL_" + strFL_Name + "_" + i.ToString() + "_Anzahl ";

                sb.Append(str2b);
                
                // continue;


                for (int j = 1; j < maxval; ++j)
                {
                    string str3 = @"
,
CASE 
	WHEN T_AP_Ref_NutzungsartGruppe.NAG_Code = " + i.ToString() + " AND (CAST(CAST(NA_Code AS float)*10 AS int) % 10) = " + j.ToString() + @"
		THEN T_ZO_AP_Raum_Flaeche.ZO_RMFlaeche_Flaeche
	ELSE 0.0
END AS CALC_FL_" + strFL_Name + "_" + i.ToString() + "_" + j.ToString() + " " + Environment.NewLine + Environment.NewLine;

                    //sb.AppendLine(str3);


                    string str4 = @"
,
CASE 
	WHEN T_AP_Ref_NutzungsartGruppe.NAG_Code = " + i.ToString() + " AND (CAST(CAST(NA_Code AS float)*10 AS int) % 10) = " + j.ToString() + @"
		THEN 1 
	ELSE 0
END AS CALC_FL_" + strFL_Name + "_" + i.ToString() + "_" + j.ToString() + "_Anzahl " + Environment.NewLine + Environment.NewLine;

                    //sb.AppendLine(str4);


                    string str5 = @"
,ROUND(SUM(CALC_FL_"+ strFL_Name + "_" + i.ToString() + "_" + j.ToString() +"), 2) AS CALC_FL_" + strFL_Name + "_" + i.ToString() + "_" + j.ToString() + " ";

                    sb.Append(str5);

                } // Next j
            } // Next i

            this.txtSQLoutput.Text = sb.ToString();

        } // End Sub btnGenerateSQL_Click


        private void txtSQLoutput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A && e.Control)
            {
                this.txtSQLoutput.SelectAll();
            }
        } // End Sub txtSQLoutput_KeyDown


        private void Form2_Load(object sender, EventArgs e)
        {

        } // End Sub Form2_Load


    } // End Class Form2 : Form


} // End Namespace ImportExportTableData
