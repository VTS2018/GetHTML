using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GetHTML
{
    public class Import
    {
        //将dt结果转换为html格式文件
        public static string ImportHTML(DataTable _dataSource, string strGoogleUrl)
        {
            StringBuilder strbData = new StringBuilder();
            strbData.Append("<h4>导出时间：" + System.DateTime.Now.ToString("G") + "</h4>");
            strbData.Append("<style type=\"text/css\">table { border-collapse: collapse; border: 1px solid #000;}td,th {text-align:left; border: 1px solid #000; }  a{ text-decoration:none}</style>");
            strbData.Append("<table style=\"border: 1px solid #000; display: block;\" cellpadding=\"4\" cellspacing=\"0\">");
            strbData.Append("<tr>");
            string strColumn = string.Empty;

            //添加列名
            foreach (DataColumn column in _dataSource.Columns)
            {
                strbData.Append("<th style=\"text-align:center\">" + column.ColumnName + "</th>");
            }
            strbData.Append("</tr>");

            foreach (DataRow dr in _dataSource.Rows)
            {
                strbData.Append("<tr>\n");

                for (int i = 0; i < _dataSource.Columns.Count; i++)
                {
                    strColumn = _dataSource.Columns[i].ColumnName;
                    switch (strColumn)
                    {
                        case "关键词":
                            strbData.Append("<td>\n" + "<a target=\"_blank\"  href=\"" + strGoogleUrl + dr[i].ToString() + "\">" + dr[i].ToString() + "</a>" + "</td>\n");
                            break;
                        //case "当前排名":
                        //    if (Convert.ToInt32(dr[i]) > 0)
                        //    {
                        //        strbData.Append("<td style=\"background-color: Red; color: White\">\n" + dr[i].ToString() + "</td>\n");
                        //    }
                        //    break;
                        default:
                            strbData.Append("<td>\n" + dr[i].ToString() + "</td>\n");
                            break;
                    }
                }

                strbData.Append("</tr>\n");
            }
            strbData.Append("</table>");

            return strbData.ToString();
        }
    }
}
