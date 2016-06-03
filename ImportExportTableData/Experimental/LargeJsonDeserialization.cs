
namespace ImportExportTableData
{


    public class LargeJsonDeserialization
    {


        public static void Test()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("PackageID", typeof(int));
            dt.Columns.Add("Amount", typeof(int));
            dt.Columns.Add("Auto_sync", typeof(bool));
            dt.Columns.Add("Color", typeof(string));

            // Comment out these two lines to see the table with no data
            dt.Rows.Add(new object[] { 226, 15000, true, "BLUE" });
            dt.Rows.Add(new object[] { 500, 15000, true, "PEACH" });

            string jsoon = Newtonsoft.Json.JsonConvert.SerializeObject(dt, new ImportExportTableData.CustomDataTableConverter());
            System.Console.WriteLine(jsoon);
            System.Data.DataTable tablee = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(jsoon, new ImportExportTableData.CustomDataTableConverter());
            System.Console.WriteLine(tablee);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dt, new ImportExportTableData.DataTableConverter(null));
            DeserializeTable(json);
            System.Data.DataTable table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>
                (json, new ImportExportTableData.DataTableConverter(null));

            System.Console.WriteLine(table);
        } // End Sub SerializationTest 


        private class JsonFieldInfo
        {
            public string ColumnName;
            public string DataType;


            public JsonFieldInfo()
            {
                this.ColumnName = null;
                this.DataType = null;
            }


            public System.Type DataTypeTypeInfo
            {
                get
                {
                    return System.Type.GetType(this.DataType);
                } // End get 
            } // End Property DataTypeTypeInfo 


            public static object JValueToObject(Newtonsoft.Json.Linq.JValue jobj, System.Type t)
            {
                if (jobj.Value == null)
                {
                    // Warning: This is very wrong...
                    // if (t.IsValueType) return System.Activator.CreateInstance(t);
                    return null;
                }
                object obj = (object)jobj.Value;

                System.Type tt = obj.GetType();
                if (object.ReferenceEquals(t, typeof(System.Guid)) && object.ReferenceEquals(tt, typeof(string)))
                {
                    return new System.Guid(obj.ToString());
                }
                else if (object.ReferenceEquals(t, typeof(byte[])) && object.ReferenceEquals(tt, typeof(string)))
                {
                    byte[] byteArray = System.Convert.FromBase64String(obj.ToString());
                    return (object)byteArray;
                }
                else if (object.ReferenceEquals(t, tt))
                    return obj;

                return System.Convert.ChangeType(obj, t);
            } // End Function JValueToObject 

        } // End Class JsonFieldInfo


        public static void DeserializeTableFromFile(string fileName)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
            {
                DeserializeTable(fs);
            } // End Using fs
        } // End Sub DeserializeTableFromFile 


        public static void DeserializeTable(string json)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                DeserializeTable(ms);
            } // End Using ms
        } // End Sub DeserializeTable 




        private static string ByteToHexBitFiddle(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            int b;
            for (int i = 0; i < bytes.Length; i++)
            {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c);
        } // End Function ByteToHexBitFiddle 


        public static string GetInsertText(object obj)
        {
            if (obj == null || obj == System.DBNull.Value)
                return "NULL";

            System.Type t = obj.GetType();

            if (object.ReferenceEquals(t, typeof(System.DateTime)))
                //return this.Insert_DateTime(obj);
                return "N'" + obj.ToString().Replace("'", "''") + "'";
            
            if (object.ReferenceEquals(t, typeof(byte[])))
                return "0x" + ByteToHexBitFiddle((byte[])obj);

            //return this.Insert_Unicode(obj);
            return "N'" + obj.ToString().Replace("'", "''") + "'";
        } // End Function GetInsertText 


        public static void DeserializeTable(System.IO.Stream fs)
        {
            string tableSchema = "dbo";
            string tableName = "T_Benutzer";

            string strInsert = "INSERT INTO " + tableSchema + "." + tableName + "( \r\n";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();


            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

            JsonFieldInfo[] columnInfo = null;
            int openArrayCounter = 0;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.UTF8))
            {

                using (Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(sr))
                {
                    while (reader.Read())
                    {

                        if (reader.TokenType == Newtonsoft.Json.JsonToken.StartArray)
                        {
                            if (openArrayCounter > 0)
                            {
                                Newtonsoft.Json.Linq.JArray jRow = Newtonsoft.Json.Linq.JArray.Load(reader);

                                // object[] obj = new object[jRow.Count];
                                sb.Append(strInsert);

                                int i = 0;
                                foreach (Newtonsoft.Json.Linq.JToken thisArrayMember in jRow.Children())
                                {
                                    Newtonsoft.Json.Linq.JValue jv = Newtonsoft.Json.Linq.Extensions
                                        .Value<Newtonsoft.Json.Linq.JValue>(thisArrayMember);

                                    try
                                    {
                                        // object objt = JValueToObject(jv, typeof(string));
                                        // System.Console.WriteLine(objt);
                                        // obj[i] = JValueToObject(jv, columnInfo[i].DataTypeTypeInfo);
                                        object obj = JsonFieldInfo.JValueToObject(jv, columnInfo[i].DataTypeTypeInfo);

                                        sb.Append(i == 0 ? " " : ",");
                                        sb.Append(GetInsertText(obj));
                                        
                                        sb.Append(" -- ");
                                        sb.Append(columnInfo[i].ColumnName);
                                        sb.Append("\r\n");

                                    }
                                    catch (System.Exception ex)
                                    {
                                        // System.Console.WriteLine(table.Columns[i].ColumnName);
                                        System.Console.WriteLine(ex.Message);
                                        throw;
                                    }

                                    ++i;
                                } // Next thisArrayMember 

                                sb.Append(");\r\n"); // End Insert Row
                            } // End if (openArrayCounter > 0) 

                            ++openArrayCounter;
                        } // End if (reader.TokenType == Newtonsoft.Json.JsonToken.StartArray) 
                        else if (reader.TokenType == Newtonsoft.Json.JsonToken.EndArray)
                        {
                            openArrayCounter--;
                        }
                        else if (reader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
                        {
                            if (string.Equals(reader.Value, "Columns"))
                            {
                                // public class TableInfo { public System.Collections.Generic.List<JsonFieldInfo> Columns; }
                                // Doesn't work
                                // TableInfo thisRow = serializer.Deserialize<TableInfo>(reader);
                                reader.Read(); // So instead advance to property.Value
                                columnInfo = serializer.Deserialize<JsonFieldInfo[]>(reader);


                                //// Otherwise, without any serialization
                                //Newtonsoft.Json.Linq.JProperty obj = Newtonsoft.Json.Linq.JProperty.Load(reader);
                                //Newtonsoft.Json.Linq.JArray columnsArray = (Newtonsoft.Json.Linq.JArray)obj.Value;

                                //columnInfo = new JsonFieldInfo[columnsArray.Count];
                                //int i = 0;
                                //foreach (Newtonsoft.Json.Linq.JToken thisColumn in columnsArray)
                                //{
                                //    columnInfo[i] = new JsonFieldInfo()
                                //    {
                                //        ColumnName = Newtonsoft.Json.Linq.Extensions.Value<string>(thisColumn.SelectToken("ColumnName")),
                                //        DataType = Newtonsoft.Json.Linq.Extensions.Value<string>(thisColumn.SelectToken("DataType"))
                                //    };

                                //    ++i;
                                //} // Next thisColumn 


                                //System.Console.WriteLine(columnInfo); 
                                for (int i = 0; i < columnInfo.Length; ++i)
                                {
                                    strInsert += (i == 0 ? " " : ",") + columnInfo[i].ColumnName + "\r\n";
                                }
                                strInsert += ") VALUES ( \r\n";

                            } // End if(string.Equals(reader.Value, "Columns")) 

                        } // End if (reader.TokenType == Newtonsoft.Json.JsonToken.PropertyName) 

                    } // Whend 

                    reader.Close();
                } // End Using reader 

            } // End using sr 

            string SQL = sb.ToString();
            System.Console.WriteLine(SQL);
        } // End Sub DeserializeTable 


    } // End Class LargeJsonDeserialization


} // End Namespace ImportExportTableData 
