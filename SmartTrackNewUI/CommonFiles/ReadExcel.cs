
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace SmartTrack_Automation
{
  //  [TestClass]
    public class ReadExcel
    {

        public const string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=<FILENAME>;Extended Properties=\"Excel 12.0;HDR=Yes;\";";

        //public Result WriteDataToExcelFile(string fullFileName, string strWriteSqlQuery)
        public Result WriteDataToExcelFile(string fullFileName, string[] strColArray, string[] strDataArray, string RunCount, string NumberOfRepeats, string Result,string Comments)
        {
            //CommonMethods.Result
            var results = new Result();
            OleDbConnection objConnection = new OleDbConnection();
            objConnection = new OleDbConnection(CONNECTION_STRING.Replace("<FILENAME>", fullFileName));
           // Console.WriteLine("write data to excel pass1");
           // Console.WriteLine(strArray[0] + "," + strArray[1]);
           // string[] strArray;
            string strSQLInsert = "";
            string strSQLInsertValue = "";
          //  Console.WriteLine(strColArray.Length);
           
            try
            {
                objConnection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {

                    command.Connection = objConnection;
                    for (int z = 0; z < strColArray.Length; z++)
                    {
                        if (strColArray[z].ToString() != "")
                        {
                            if (strSQLInsert == "")
                            {
                                strSQLInsert = strColArray[z].ToString();
                                strSQLInsertValue = "?";
                            }
                            else
                            {
                                strSQLInsert = strSQLInsert + "," + strColArray[z].ToString();
                                strSQLInsertValue = strSQLInsertValue + ",?";
                            }
                        }

                    }
                    strSQLInsert = strSQLInsert + ",RunCount,NumberOfRepeats,Result,Comments,Comments1";
                    strSQLInsertValue = strSQLInsertValue + ",?,?,?,?,?";
                    
                    string insertStatement = "INSERT INTO [Sheet1$]("+strSQLInsert+") VALUES ("+strSQLInsertValue+")";
                    command.CommandText = insertStatement;


                    for (int z = 0; z < strColArray.Length; z++)
                    {
                        if (strColArray[z].ToString() != "")
                        {
                            command.Parameters.AddWithValue(strColArray[z].ToString(), strDataArray[z].ToString());
                        }

                    }
                    
                    command.Parameters.AddWithValue("RunCount", RunCount);
                    command.Parameters.AddWithValue("NumberOfRepeats", NumberOfRepeats);
                    command.Parameters.AddWithValue("Result", Result);
                    if (Comments.Length > 254)
                    {
                       // Console.WriteLine(Comments.Length);
                       // Console.WriteLine(Comments.Substring(0,255));
                      //  Console.WriteLine(Comments.Substring(255, Comments.Length -255));
                        command.Parameters.AddWithValue("Comments", Comments.Substring(0, 255));
                        command.Parameters.AddWithValue("Comments1", Comments.Substring(255, Comments.Length - 255));

                    }
                    else
                    {
                       // Console.WriteLine("Comments.Length");
                        command.Parameters.AddWithValue("Comments", Comments);
                        command.Parameters.AddWithValue("Comments1", "");
                    }
                    


                    command.ExecuteNonQuery();
                  //  Console.WriteLine("write data to excel pass2");
                   
                }

            }
            catch (Exception wr)
            {
               // Console.WriteLine("write data to excel error");
              //  Console.WriteLine(wr.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = wr.Message;
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
                return results;
                //raise exception if needed
            }
            finally
            {
                // Clean up.
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "";
            return results;

        }

        public Result WriteDataToExcelFileSelected(string fullFileName, string strSheetName, string[] strColArray, string[] strDataArray)
        {
            //CommonMethods.Result
            var results = new Result();
            OleDbConnection objConnection = new OleDbConnection();
            objConnection = new OleDbConnection(CONNECTION_STRING.Replace("<FILENAME>", fullFileName));
            // Console.WriteLine("write data to excel pass1");
            // Console.WriteLine(strArray[0] + "," + strArray[1]);
            // string[] strArray;
            string strSQLInsert = "";
            string strSQLInsertValue = "";
            //  Console.WriteLine(strColArray.Length);

            try
            {
                objConnection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {

                    command.Connection = objConnection;
                    for (int z = 0; z <= strColArray.Length - 1; z++)
                    {
                        if (strColArray[z].ToString() != "")
                        {
                            if (strSQLInsert == "")
                            {
                                strSQLInsert = strColArray[z].ToString();
                                strSQLInsertValue = "?";
                            }
                            else
                            {
                                strSQLInsert = strSQLInsert + "," + strColArray[z].ToString();
                                strSQLInsertValue = strSQLInsertValue + ",?";
                            }
                        }

                    }
                    //    strSQLInsert = strSQLInsert + ",RunCount,NumberOfRepeats,Result,Comments,Comments1";
                    //    strSQLInsertValue = strSQLInsertValue + ",?,?,?,?,?";

                    string insertStatement = "INSERT INTO [" + strSheetName + "$](" + strSQLInsert + ") VALUES (" + strSQLInsertValue + ")";
                    command.CommandText = insertStatement;


                    for (int z = 0; z < strColArray.Length ; z++)
                    {
                        if (strColArray[z].ToString() != "")
                        {
                            command.Parameters.AddWithValue(strColArray[z].ToString(), strDataArray[z].ToString());
                          //  Console.WriteLine(strColArray[z].ToString());
                         //   Console.WriteLine(strDataArray[z].ToString());
                        }
            

                    }

                    command.ExecuteNonQuery();
                    // Console.WriteLine("write data to excel pass2");

                }

            }
            catch (Exception wr)
            {
                //  Console.WriteLine("write data to excel error");
                //  Console.WriteLine(wr.Message);
                results.Result1 = KeyWords.Result_FAIL;
                results.ErrorMessage = wr.Message;
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
                return results;
                //raise exception if needed
            }
            finally
            {
                // Clean up.
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
            results.Result1 = KeyWords.Result_PASS;
            results.ErrorMessage = "";
            return results;

        }
   
        public Result GetDataTableFromExcelFile(string fullFileName, string sheetName, string strSqlQuery)
        {
            var results = new Result();
            OleDbConnection objConnection = new OleDbConnection();
            string replaceing = CONNECTION_STRING.Replace("<FILENAME>", fullFileName);
            objConnection = new OleDbConnection(replaceing);
            DataSet dsImport = new DataSet();
            DataTable dt;
           // Console.WriteLine("Pass1");
            try
            {
               // Console.WriteLine("Pass2");
                objConnection.Open();
              //  Console.WriteLine("Pass12");
                //objConnection.CreateObjRef( 
                DataTable dtSchema = objConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if ((null == dtSchema) || (dtSchema.Rows.Count <= 0))
                {
                    //raise exception if needed
                    results.Result1 = "Fail";
                    results.ErrorMessage = "Given input file some problem Input.xlsx";
                    return results;

                }

                if ((null != sheetName) && (0 != sheetName.Length))
                {
                    if (!CheckIfSheetNameExists(sheetName, dtSchema))
                    {
                        //raise exception if needed
                        results.Result1 = "Fail";
                        results.ErrorMessage = sheetName + " Sheet name not find in given Input.xls";
                        return results;
                    }
                }
                else
                {
                    //Reading the first sheet name from the Excel file.
                    sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                }

                new OleDbDataAdapter(strSqlQuery, objConnection).Fill(dsImport);

            }
            catch (Exception ExReadData)
            {
                //raise exception if needed
                results.Result1 = "Fail";
                results.ErrorMessage = ExReadData.Message;
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
                return results;
            }
            finally
            {
                // Clean up.
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
            try
            {
                dt = dsImport.Tables[0];
                results.Result1 = "Pass";
                results.ErrorMessage = "";
                results.dt = dt;
            }
            catch (Exception ExImportData)
            {
                //raise exception if needed
                results.Result1 = "Fail";
                results.ErrorMessage = ExImportData.Message;
                throw ExImportData;
            }
            
            
            return results;

        }

        /// <summary>
        /// This method checks if the user entered sheetName exists in the Schema Table
        /// </summary>
        /// <param name="sheetName">Sheet name to be verified</param>
        /// <param name="dtSchema">schema table </param>
        private static bool CheckIfSheetNameExists(string sheetName, DataTable dtSchema)
        {
           // Console.WriteLine("testsheetname");
            //dtSchema.WriteXmlSchema("testsheetname");
            //dtSchema.
            foreach (DataRow dataRow in dtSchema.Rows)
            {
                if (sheetName == dataRow["TABLE_NAME"].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public Result UpdateDataToExcelFile(string fullFileName, string strSqlQuery)
        {
            //CommonMethods.Result
            var results = new Result();
            OleDbConnection objConnection = new OleDbConnection();
            objConnection = new OleDbConnection(CONNECTION_STRING.Replace("<FILENAME>", fullFileName));
         //   Console.WriteLine("write data to excel pass1");
           
            

            try
            {
                objConnection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {

                    command.Connection = objConnection;

                    //sql = "Update [Sheet1$] set name = 'New Name' where id=1";
                   // Console.WriteLine(strSqlQuery);
                    command.CommandText = strSqlQuery;
                    command.ExecuteNonQuery();
                  //  Console.WriteLine("write data to excel pass2");

                }

            }
            catch (Exception wr)
            {
               //// Console.WriteLine("write data to excel pass3");
               // Console.WriteLine(wr.Message);
                results.Result1 = "Fail";
                results.ErrorMessage = wr.Message;
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
                return results;
                //raise exception if needed
            }
            finally
            {
                // Clean up.
                if (objConnection != null)
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
            results.Result1 = "Pass";
            results.ErrorMessage = "";
            return results;

        }

    }
}
