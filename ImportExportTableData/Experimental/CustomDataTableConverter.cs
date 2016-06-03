
namespace ImportExportTableData
{


    class CustomDataTableConverter : Newtonsoft.Json.JsonConverter
    {


        private static string GetAssemblyQualifiedNoVersionName(string input)
        {
            int i = 0;
            bool isNotFirst = false;
            for (; i < input.Length; ++i)
            {
                if (input[i] == ',')
                {
                    if (isNotFirst)
                        break;

                    isNotFirst = true;
                }
            }

            return input.Substring(0, i);
        } // End Function GetAssemblyQualifiedNoVersionName 


        public override bool CanConvert(System.Type objectType)
        {
            return (objectType == typeof(System.Data.DataTable));
        } // End Function CanConvert 


        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.Formatting = Newtonsoft.Json.Formatting.Indented;


            System.Data.DataTable dt = (System.Data.DataTable)value;
            Newtonsoft.Json.Linq.JObject metaDataObj = new Newtonsoft.Json.Linq.JObject();
            foreach (System.Data.DataColumn col in dt.Columns)
            {
                metaDataObj.Add(col.ColumnName, GetAssemblyQualifiedNoVersionName(col.DataType.AssemblyQualifiedName));
            } // Next col 

            Newtonsoft.Json.Linq.JArray rowsArray = new Newtonsoft.Json.Linq.JArray();
            rowsArray.Add(metaDataObj);
            foreach (System.Data.DataRow row in dt.Rows)
            {
                Newtonsoft.Json.Linq.JObject rowDataObj = new Newtonsoft.Json.Linq.JObject();
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    rowDataObj.Add(col.ColumnName, Newtonsoft.Json.Linq.JToken.FromObject(row[col]));
                } // Next col 

                rowsArray.Add(rowDataObj);
            } // Next row

            rowsArray.WriteTo(writer);
        } // End Sub WriteJson 


        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue
            , Newtonsoft.Json.JsonSerializer serializer)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            Newtonsoft.Json.Linq.JArray rowsArray = Newtonsoft.Json.Linq.JArray.Load(reader);
            Newtonsoft.Json.Linq.JObject metaDataObj = (Newtonsoft.Json.Linq.JObject)rowsArray.First;

            foreach (Newtonsoft.Json.Linq.JProperty prop in metaDataObj.Properties())
            {
                dt.Columns.Add(prop.Name, System.Type.GetType((string)prop.Value, throwOnError: true));
            } // Next prop 


            for (int i = 1; i < rowsArray.Count; ++i)
            {
                System.Data.DataRow row = dt.NewRow();

                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    row[col] = rowsArray[i][col.ColumnName].ToObject(col.DataType);
                } // Next col 

                dt.Rows.Add(row);
            } // Next i 

            return dt;
        } // End Function ReadJson 


    } // End Class CustomDataTableConverter : Newtonsoft.Json.JsonConverter


} // End Namespace ImportExportTableData 
