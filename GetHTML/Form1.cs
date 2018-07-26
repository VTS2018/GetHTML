using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Mail;
using xiaoy.Excel;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Xml;

using Microsoft.Win32;


namespace GetHTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initnumeric();
            RegcheckEvent();
            SetTiptoControl();
        }

        //初始化numeric控件
        public void Initnumeric()
        {
            //初始化
            this.numericMax.Maximum = 1000;
            this.numericMin.Minimum = 1;

            this.numericMax.Value = 6;
            this.numericMin.Value = 1;

            this.numericMax.Increment = 1;
            this.numericMin.Increment = 1;

            this.numericMax.DecimalPlaces = 0;
            this.numericMin.DecimalPlaces = 0;

            this.numericMax.InterceptArrowKeys = true;
            this.numericMin.InterceptArrowKeys = true;
        }

        //为控件批量注册事件
        public void RegcheckEvent()
        {
            //为checkBox注册事件
            this.checkBox1.CheckedChanged += new EventHandler(checkBoxCheckedChanged);
            this.checkBox2.CheckedChanged += new EventHandler(checkBoxCheckedChanged);
            this.checkBox3.CheckedChanged += new EventHandler(checkBoxCheckedChanged);
            this.checkBox4.CheckedChanged += new EventHandler(checkBoxCheckedChanged);
            this.checkBox5.CheckedChanged += new EventHandler(checkBoxCheckedChanged);

            this.btnSetTxtPath.Click += new EventHandler(btnClick);
            this.btnImportDomain.Click += new EventHandler(btnClick);
        }

        //为控件设置提示信息
        public void SetTiptoControl()
        {
            Tools.SetTip(this.btnSeleteMtil, "请一定要设置Excel数据文件！");
        }

        void checkBoxCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbox = (CheckBox)sender;
            string str = chbox.Text;

            if (chbox.Checked)
            {
                optionList.Add(str);
            }
            else
            {
                optionList.Remove(str);
            }
            Structure();
        }

        #region 全局变量定义

        //软件注册
        SoftReg softReg = new SoftReg();

        //用于批量查询的线程操作
        Thread th;
        delegate void MyDelegate(string value);

        //定义获得远程HTML的委托
        public delegate string[] GetWebClientHandler(string strURL);

        //googleURL查询参数
        public string strGoogleUrl = string.Empty;

        //当前查询域名
        public string currentKeywords = string.Empty;

        //当前查询关键字
        public string currentURL = string.Empty;

        //excel文件的路径
        public static string strExcel = string.Empty;

        //排名域名-关键字列表
        public IList<KeyURL> urlKeywords = new List<KeyURL>();

        //导出结果列选项
        public IList<string> optionList = new List<string>();

        //保存item 域名或者关键字 的选项集合  
        public IList<string> comListitem = new List<string>();

        //保存导出结果到内存表
        public DataTable dt = new DataTable();

        //保存所有结果
        public DataTable dtall = new DataTable();

        //初始文本路径
        public string strTxtpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //定义保存html代码的txt文件路径
        public string savePath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Tools.GetFileName() + ".html";

        #endregion

        //窗体初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStyletem();

            LoadCheckList();

            //软件注册
            Register(sender, e);
        }

        //查询方式更改事件
        private void comBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.comBoxStyle.SelectedIndex;
            switch (index)
            {
                case 0:
                    //查询关键字的结果数
                    //this.strGoogleUrl = this.txtGoogle.Text + "search?newwindow=1&output=search&sclient=psy-ab&q=";
                    this.strGoogleUrl = this.txtGoogle.Text + "search?newwindow=1&q=";

                    this.btnCurrentSearch.Enabled = true;
                    this.btnSearch.Enabled = true;

                    this.btnSelect.Enabled = false;
                    this.btnSeleteMtil.Enabled = false;

                    break;
                case 1:
                    //查询域名是否有收录
                    //this.strGoogleUrl = this.txtGoogle.Text + "search?newwindow=1&output=search&sclient=psy-ab&q=site:";
                    this.strGoogleUrl = this.txtGoogle.Text + "search?newwindow=1&q=site:";

                    this.btnCurrentSearch.Enabled = true;
                    this.btnSearch.Enabled = true;

                    this.btnSelect.Enabled = false;
                    this.btnSeleteMtil.Enabled = false;

                    break;
                case 2:
                    //查询域名对应的关键词排名情况
                    this.strGoogleUrl = this.txtGoogle.Text + "search?num=50&newwindow=1&q=";

                    this.btnCurrentSearch.Enabled = false;
                    this.btnSearch.Enabled = false;

                    this.btnSelect.Enabled = true;
                    this.btnSeleteMtil.Enabled = true;

                    break;
                default:
                    break;
            }
        }

        //导入列表
        private void btnClick(object sender, EventArgs e)
        {
            //需要支持Excel文件
            string strTxtpath = Tools.GetFilePath(new OpenFileDialog(), "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx|txt文件(*.txt)|*.txt");
            if (strTxtpath == "")
            {
                return;
            }

            IList<string> alist = ImData.LoadDataFromfile(strTxtpath);

            Button btn = (Button)sender;
            if (btn.Name == "btnSetTxtPath")
            {
                this.comkeyWords.Text = strTxtpath;
                LoadkeyOrUrlData(alist, this.comkeyWords);
            }

            if (btn.Name == "btnImportDomain")
            {
                this.comDomainItems.Text = strTxtpath;
                LoadkeyOrUrlData(alist, this.comDomainItems);
            }

            //先清空，保存到全局变量
            this.comListitem.Clear();
            this.comListitem = alist;
        }

        //设置文件
        private void btnSetExcel_Click(object sender, EventArgs e)
        {
            strExcel = Tools.GetFilePath(new OpenFileDialog(), "Excel2003文件(*.xls)|*.xls|Excel2007文件(*.xlsx)|*.xlsx");

            if (strExcel == "")
            {
                return;
            }

            this.txtkeyUrl.Text = strExcel;

            //将数据加载到IList<KeyURL>
            string strExt = Path.GetExtension(strExcel).Trim();

            if (strExt == ".xls")
            {
                GetListFromDataTable(strExcel, CommonSpace.ExcelVersions.Excel8);
            }
            else if (strExt == ".xlsx")
            {
                GetListFromDataTable(strExcel, CommonSpace.ExcelVersions.Excel12);
            }
        }

        //清空数据
        private void btnClear_Click(object sender, EventArgs e)
        {
            urlKeywords.Clear();
            comListitem.Clear();
            dt.Clear();
            this.txtResult.Text = "";
        }

        //软件注册
        private void btnReg_Click(object sender, EventArgs e)
        {
            frmRegisterForm frmRegister = new frmRegisterForm();
            frmRegister.ShowDialog();
        }

        //关闭窗体
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //在此处必须将其中没有终止的线程终止掉
            if (th != null)
            {
                th.Abort();
            }
            Application.ExitThread();
            Application.Exit();
        }

        #region 关键字数量和域名

        //单个查询
        private void btnCurrentSearch_Click(object sender, EventArgs e)
        {
            //使用异步回调的方式实现
            if (this.comkeyWords.Text == "")
            {
                return;
            }

            GetWebClientHandler handler = new GetWebClientHandler(HtmlOpear.GetWebClient);

            //需要对关键字进行处理 但是URL却不需要处理
            IAsyncResult result = handler.BeginInvoke(GetStrURI(this.comkeyWords.Text), new AsyncCallback(CallbackFuction), "ok");

            this.txtResult.Text = "";
            this.txtResult.AppendText("正在查询中请稍后···\n");
            this.txtResult.AppendText(this.comkeyWords.Text + "\t");
        }

        //单个查询的回调函数
        public void CallbackFuction(IAsyncResult result)
        {
            int num = 0;
            string strResult = string.Empty;
            string temp = string.Empty;

            GetWebClientHandler handler = (GetWebClientHandler)((AsyncResult)result).AsyncDelegate;

            string[] html = handler.EndInvoke(result);

            //处理返回的结果
            if (html[0] == "false")
            {
                this.txtResult.AppendText("\r\nIP被封!\r\n");
                return;
            }
            temp = Tools.Google_getProductNum(html[1]);

            num = (temp == string.Empty ? 0 : Convert.ToInt32(temp));

            if (num == 0)
            {
                strResult = "没有收录";
            }
            else
            {
                strResult = num.ToString();
            }

            this.txtResult.AppendText("结果：\r\t" + strResult + Environment.NewLine);
            this.txtResult.AppendText(result.AsyncState.ToString());
        }

        //批量查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 废弃
            //MessageBox.Show(this.checkListItem.SelectedItems.Count.ToString());
            //MessageBox.Show(this.listItem.SelectedItems.Count.ToString());
            //MessageBox.Show(this.strGoogleUrl + this.comkeyWords.Text);
            //MessageBox.Show(this.comkeyWords.Items.Count.ToString());

            //此处开始异步函数的回调 解决线程UI的假死

            //DateTime dtNow = DateTime.Now;
            //SearchKeyMutil(this.comkeyWords.Items);
            //TimeSpan span = DateTime.Now - dtNow;

            //this.labTime.Text = "用时：[" + span.ToString() + "]";
            //包含处理函数和回调函数两个部分
            //GetHtmlHandler handler = new GetHtmlHandler(this.SearchKeyMutil);
            //handler.BeginInvoke(this.comkeyWords.Items, new AsyncCallback(this.SearchKeyMutil), "po"); 
            #endregion

            this.txtResult.Text = "";
            //使用另一个线程来查询
            th = new Thread(SearchKeyMutil);
            th.Start();
        }

        #endregion

        #region 查询排名

        //查询排名情况
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.comkeyWords.Text == "")
            {
                return;
            }

            GetWebClientHandler handler = new GetWebClientHandler(HtmlOpear.GetWebClient);

            //需要对关键字进行处理 但是URL却不需要处理
            IAsyncResult result = handler.BeginInvoke(GetStrURI(this.comkeyWords.Text), new AsyncCallback(CallbackFuctionGrankings), "ok");

            this.txtResult.Text = "";
            this.txtResult.AppendText("正在查询中请稍后···\r\n");
            this.txtResult.AppendText("域名：" + this.comDomainItems.Text + "关键词：" + this.comkeyWords.Text + "\r\n");

        }

        //排名回调
        public void CallbackFuctionGrankings(IAsyncResult result)
        {
            string strResult = string.Empty;
            string[] html = null;
            GetWebClientHandler handler = (GetWebClientHandler)((AsyncResult)result).AsyncDelegate;

            html = handler.EndInvoke(result);

            if (html[0] == "false")
            {
                this.txtResult.AppendText("\r\nIP已经被封掉了\r\n");
                return;
            }

            List<string> alist = GetUrlList(html[1]);//代码中已经转换为小写了

            int ranknum = 0;
            strResult = Computingrankings(alist, this.comDomainItems.Text, out  ranknum);
            this.txtResult.AppendText(strResult);
        }

        //批量查询排名情况
        private void btnSeleteMtil_Click(object sender, EventArgs e)
        {
            if (urlKeywords.Count <= 0)
            {
                return;
            }
            this.txtResult.Text = "";

            //开始进行域名列表的批量查询
            //使用另一个线程来查询

            th = new Thread(SearchSiteMutil);
            th.Start();
        }

        //终止批量查询
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (th == null)
            {
                return;
            }
            th.Abort();
        }

        #endregion

        #region 导出数据到文件

        //导出Excel
        private void btnImport_Click(object sender, EventArgs e)
        {
            //如何实现动态的选择导出列呢？
            if (optionList.Count == 0)
            {
                MessageBox.Show("Sorry!您没有设置数据导出选项！", "提醒", MessageBoxButtons.OK);
                return;
            }

            string excelPath = string.Empty;
            SaveFileDialog sf = new SaveFileDialog();
            sf.AddExtension = true;
            sf.Title = "请选择Excel保存的位置：";
            sf.FileName = Tools.GetFileName();
            sf.Filter = "Excel2003文件(*.xls)|*.xls";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                excelPath = sf.FileName;
                if (dt != null && !string.IsNullOrEmpty(excelPath))
                {
                    ExcelFile.SetData(dt, excelPath, ExcelVersion.Excel8, HDRType.Yes);
                    MessageBox.Show("导出成功");
                }
                else
                {
                    MessageBox.Show("没有需要导出的数据");
                }
            }
            return;
        }

        //导出HTML文本
        private void btnImportHTML_Click(object sender, EventArgs e)
        {
            string strHTML = Import.ImportHTML(this.dt, strGoogleUrl);

            System.IO.File.WriteAllText(savePath, strHTML, System.Text.Encoding.GetEncoding("utf-8"));

            System.Diagnostics.Process.Start(savePath);
        }

        #endregion


        //构造DataTable架构
        public void Structure()
        {
            //构造架构之前销毁原先的架构
            dt.Columns.Clear();//不适用dt.Clear() -这个主要是用来清除数据的
            foreach (string item in optionList)
            {
                DataColumn dc = new DataColumn(item, System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
            }
        }

        //构造查询URL函数部分
        public string GetStrURI(string strKeywods)
        {
            string strURI = this.strGoogleUrl + Tools.GetString(strKeywods);
            return strURI;
        }

        /// <summary>
        /// 批量查询关键字
        /// </summary>
        public void SearchKeyMutil()
        {
            if (comListitem == null || comListitem.Count <= 0)
            {
                return;
            }

            //委托一个方法用来更新界面
            MyDelegate d = new MyDelegate(UpdateText);

            this.txtResult.Text = "";

            string strURI = string.Empty;
            int num = 0;
            string strResult = string.Empty;
            string temp = string.Empty;
            string result = string.Empty;
            string[] html = null;

            this.Invoke(d, string.Format("共导入{0}结果！\r\n", comListitem.Count));

            DataRow dr;

            for (int i = 0; i < comListitem.Count; i++)
            {
                //组合关键的查询的URL 并对关键字中的空格进行处理
                strURI = this.strGoogleUrl + Tools.GetString(comListitem[i].ToString());

                html = HtmlOpear.GetWebClient(strURI);
                if (html[0] == "false")
                {
                    this.Invoke(d, "\r\nIP被封!\r\n");
                    break;
                }
                temp = Tools.Google_getProductNum(html[1]);

                num = (temp == string.Empty ? 0 : Convert.ToInt32(temp));

                if (num == 0)
                {
                    strResult = "没有收录";
                }
                else
                {
                    strResult = num.ToString();
                }

                //需要根据一个全局变量动态的构建
                dr = dt.NewRow();
                if (optionList.Contains("关键词"))
                {
                    dr["关键词"] = comListitem[i].ToString();
                }
                if (optionList.Contains("结果数"))
                {
                    dr["结果数"] = strResult;
                }

                dt.Rows.Add(dr);
                result = string.Format("\r\n第{0}条 {1}\t-结果数：\t{2}", i + 1, comListitem[i].ToString().PadRight(25, ' '), strResult + Environment.NewLine);
                this.Invoke(d, result);

                //让当前的线程歇一会
                if (th != null)
                {
                    this.Invoke(d, "\r\n我在休息中...\r\n");
                    th.Join(GetRandomSeconds());
                }
            }
            this.Invoke(d, "\r\n已处理完毕！\r\n");
        }

        /// <summary>
        /// 查询排名函数处理
        /// </summary>
        public void SearchSiteMutil()
        {
            string result = string.Empty;
            string[] html = null;
            int ranknum = 0;
            List<string> alist = new List<string>();

            MyDelegate d = new MyDelegate(UpdateText);

            //保留列的定义，清空所有的DT数据
            dt.Clear();

            DataRow dr;

            /************************增加代码在查询结果中也获取关键字的结果数********************/
            int num = 0;
            string strResult = string.Empty;
            string temp = string.Empty;
            /************************************************************************************/

            this.Invoke(d, string.Format("共导入{0}结果！\r\n", urlKeywords.Count));

            for (int i = 0; i < urlKeywords.Count; i++)
            {
                //获得关键词源代码
                html = HtmlOpear.GetWebClient(GetStrURI(urlKeywords[i].KeyWords));

                if (html[0] == "false")
                {
                    this.Invoke(d, "\r\nIP被封!\r\n");
                    break;
                }

                ////////////////计算关键字的结果数量//////////////
                temp = Tools.Google_getProductNum(html[1]);

                num = (temp == string.Empty ? 0 : Convert.ToInt32(temp));

                if (num == 0)
                {
                    strResult = "没有收录";
                }
                else
                {
                    //插入逗号处理
                    strResult = Tools.InserChar(num.ToString());
                }
                /////////////////////////////////////////////////

                alist.Clear();//清空所有元素
                alist = GetUrlList(html[1]);

                result = "\r\n第" + (i + 1) + "条 域名：" + urlKeywords[i].URL + "关键字：" + urlKeywords[i].KeyWords + "\r\n";
                result += Computingrankings(alist, urlKeywords[i].URL, out ranknum);

                dr = dt.NewRow();

                if (optionList.Contains("域名"))
                {
                    dr["域名"] = urlKeywords[i].URL;
                }

                if (optionList.Contains("关键词"))
                {
                    dr["关键词"] = urlKeywords[i].KeyWords;
                }
                if (optionList.Contains("结果数"))
                {
                    dr["结果数"] = strResult;
                }
                if (optionList.Contains("当前排名"))
                {
                    dr["当前排名"] = ranknum;
                }
                if (optionList.Contains("收录情况"))
                {
                    dr["收录情况"] = result;//对结果进一步的处理
                }
                dt.Rows.Add(dr);

                this.Invoke(d, result);

                //让当前的线程歇一会
                if (th != null)
                {
                    this.Invoke(d, "\r\n我在休息中...\r\n*************************************************************************\r\n");
                    th.Join(GetRandomSeconds());
                }
            }
            this.Invoke(d, "\r\n已处理完毕！\r\n");
        }

        //更新界面的方法
        public void UpdateText(string strText)
        {
            this.txtResult.AppendText(strText);
        }

        //加载查询选项
        public void LoadStyletem()
        {
            this.comBoxStyle.Items.Clear();
            this.comBoxStyle.DropDownStyle = ComboBoxStyle.DropDownList;

            this.comBoxStyle.Items.Add("查询关键字结果数量");
            this.comBoxStyle.Items.Add("查询域名是否收录");
            this.comBoxStyle.Items.Add("查询关键词排名");

            this.comBoxStyle.SelectedItem = this.comBoxStyle.Items[0];
        }

        //加载checkbox选项
        public void LoadCheckList()
        {
            string[] optionArr = new string[] { "域名", "关键词", "结果数", "当前排名", "收录情况" };
            Control.ControlCollection Collection = this.groupOptions.Controls;

            for (int i = 0; i < Collection.Count; i++)
            {
                CheckBox ch = Collection[i] as CheckBox;
                ch.Text = optionArr[i];
                ch.Checked = true;
                //ch.CheckState = CheckState.Checked;
            }

            //this.listItem.Items.Clear();
            //this.listItem.Items.Add("域名");
            //this.listItem.Items.Add("关键字");
            //this.listItem.Items.Add("结果数");
            //this.listItem.Items.Add("收录情况");
            //this.listItem.Items.Add("当前排名");
            //this.listItem.SelectionMode = SelectionMode.MultiSimple;
        }

        /// <summary>
        /// 加载文本数据（关键词或域名）到下拉列表框
        /// </summary>
        /// <param name="alist"></param>
        /// <param name="box"></param>
        public void LoadkeyOrUrlData(IList<string> alist, ComboBox box)
        {
            //清空原有的选项
            box.Items.Clear();
            if (alist == null || alist.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < alist.Count; i++)
            {
                box.Items.Add(alist[i]);
            }
        }

        public void LoadDataToComList(IList<string> alist)
        {
            //清空全局参数
            comListitem.Clear();
            if (alist == null || alist.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < alist.Count; i++)
            {
                comListitem.Add(alist[i]);
            }
            //该方法完成了两件事情 不好
        }

        /// <summary>
        /// 从Excel中加载数据 版本升级2.0一个域名 对应多个关键词
        /// </summary>
        /// <param name="strExcel"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public IList<KeyURL> GetListFromDataTable(string strExcel, CommonSpace.ExcelVersions ex)
        {
            if (File.Exists(strExcel))
            {
                DataTable dt = CommonSpace.Conmmon.ExcelToDataTable(strExcel, "Sheet1", ex);

                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //如果数据只有一列就会发生问题 一个域名对应一个关键词

                        //从第二个单元格获取想要的数据
                        string[] arr = Tools.SplitString(dr[1].ToString());

                        for (int i = 0; i < arr.Length; i++)
                        {
                            urlKeywords.Add(new KeyURL { URL = dr[0].ToString(), KeyWords = arr[i].ToString() });
                        }

                        //在数据结果中还需要保持其他的列
                    }
                }
            }
            return urlKeywords;
        }

        /// <summary>
        /// 从Excel中加载数据
        /// </summary>
        /// <param name="strExcel"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public List<string> GetListDataFromDataTable(string strExcel, CommonSpace.ExcelVersions ex)
        {
            List<string> alist = new List<string>();

            if (File.Exists(strExcel))
            {
                DataTable dt = CommonSpace.Conmmon.ExcelToDataTable(strExcel, "Sheet1", ex);

                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        alist.Add(dr[0].ToString());
                    }
                }
            }
            return alist;
        }

        #region 计算排名情况模块

        /// <summary>
        /// 分析从google获得源码 获取排名前50个url集合【导出前50个竞争对手的站点URL】
        /// </summary>
        /// <param name="strHTMLCode"></param>
        /// <returns></returns>
        public List<string> GetUrlList(string strHTMLCode)
        {
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(strHTMLCode);

            HtmlAgilityPack.HtmlNodeCollection hrefList = htmldoc.DocumentNode.SelectNodes(".//li[@class=\"g\"]");

            //表示单个的节点
            string strCite = ".//cite";

            List<string> alistURL = new List<string>();

            if (hrefList != null)
            {
                //foreach (HtmlAgilityPack.HtmlNode href in hrefList)
                //{
                //    //HtmlAgilityPack.HtmlAttribute att = href.Attributes["href"];
                //    //this.txtResult.AppendText(att.Value+Environment.NewLine);
                //    //this.txtResult.AppendText(href.InnerText);

                //    HtmlAgilityPack.HtmlNode node = href.SelectSingleNode(strCite);
                //    this.txtResult.AppendText(node.InnerText);
                //}

                for (int i = 0; i < hrefList.Count; i++)
                {
                    HtmlAgilityPack.HtmlNode curSpanNode = hrefList[i];

                    //bool bl = new CheckBox().Checked;
                    //if (bl)
                    //{
                    //    //勾选
                    //    HtmlAgilityPack.HtmlNodeCollection curImageNode = curSpanNode.SelectNodes(".//cite");
                    //}
                    //else
                    //{
                    //    //不勾选
                    //    HtmlAgilityPack.HtmlNode curImageNode = curSpanNode.SelectSingleNode(".//cite");
                    //}

                    HtmlAgilityPack.HtmlNode curImageNode = curSpanNode.SelectSingleNode(strCite);
                    if (curImageNode == null || curImageNode.InnerText == "")
                    {
                        continue;
                    }
                    alistURL.Add(OpearURL(curImageNode.InnerText));

                    //this.txtResult.AppendText(curImageNode.InnerText + Environment.NewLine);
                    //HtmlAgilityPack.HtmlNode curLinkNode = curSpanNode.SelectSingleNode("a");
                    //ImageInfo image = new ImageInfo();
                    //image.Title = curLinkNode.InnerText;
                    //image.SrcPath = curImageNode.Attributes["src"].Value; imageList.Add(image);
                }
            }
            return alistURL;
        }

        /// <summary>
        /// 计算排名情况参数： 域名列表  要查询的域名  排名
        /// </summary>
        /// <param name="alisturl"></param>
        /// <param name="strDomain"></param>
        /// <param name="ranking"></param>
        /// <returns></returns>
        public string Computingrankings(List<string> alisturl, string strDomain, out int ranking)
        {
            //思路：获得该关键词的前五十个结果；在结果中搜索执行的域名；结算域名的排名情况
            if (alisturl == null || alisturl.Count <= 0)
            {
                ranking = 0;
                return "Sorry！没有获得查询的结果！";
            }

            string strResult = string.Empty;

            int count = alisturl.Count;
            int currentindex = 0;

            string strurl = strDomain.ToLower().Trim();

            for (int i = 0; i < alisturl.Count; i++)
            {
                if (alisturl[i].Contains(strurl))
                {
                    currentindex = i + 1;
                    break;
                }
                else
                {
                    currentindex = -1;
                }
            }

            if (currentindex == -1)
            {
                strResult = "\r\nSorry!在前50个结果中没有找到您网址的结果！请继续努力！\r\n";
                ranking = 0;
                return strResult;
            }

            //计算在第几页
            int pageindex = 0;
            int rankindex = 0;

            int ptemp = currentindex / 10;
            int rtemp = currentindex % 10;

            //先分析页数
            if (rtemp == 0)//10,20,30,40,50
            {
                pageindex = ptemp;
                rankindex = 10;//表示第十个位置
            }
            else
            {
                pageindex = ptemp + 1;
                rankindex = rtemp;//10以外的位置
            }

            if (pageindex >= 0 && rankindex >= 0)
            {
                strResult = string.Format("\r\n恭喜您！在第{0}页的第{1}个位置找到了您的网站！在前{2}个结果总排名{3}\r\n", pageindex, rankindex, count, currentindex);
            }

            ranking = currentindex;
            return strResult;
        }

        /// <summary>
        /// 对URL做更近一步的处理
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        public string OpearURL(string strURL)
        {
            if (strURL == "" || strURL == null)
            {
                return " no URL!";
            }
            string str = string.Empty;
            if (strURL.Contains("/"))
            {
                int index = strURL.IndexOf('/');
                if (index == -1)
                {
                    return " no URL!";
                }
                str = strURL.Substring(0, index).ToLower().Trim();
            }
            return str;

        }

        /// <summary>
        /// 获得随机的间隔时间 3s-5s去查询一下
        /// </summary>
        /// <returns></returns>
        public int GetRandomSeconds()
        {
            int n = 0;
            int min = Convert.ToInt32(numericMin.Value);
            int max = Convert.ToInt32(numericMax.Value);

            if (min < max)
            {
                n = new Random().Next(min, max) * 1000;
            }
            else
            {
                n = 3 * 1000;
            }

            return n;
        }

        #endregion

        //软件注册
        public void Register(object sender, EventArgs e)
        {
            //判断软件是否注册
            RegistryKey retkey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("wxf").CreateSubKey("wxf.INI");
            foreach (string strRNum in retkey.GetSubKeyNames())
            {
                if (strRNum == softReg.GetRNum())
                {
                    //this.lblRegInfo.Text = "此软件已注册！";
                    this.Text = "关键查询结果统计！技术支持 QQ:1065359365 此软件已注册！";

                    this.btnReg.Enabled = false;
                    return;
                }
            }

            this.Text = "关键查询结果统计！技术支持 QQ:1065359365 此软件尚未注册！";
            this.btnReg.Enabled = true;

            MessageBox.Show("您现在使用的是试用版，可以免费试用30次！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Int32 tLong;
            try
            {
                tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", 0);
                MessageBox.Show("您已经使用了" + tLong + "次！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("欢迎使用本软件！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", 0, RegistryValueKind.DWord);
            }
            tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", 0);

            if (tLong < 10)
            {
                int tTimes = tLong + 1;
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", tTimes);
            }
            else
            {
                DialogResult result = MessageBox.Show("试用次数已到！您是否需要注册？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    frmRegisterForm.state = false;

                    btnReg_Click(sender, e);
                }
                else
                {
                    Application.ExitThread();
                    Application.Exit();
                }
            }
        }
    }
}