using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //Global.FormLogin = new FormLogin();
        }
        /// <summary>
        /// 打开各个功能窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            switch (listView1.SelectedItems[0].Text)
            {
                case "领还记录":

                    Global.FormRecord.Show();
                    Global.FormRecord.Focus();
                    break;
                case "维护管理":

                    Global.FormMaintain.Show();
                    Global.FormMaintain.Focus();

                    break;
                case "业务报表":

                    Global.FormReport.Show();
                    Global.FormReport.Focus();

                    break;
                case "子系统":

                    Global.FormSubsystem.Show();
                    Global.FormSubsystem.Focus();

                    break;
                case "个人设置":

                    Global.FormSettings.Show();
                    Global.FormSettings.Focus();

                    break;
                case "实时领还记录表":

                    Global.FormTaskReceiveList.Show();
                    Global.FormTaskReceiveList.Focus();

                    break;
                case "系统设置":

                    //Global.FormSettings.Show();
                    //Global.FormSettings.Focus();
                    var pwd = Interaction.InputBox("请输入管理员密码：", "系统设置");
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(pwd));
                    if (BitConverter.ToString(output).Replace("-", "").ToUpper() == Properties.Settings.Default.pwd.Trim())
                    {
                        FormLocal f = new FormLocal();
                        f.TopMost = true;
                        f.Show();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("抱歉，密码错误。");
                    }
                    break;
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Global.FormMain = null;
            Global.AutoLogin = null;
            Global.FormLogin.Show();
            Hide();
            Global.FormLogin.FormLogin_Load(null, null);
            //e.Cancel = true;
            //FormMain_Load(null,null);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = Properties.Settings.Default.供电局名称 + " - " + Properties.Settings.Default.站点名称 + " - " + "智能物联工器具管理系统";
            if (Global.AutoLogin == null)
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    //Debug.WriteLine(i.Text);
                    if (i.Text == "实时领还记录表")
                    {
                        i.Remove();
                    }
                }
                //  i.Remove();
                timer1.Start();

            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
