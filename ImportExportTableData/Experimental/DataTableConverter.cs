
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


// https://github.com/chris-herring/DataTableConverter
// https://raw.githubusercontent.com/chris-herring/DataTableConverter/master/DataTableConverter.cs
// http://weblog.west-wind.com/posts/2008/Sep/03/DataTable-JSON-Serialization-in-JSONNET-and-JavaScriptSerializer
// http://mvitorino.com/2011/05/28/json-net-custom-datatable-serializerconverter/
namespace ImportExportTableData
{

    /// <summary>
    /// Converts a DataTable to JSON. Note no support for deserialization
    /// </summary>
    public class DataTableConverter : JsonConverter
    {
        private DB.Abstraction.cDAL m_DAL;

        private string m_tableSchema;
        private string m_tableName;

        public DataTableConverter(DB.Abstraction.cDAL DAL)
        {
            if (DAL != null)
                m_DAL = DAL;
            else
                m_DAL = GetDAL();

            string tableSchema = "dbo";
            string tableName = "T_Benutzer";
            // string tableName = "T_AP_Dokumente";
            // string tableName = "BAPI_RE_ARCH_OBJECT";

            this.m_tableSchema = tableSchema;
            this.m_tableName = tableName;
        }


        public DB.Abstraction.cDAL GetDAL()
        {
            DB.Abstraction.UniversalConnectionStringBuilder csb = 
                DB.Abstraction.UniversalConnectionStringBuilder.CreateInstance(DB.Abstraction.cDAL.DataBaseEngine_t.MS_SQL);

            csb.IntegratedSecurity = true;

            csb.Server = "CORDB2014";
            csb.DataBase = "P61_CAFM_Basic";
            // csb.DataBase = "COR_Basic_BKB";

            return DB.Abstraction.cDAL.CreateInstance(csb);
        } // End Function GetDAL



        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param><returns>
        ///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(System.Type objectType)
        {
            //Return objectType = GetType(DataTable)
            return typeof(System.Data.DataTable).IsAssignableFrom(objectType);
        }


        
        public static object JValueToObject(Newtonsoft.Json.Linq.JValue jobj, System.Type t)
        {
            if (jobj.Value == null)
            {
                if (t.IsValueType)
                    return System.Activator.CreateInstance(t);
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
                byte[] bte = System.Convert.FromBase64String(obj.ToString());
                return (object)bte;
            }
            else if (object.ReferenceEquals(t, tt))
                return obj;

            return System.Convert.ChangeType(obj, t);
        }


        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param><returns></returns>
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            System.Data.DataTable table = new System.Data.DataTable();

            if (jObject["TableName"] != null)
            {
                table.TableName = jObject["TableName"].ToString();
            }

            if (jObject["Columns"] == null)
                return table;

            // Loop through the columns in the table and apply any properties provided
            foreach (JObject jColumn in jObject["Columns"])
            {
                System.Data.DataColumn column = new System.Data.DataColumn();
                JToken token = default(JToken);

                token = jColumn.SelectToken("ColumnName");
                if (token != null)
                {
                    column.ColumnName = token.Value<string>();
                }

                // Allowed data types: http://msdn.microsoft.com/en-us/library/system.data.datacolumn.datatype.aspx
                token = jColumn.SelectToken("DataType");
                if (token != null)
                {
                    string dataType = token.Value<string>();
                    column.DataType = System.Type.GetType(dataType);
                }

                //token = jColumn.SelectToken("DateTimeMode");
                //if (token != null)
                //{
                //    column.DateTimeMode = (System.Data.DataSetDateTime)
                //        System.Enum.Parse(typeof(System.Data.DataSetDateTime), token.Value<string>());
                //}

                table.Columns.Add(column);
            }

            // Add the rows to the table
            if (jObject["Rows"] != null)
            {
                foreach (JArray jRow in jObject["Rows"])
                {
                    System.Data.DataRow row = table.NewRow();
                    
                    // Each row is just an array of objects
                    // row.ItemArray = jRow.ToObject<object[]>();

                    // Sorry, but .NET does not make it that easy...
                    int i = 0;
                    foreach (Newtonsoft.Json.Linq.JToken thisArrayMember in jRow.Children())
                    {
                        Newtonsoft.Json.Linq.JValue jv = thisArrayMember.Value<Newtonsoft.Json.Linq.JValue>();

                        try
                        {
                            row[i] = JValueToObject(jv, table.Columns[i].DataType);
                            // System.Console.WriteLine(jv);
                        }
                        catch (System.Exception ex)
                        {
                            System.Console.WriteLine(table.Columns[i].ColumnName);
                            System.Console.WriteLine(ex.Message);
                            throw;
                        }

                        ++i;
                    }

                    table.Rows.Add(row);
                }
            }

            return table;
        }

        private static string GetAssemblyQualifiedNoVersionName(System.Type type)
        { 
            if(type == null)
                return null;

            return GetAssemblyQualifiedNoVersionName(type.AssemblyQualifiedName);
        }

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
        }


        public override void WriteJson(Newtonsoft.Json.JsonWriter jsonWriter, object value, Newtonsoft.Json.JsonSerializer ser)
        {
            bool bOmitNullValues = false;
            bool bPrettyPrint = true;

            // WARNING: ISO will not deserialize properly...
            // jsonWriter.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            jsonWriter.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;

            if (bPrettyPrint)
                jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
            else
                jsonWriter.Formatting = Newtonsoft.Json.Formatting.None;


            string str = "SELECT * FROM " + this.m_DAL.QuoteObjectWhereNecessary(this.m_tableSchema) + "."
                + this.m_DAL.QuoteObjectWhereNecessary(this.m_tableName) + " WHERE (1=2); ";

            using (System.Data.DataTable dt = this.m_DAL.GetDataTable(str))
            {
                jsonWriter.WriteStartObject();

                // jsonWriter.WritePropertyName("TableName");
                // jsonWriter.WriteValue(dt.TableName);

                jsonWriter.WritePropertyName("Columns");
                jsonWriter.WriteStartArray();

                foreach (System.Data.DataColumn column in dt.Columns)
                {
                    jsonWriter.WriteStartObject();

                    if (column.ColumnName != null || (column.ColumnName == null && !bOmitNullValues))
                    {
                        jsonWriter.WritePropertyName("ColumnName");
                        jsonWriter.WriteValue(column.ColumnName);

                        jsonWriter.WritePropertyName("DataType");
                        jsonWriter.WriteValue(GetAssemblyQualifiedNoVersionName(column.DataType));
                    } // End if (column.ColumnName != null || (column.ColumnName == null && !bOmitNullValues)) 
                    
                    // jsonWriter.WritePropertyName("DateTimeMode");
                    // jsonWriter.WriteValue(column.DateTimeMode.ToString());

                    jsonWriter.WriteEndObject();
                } // Next column 

                jsonWriter.WriteEndArray();

                jsonWriter.WritePropertyName("Rows");
                jsonWriter.WriteStartArray();


                using (System.Data.Common.DbDataReader dr = this.m_DAL.ExecuteDbReader(
                      "SELECT TOP 100 * FROM " + this.m_DAL.QuoteObject(this.m_tableSchema) + "." + this.m_DAL.QuoteObject(this.m_tableName) + ";"
                    , System.Data.CommandBehavior.SequentialAccess | System.Data.CommandBehavior.CloseConnection))
                {
                    if (dr.HasRows)
                    {
                        int fieldCount = dr.FieldCount;

                        while (dr.Read())
                        {
                            jsonWriter.WriteStartArray();

                            for (int i = 0; i < fieldCount; ++i)
                            {
                                object obj = dr.GetValue(i);
                                jsonWriter.WriteValue(obj);
                            } // Next i

                            jsonWriter.WriteEndArray();
                        } // Whend while (dr.Read())

                    } // End if (dr.HasRows)

                } // End using dr 
                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject();
            } // End Using dt 

        } // End Sub SerializeTableAsJson



    }

}