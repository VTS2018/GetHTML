#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Security.Cryptography;
#endregion

/*通用函数助手*/
namespace CommonSpace
{
    public enum ExcelVersions
    {
        /// <summary>
        /// Excel8.0版文档格式，适用于Microsoft Excel 8.0 (98-2003) 工作簿
        /// </summary>
        Excel8 = 2003,
        /// <summary>
        /// Excel12.0版文档格式，适用于Microsoft Excel 12.0 (2007) 工作簿
        /// </summary>
        Excel12 = 2007
    }

    public class Conmmon
    {
        #region 功能：用于读取显示txt文件================================

        /// <summary>
        /// 用于读取txt文件显示输出
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        public static void LoadDisText(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            fs.Close();
        }

        public static string[] LoadText(string filePath)
        {
            ArrayList alist = new ArrayList();

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        alist.Add(line);
                    }
                }
                string[] arr = new string[alist.Count];
                for (int i = 0; i < alist.Count; i++)
                {
                    arr[i] = alist[i].ToString();
                }
                return arr;
            }
        }

        /// <summary>
        /// 读取一个文件并返回全部的内容
        /// </summary>
        /// <param name="filePath">文本文件的地址</param>
        /// <returns>文本文件的全部内容</returns>
        public static string ReadTextToend(string filePath)
        {
            String strContent = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                    {
                        strContent = sr.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    fs.Dispose();
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            return strContent;
        }

        #endregion

        #region 功能：读取excel文件获得DataTable=========================

        /// <summary>
        /// 读取excel文件获得DataTable
        /// </summary>
        /// <param name="strExcelFileName">目标Excel文件完全路径</param>
        /// <param name="strSheetName">工作表的名字</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName, ExcelVersions exVersions)
        {
            string ConnectString = string.Empty;
            switch (exVersions)
            {
                case ExcelVersions.Excel8:
                    ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                    break;
                case ExcelVersions.Excel12:
                    ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
                    break;
                default:
                    break;
            }
            string strExcel = "select * from  [" + strSheetName + "$]";
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(ConnectString))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, ConnectString);
                adapter.Fill(ds, strSheetName);
                return ds.Tables[strSheetName];
            }
            #region MyRegion

            //很简单的代码，但是问题就出在连接字符串上面，后面一定要加上Extended Properties='Excel 8.0;HDR=NO;IMEX=1'，HDR和IMEX也一定要配合使用，
            //哈哈,老实说,我也不知道为什么,这样配合的效果最好,这是我艰苦调试的结果.IMEX=1应该是将所有的列全部视为文本,我也有点忘记了.
            //至于HDR本来只是说是否要出现一行标题头而已,但是结果却会导致某些字段值丢失,所以其实我至今也搞不明白为什么,很可能是驱动的问题...
            //IMEX=1 解决数字与字符混合时,识别不正常的情况.
            #endregion
        }
        /// <summary>
        /// 读取excel文件获得DataReader
        /// </summary>
        /// <param name="strExcelFileName"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
        public static OleDbDataReader ExcelToDataReader(string strExcelFileName, string strSheetName)
        {
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
            string strExcel = "select * from  [" + strSheetName + "$]";

            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbCommand cmd = new OleDbCommand(strExcel, conn);
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}