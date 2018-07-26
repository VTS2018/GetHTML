namespace GetHTML
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetTxtPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comBoxStyle = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGoogle = new System.Windows.Forms.TextBox();
            this.btnCurrentSearch = new System.Windows.Forms.Button();
            this.comkeyWords = new System.Windows.Forms.ComboBox();
            this.btnImportHTML = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comDomainItems = new System.Windows.Forms.ComboBox();
            this.btnImportDomain = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSetExcel = new System.Windows.Forms.Button();
            this.txtkeyUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSeleteMtil = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.numericMax = new System.Windows.Forms.NumericUpDown();
            this.numericMin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "时间间隔:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(139, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "批量查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(70, 393);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "导出Excel";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "关键字:";
            // 
            // btnSetTxtPath
            // 
            this.btnSetTxtPath.Location = new System.Drawing.Point(290, 70);
            this.btnSetTxtPath.Name = "btnSetTxtPath";
            this.btnSetTxtPath.Size = new System.Drawing.Size(75, 23);
            this.btnSetTxtPath.TabIndex = 8;
            this.btnSetTxtPath.Text = "导入文本";
            this.btnSetTxtPath.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "查询方式:";
            // 
            // comBoxStyle
            // 
            this.comBoxStyle.FormattingEnabled = true;
            this.comBoxStyle.Location = new System.Drawing.Point(84, 74);
            this.comBoxStyle.Name = "comBoxStyle";
            this.comBoxStyle.Size = new System.Drawing.Size(210, 20);
            this.comBoxStyle.TabIndex = 10;
            this.comBoxStyle.SelectedIndexChanged += new System.EventHandler(this.comBoxStyle_SelectedIndexChanged);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(9, 20);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(371, 359);
            this.txtResult.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Google区域:";
            // 
            // txtGoogle
            // 
            this.txtGoogle.Location = new System.Drawing.Point(83, 20);
            this.txtGoogle.Name = "txtGoogle";
            this.txtGoogle.Size = new System.Drawing.Size(211, 21);
            this.txtGoogle.TabIndex = 17;
            this.txtGoogle.Text = "http://www.google.com/";
            // 
            // btnCurrentSearch
            // 
            this.btnCurrentSearch.Location = new System.Drawing.Point(20, 19);
            this.btnCurrentSearch.Name = "btnCurrentSearch";
            this.btnCurrentSearch.Size = new System.Drawing.Size(113, 23);
            this.btnCurrentSearch.TabIndex = 18;
            this.btnCurrentSearch.Text = "查询当前";
            this.btnCurrentSearch.UseVisualStyleBackColor = true;
            this.btnCurrentSearch.Click += new System.EventHandler(this.btnCurrentSearch_Click);
            // 
            // comkeyWords
            // 
            this.comkeyWords.FormattingEnabled = true;
            this.comkeyWords.Location = new System.Drawing.Point(73, 72);
            this.comkeyWords.Name = "comkeyWords";
            this.comkeyWords.Size = new System.Drawing.Size(211, 20);
            this.comkeyWords.TabIndex = 19;
            this.comkeyWords.Text = "hermes bag";
            // 
            // btnImportHTML
            // 
            this.btnImportHTML.Location = new System.Drawing.Point(151, 393);
            this.btnImportHTML.Name = "btnImportHTML";
            this.btnImportHTML.Size = new System.Drawing.Size(89, 23);
            this.btnImportHTML.TabIndex = 22;
            this.btnImportHTML.Text = "导出HTML文本";
            this.btnImportHTML.UseVisualStyleBackColor = true;
            this.btnImportHTML.Click += new System.EventHandler(this.btnImportHTML_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(258, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 23);
            this.btnStop.TabIndex = 23;
            this.btnStop.Text = "停止查询任务";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(20, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(113, 23);
            this.btnSelect.TabIndex = 24;
            this.btnSelect.Text = "查询当前排名情况";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "网  址:";
            // 
            // comDomainItems
            // 
            this.comDomainItems.FormattingEnabled = true;
            this.comDomainItems.Location = new System.Drawing.Point(73, 45);
            this.comDomainItems.Name = "comDomainItems";
            this.comDomainItems.Size = new System.Drawing.Size(211, 20);
            this.comDomainItems.TabIndex = 26;
            this.comDomainItems.Text = "www.hermes.com";
            // 
            // btnImportDomain
            // 
            this.btnImportDomain.Location = new System.Drawing.Point(290, 43);
            this.btnImportDomain.Name = "btnImportDomain";
            this.btnImportDomain.Size = new System.Drawing.Size(75, 23);
            this.btnImportDomain.TabIndex = 27;
            this.btnImportDomain.Text = "导入域名";
            this.btnImportDomain.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(106, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 16);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(22, 41);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(78, 16);
            this.checkBox3.TabIndex = 30;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.checkBox5);
            this.groupOptions.Controls.Add(this.checkBox4);
            this.groupOptions.Controls.Add(this.checkBox1);
            this.groupOptions.Controls.Add(this.checkBox3);
            this.groupOptions.Controls.Add(this.checkBox2);
            this.groupOptions.Location = new System.Drawing.Point(8, 100);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(286, 85);
            this.groupOptions.TabIndex = 31;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "导出选项设置";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(183, 41);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(78, 16);
            this.checkBox5.TabIndex = 35;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(106, 41);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 16);
            this.checkBox4.TabIndex = 31;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.btnImportHTML);
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.Location = new System.Drawing.Point(478, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 435);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "显示结果";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(246, 393);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "清空显示结果";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSetExcel);
            this.groupBox3.Controls.Add(this.txtkeyUrl);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnImportDomain);
            this.groupBox3.Controls.Add(this.btnSetTxtPath);
            this.groupBox3.Controls.Add(this.comDomainItems);
            this.groupBox3.Controls.Add(this.comkeyWords);
            this.groupBox3.Location = new System.Drawing.Point(12, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 103);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询操作";
            // 
            // btnSetExcel
            // 
            this.btnSetExcel.Location = new System.Drawing.Point(290, 14);
            this.btnSetExcel.Name = "btnSetExcel";
            this.btnSetExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSetExcel.TabIndex = 37;
            this.btnSetExcel.Text = "选择";
            this.btnSetExcel.UseVisualStyleBackColor = true;
            this.btnSetExcel.Click += new System.EventHandler(this.btnSetExcel_Click);
            // 
            // txtkeyUrl
            // 
            this.txtkeyUrl.Location = new System.Drawing.Point(73, 16);
            this.txtkeyUrl.Name = "txtkeyUrl";
            this.txtkeyUrl.Size = new System.Drawing.Size(211, 21);
            this.txtkeyUrl.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "列  表:";
            // 
            // btnSeleteMtil
            // 
            this.btnSeleteMtil.Location = new System.Drawing.Point(139, 20);
            this.btnSeleteMtil.Name = "btnSeleteMtil";
            this.btnSeleteMtil.Size = new System.Drawing.Size(113, 23);
            this.btnSeleteMtil.TabIndex = 28;
            this.btnSeleteMtil.Text = "批量查询排名情况";
            this.btnSeleteMtil.UseVisualStyleBackColor = true;
            this.btnSeleteMtil.Click += new System.EventHandler(this.btnSeleteMtil_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnReg);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.numericMax);
            this.groupBox4.Controls.Add(this.numericMin);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtGoogle);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.groupOptions);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.comBoxStyle);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(449, 200);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选项设置";
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReg.ForeColor = System.Drawing.Color.Red;
            this.btnReg.Location = new System.Drawing.Point(300, 139);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(140, 46);
            this.btnReg.TabIndex = 35;
            this.btnReg.Text = "软件注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "秒";
            // 
            // numericMax
            // 
            this.numericMax.Location = new System.Drawing.Point(191, 45);
            this.numericMax.Name = "numericMax";
            this.numericMax.Size = new System.Drawing.Size(43, 21);
            this.numericMax.TabIndex = 33;
            // 
            // numericMin
            // 
            this.numericMin.Location = new System.Drawing.Point(107, 45);
            this.numericMin.Name = "numericMin";
            this.numericMin.Size = new System.Drawing.Size(43, 21);
            this.numericMin.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "秒到";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "从";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCurrentSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 48);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "域名|关键字查询";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSelect);
            this.groupBox5.Controls.Add(this.btnSeleteMtil);
            this.groupBox5.Controls.Add(this.btnStop);
            this.groupBox5.Location = new System.Drawing.Point(12, 391);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(388, 56);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "站点排名查询";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 526);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关键查询结果统计！技术支持 QQ:1065359365";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetTxtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comBoxStyle;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGoogle;
        private System.Windows.Forms.Button btnCurrentSearch;
        private System.Windows.Forms.ComboBox comkeyWords;
        private System.Windows.Forms.Button btnImportHTML;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comDomainItems;
        private System.Windows.Forms.Button btnImportDomain;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericMax;
        private System.Windows.Forms.NumericUpDown numericMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button btnSeleteMtil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetExcel;
        private System.Windows.Forms.TextBox txtkeyUrl;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnReg;


    }
}

