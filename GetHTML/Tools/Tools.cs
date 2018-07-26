using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace GetHTML
{
    public class Tools
    {
        /// <summary>
        /// 设置页面按钮的提示情况
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="message"></param>
        public static void SetTip(Control cl, string message)
        {
            ToolTip tp = new ToolTip();
            tp.ShowAlways = true;
            tp.SetToolTip(cl, message);
        }

        /// <summary>
        /// 文件对话框设置函数部分
        /// </summary>
        /// <param name="ofd"></param>
        /// <param name="strFilter"></param>
        /// <returns></returns>
        public static string GetFilePath(OpenFileDialog ofd, string strFilter)
        {
            OpenFileDialog ofdExcel = new OpenFileDialog();
            ofdExcel.Filter = strFilter;
            ofdExcel.AddExtension = true;
            //ofdExcel.InitialDirectory = strTxtpath;
            string strexcelPath = string.Empty;
            if (ofdExcel.ShowDialog() == DialogResult.OK)
            {
                strexcelPath = ofdExcel.FileName;
            }
            return strexcelPath;
        }

        /// <summary>
        /// 加载文本数据部分 .txt格式
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> GetkeyWords(string filePath)
        {
            List<string> list = new List<string>();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            list.Add(line.Trim());//去空处理
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            fs.Close();
            return list;
        }








        /// <summary>
        /// 分割关键词“|”
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string[] SplitString(string strInput)
        {
            string[] arrResult;
            if (!string.IsNullOrEmpty(strInput))
            {
                if (strInput.Contains("|"))
                {
                    string[] arr = strInput.Split('|');
                    arrResult = new string[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arrResult[i] = arr[i].Trim();
                    }
                }
                else
                {
                    //直接返回该关键词
                    arrResult = new string[1];
                    arrResult[0] = strInput.Trim();
                }
            }
            else
            {
                arrResult = new string[] { " " };
            }
            return arrResult;
        }

        /// <summary>
        /// 插入逗号
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string InserChar(string strInput)
        {
            //char[] arr = Array.Reverse(strInput.ToCharArray());
            string str = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                for (int i = 0; i < strInput.Length; i++)
                {
                    str += strInput[i].ToString();
                    if (i % 3 == 0)
                    {
                        str += ",";
                    }
                }
                //for (int i = strInput.Length - 1; i >= 0; i--)
                //{
                //    str += strInput[i].ToString();
                //    if (i % 3 == 0)
                //    {
                //        str += ",";
                //    }
                //}
            }
            return str;
        }


        /// <summary>
        /// 获得搜索量
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        public static string Google_getProductNum(string strURL)
        {
            int n = strURL.IndexOf("<div id=\"resultStats\">");
            if (n == -1)
            {
                return string.Empty;
            }
            string buf = string.Empty;
            try
            {
                buf = GetNumber(strURL.Substring(n, 60));
            }
            catch (Exception x)
            {
                buf = x.Message.ToString();
            }
            return buf;
        }



        /// <summary>
        /// 解析出字符串中的数字
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string GetNumber(string strInput)
        {
            StringBuilder sbr = new StringBuilder();
            if (strInput != "" && strInput != null)
            {
                char[] achar = strInput.ToCharArray();

                foreach (char item in achar)
                {
                    if (char.IsDigit(item))
                    {
                        sbr.Append(item.ToString());
                    }
                }
            }
            return sbr.ToString();
        }

        /// <summary>
        /// 处理关键字中空格字符
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string GetString(string strInput)
        {
            return strInput.Replace(" ", "+").Replace("/", "%2F");
        }

        /// <summary>
        /// 获得以当前日期的文件名字
        /// </summary>
        /// <returns></returns>
        public static string GetFileName()
        {
            string strName = string.Empty;
            strName = System.DateTime.Now.ToString("G").Replace("/", "-").Replace(":", "-");
            return strName;
        }
    }
    //这样就通过抽象的方式完成了封装 不管外面使用什么格式的数据 都使用一个方法进行搞定
    public class ImData
    {
        public static IList<string> LoadDataFromfile(string strFilePath)
        {
            IList<string> alist=new List<string>();
            string strExt = Path.GetExtension(strFilePath).Trim();
            if (strExt == ".txt")
            {
                IDataImport port = new ClassText();
                alist= port.GetDataFromFile(strFilePath);
            }
            else if (strExt == ".xls")
            {
                IDataImport port = new ClassExcel2003();
                alist= port.GetDataFromFile(strFilePath);
            }
            else if (strExt == ".xlsx")
            {
                IDataImport port = new ClassExcel2007();
                alist= port.GetDataFromFile(strFilePath);
            }
            return alist;
        }

    }
    public interface IDataImport
    {
        /// <summary>
        /// 从文本文件中获得数据
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        IList<string> GetDataFromFile(string strPath);
    }
    public class ClassText : IDataImport
    {
        /// <summary>
        /// 加载文本数据部分 .txt格式
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IList<string> GetDataFromFile(string filePath)
        {
            List<string> list = new List<string>();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            list.Add(line.Trim());//去空处理
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            fs.Close();
            return list;
        }
    }
    public class ClassExcel2003 : IDataImport
    {
        /// <summary>
        /// 加载2003Excel的文本数据
        /// </summary>
        /// <param name="strExcel"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public IList<string> GetDataFromFile(string strExcel)
        {
            List<string> alist = new List<string>();

            if (File.Exists(strExcel))
            {
                DataTable dt = CommonSpace.Conmmon.ExcelToDataTable(strExcel, "Sheet1", CommonSpace.ExcelVersions.Excel8);

                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alist.Add(dr[0].ToString().Trim());
                    }
                }
            }
            return alist;
        }
    }
    public class ClassExcel2007 : IDataImport
    {
        /// <summary>
        /// 加载2007Excel的文本数据
        /// </summary>
        /// <param name="strExcel"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public IList<string> GetDataFromFile(string strExcel)
        {
            List<string> alist = new List<string>();

            if (File.Exists(strExcel))
            {
                DataTable dt = CommonSpace.Conmmon.ExcelToDataTable(strExcel, "Sheet1", CommonSpace.ExcelVersions.Excel12);

                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alist.Add(dr[0].ToString().Trim());
                    }
                }
            }
            return alist;
        }
    }
}
