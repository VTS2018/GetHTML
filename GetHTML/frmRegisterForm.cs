using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GetHTML
{
    public partial class frmRegisterForm : Form
    {
        public frmRegisterForm()
        {
            InitializeComponent();
        }
        public static bool state = true;  //软件是否为可用状态

        SoftReg softReg = new SoftReg();

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRNum.Text == softReg.GetRNum())
                {
                    MessageBox.Show("注册成功！重启软件后生效！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegistryKey retkey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("wxf").CreateSubKey("wxf.INI").CreateSubKey(txtRNum.Text);
                    retkey.SetValue("UserName", "Rsoft");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("注册码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRNum.SelectAll();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmRegisterForm_Load(object sender, EventArgs e)
        {
            this.txtMNum.Text = softReg.GetMNum();

            this.txtRNum.Text = softReg.GetRNumByMum("BFEBFBFF000206A720C32847");
            //this.txtRNum.Text = softReg.GetRNumByMum("BFEBFBFF000006FD245CECFF");

        }
    }
}
