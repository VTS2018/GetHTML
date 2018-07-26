using System;
using System.Text;
using System.IO;
using System.Net;

namespace GetHTML
{
    public class HtmlOpear
    {
        /// <summary>
        /// 获取googl的源代码
        /// </summary>
        /// <param name="url">搜索的URL</param>
        /// <returns></returns>
        public static string[] GetWebClient(string url)
        {
            string[] arr = new string[2];

            string strHTML = "";
            using (WebClient myWebClient = new WebClient())
            {
                try
                {
                    using (Stream myStream = myWebClient.OpenRead(url))
                    {
                        using (StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8")))
                        {
                            strHTML = sr.ReadToEnd();
                            arr[0] = "true";
                            arr[1] = strHTML;
                        }
                    }
                }
                catch (Exception ex)
                {
                    strHTML = ex.Message;

                    arr[0] = "false";
                    arr[1] = strHTML;
                }
            }
            return arr;
        }
    }
}