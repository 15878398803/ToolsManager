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
                case "实时领还表":
                    //ShowDialog(new FormPassword());
                    Global.FormTaskReceiveList.Show();
                    Global.FormTaskReceiveList.Focus();

                    break;
                case "系统设置":

                    //Global.FormSettings.Show();
                    //Global.FormSettings.Focus();
                    //var pwd = Interaction.InputBox("请输入管理员密码：", "系统设置");
                    //if (ShowDialog(new FormPassword()) == DialogResult.Yes)
                    if (new FormPassword().ShowDialog() == DialogResult.Yes)
                    {

                        if (Global.UserInput.Trim() == "admin")
                        {
                            MD5 md5 = new MD5CryptoServiceProvider();
                            byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(Global.PasswordInput));
                            if (BitConverter.ToString(output).Replace("-", "").ToUpper() == Properties.Settings.Default.pwd.Trim())
                            {
                                FormLocal f = new FormLocal();
                                f.TopMost = true;
                                f.Show();
                                return;
                            }
                        }
                        Global.PasswordInput = Global.UserInput = "";
                        MessageBox.Show("抱歉，账号密码错误。");
                    }

                    break;
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Global.FormMain = null;
            Global.AutoLogin = null;
            Global.FormLogin.Show();
            Global.FormLogin.FormLogin_Load(null, null);

            Global.CloseAll();
            //e.Cancel = true;
            //FormMain_Load(null,null);
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

                    if (i.Text == "维护管理" && Global.LoginInfo.role == 1)
                    {
                        i.Remove();
                    }
                    if (i.Text == "业务报表" && Global.LoginInfo.role == 1)
                    {
                        i.Remove();
                    }
                    if (i.Text == "子系统" && Global.LoginInfo.role == 1)
                    {
                        i.Remove();
                    }

                }
                //  i.Remove();

            }
            else
            {


                Global.FormTaskReceiveList.Show();
                Global.FormTaskReceiveList.Focus();
                timer1.Start();

            }



        }
        async private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "姓名：" + Global.LoginInfo.name + " 角色：" + Global.LoginInfo.role;//+ " Code:" + Global.LoginInfo.user_code;
            timer1.Stop();

            if (await Server.AutoLogin(Global.StationId, Properties.Settings.Default.LastUserCode))
            {
                //label1.Text = "";
                if (Global.UserChanged)
                {
                    //if (Global.LoginInfo == null)
                    //{
                    Close();
                    Global.FormLogin.Show();
                    Global.FormLogin.FormLogin_Load(null, null);
                    return;
                    //}
                }

                //if (Global.FormTaskReceiveList.IsDisposed)
                //{
                //Global.FormTaskReceiveList.TopMost = true;
                //Global.FormTaskReceiveList.Show();
                //    //Global.FormTaskReceiveList.Focus();
                //}
                //Global.FormTaskReceiveList.Focus();
                //if (Global.AutoLogin.msg == "无开门记录")
                //{
                //    Global.LoginInfo = null;
                //}
            }
            else
            {
                //linkLabel1.Enabled = true;
                //label1.Text = "网络中断，正在重新建立连接...";
                Close();
                Global.FormLogin.Show();
                Global.FormLogin.FormLogin_Load(null, null);
                return;
            }
            timer1.Start();
        }
        private void FormMain_Shown(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
