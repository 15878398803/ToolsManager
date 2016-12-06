using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            initTitle();
            //this.Icon = new System.Drawing.Icon(Application.StartupPath + @"\desktop.ico");
        }
        public void initTitle()
        {
            if (Properties.Settings.Default.第一次运行)
            {
                FormLocal f = new FormLocal();
                f.TopMost = true;
 //               f.Show();
                this.Hide();
                return;
            }
            Text = Properties.Settings.Default.供电局名称 + " - " + Properties.Settings.Default.站点名称 + " - " + "智能物联工器具管理系统";
            label_main.Text = Properties.Settings.Default.供电局名称;
            label_sub.Text = "(" + Properties.Settings.Default.站点名称 + ")";
        }
        async private void btn_login_Click(object sender, EventArgs e)
        {
            //Global.StationId = 100;
            //return;
            //超级密码为123465
            //var t = await Server.AutoLogin(1, Properties.Settings.Default.LastUserCode);
            //var tt = await Server.AutoLogin(1, Global.AutoLogin.user_code);


            //return;
            if (tx_username.Text == "admin")
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(tx_password.Text));
                if (BitConverter.ToString(output).Replace("-", "").ToUpper() == Properties.Settings.Default.pwd.Trim())
                {
                    FormLocal f = new FormLocal();
                    f.TopMost = true;
                    f.Show();
                    timer1.Stop();
                    return;
                }
            }
#if DEBUG
            Debug.WriteLine("使用默认账号yyq登录调试");
            tx_username.Text = "yyq";
            tx_password.Text = "123456";
#endif
            var result = await Server.Login(tx_username.Text, tx_password.Text);

            if (result)
            {

                //Test();
                //await Server.GetTestList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 56, 1, 100);

                //登录成功
                //Convert.ToInt32("Hello");
                Global.FormMain.Show();
                //Global.FormRecord.Show();
                    Global.FormLogin.Hide();
                timer1.Stop();
                new FormInsertUpdateBuy().Show();
            }
            else
            {
                linkLabel1.Text = " ";
                //登录失败
            }
            tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = true;

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0004_登录矩形框_移动反馈;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0005_登录矩形框;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0003_登录矩形框_点击反馈;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.登录_副本_0000s_0005_登录矩形框;

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0000__退_出___点击反馈;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0001__退_出__移动反馈;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0002__退_出_;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.登录_副本_0000s_0002__退_出_;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (isChangeIP)
            //    Global.ServerIp = "127.0.0.1";
            //else
            //    Global.ServerIp = "120.76.121.79";
            Application.Exit();
        }

        private void tx_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(null, null);
            }
        }

        public void FormLogin_Load(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.isAutoLogin)
            {
                linkLabel1.Text = "正在自动登录...点此取消";
                linkLabel1.Enabled = true;
                timer1.Interval = 1000;
                timer1.Start();
                tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = false;
            }
            else
            {
                linkLabel1.Enabled = false;
            }
        }
        async public void autoLogin()
        {
            string usercode;
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.LastUserCode))
            {
                usercode = DateTime.Now.Ticks.ToString("x");
            }
            else
            {
                usercode = DateTime.Now.Ticks.ToString("x");
                //usercode = Properties.Settings.Default.LastUserCode;
            }

            if (await Server.AutoLogin(Global.StationId, usercode) == false)
            {
                linkLabel1.Enabled = true;
                linkLabel1.Text = "自动登录失败，可能网络通讯不畅，正在重试...点此取消";
                timer1.Start();
                return;
            }
            if (Global.AutoLogin.msg == "无开门记录")
            {
                linkLabel1.Enabled = false;
                linkLabel1.Text = "正在等待开门...";
                timer1.Start();
            }
            else
            {
                Properties.Settings.Default.LastUserCode = Global.AutoLogin.user_code;
                Properties.Settings.Default.Save();
                Global.LoginInfo = Global.AutoLogin;
                if (Global.LoginInfo != null)
                {
                    Global.FormMain.Show();
                    Global.FormLogin.Hide();
                    //linkLabel1.Enabled = true;
                    linkLabel1.Text = " ";
                    tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = true;


                }
            }

        }

        private int reTryDelay = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reTryDelay == 2)
            {
                reTryDelay = 0;
                timer1.Stop();
                autoLogin();
                return;
            }
            else
            {
                reTryDelay++;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reTryDelay = 0;
            timer1.Stop();
            linkLabel1.Text = "";
            linkLabel1.Enabled = false;
            tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = true;


        }

        //public void FormLogin_Load(object sender, EventArgs e)
        //{

        //    if (Properties.Settings.Default.isAutoLogin)
        //    {
        //        linkLabel1.Text = "正在自动登录...点此取消";
        //        linkLabel1.Enabled = true;
        //        timer1.Interval = 2000;
        //        timer1.Start();
        //        tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = false;
        //    }
        //    else
        //    {
        //        linkLabel1.Enabled = false;
        //    }
        //}
        //async public void autoLogin()
        //{
        //    string usercode;
        //    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.LastUserCode))
        //    {
        //        usercode = DateTime.Now.Ticks.ToString("x");
        //    }
        //    else
        //    {
        //        usercode = DateTime.Now.Ticks.ToString("x");
        //        //usercode = Properties.Settings.Default.LastUserCode;
        //    }

        //    if (await Server.AutoLogin(Global.StationId, usercode) == false)
        //    {
        //        linkLabel1.Enabled = true;
        //        linkLabel1.Text = "自动登录失败，可能网络通讯不畅，正在重试...点此取消";
        //        timer1.Start();
        //        return;
        //    }
        //    if (Global.AutoLogin.msg == "无开门记录")
        //    {
        //        linkLabel1.Enabled = false;
        //        linkLabel1.Text = "正在等待开门...";
        //        timer1.Start();
        //    }
        //    else
        //    {
        //        Properties.Settings.Default.LastUserCode = Global.AutoLogin.user_code;
        //        Properties.Settings.Default.Save();
        //        Global.LoginInfo = Global.AutoLogin;
        //        if (Global.LoginInfo != null)
        //        {
        //            Global.FormMain.Show();
        //            Global.FormLogin.Hide();
        //            //linkLabel1.Enabled = true;
        //            linkLabel1.Text = " ";
        //            tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = true;


        //        }
        //    }

        //}

        //private int reTryDelay = 0;
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (reTryDelay == 2)
        //    {
        //        reTryDelay = 0;
        //        timer1.Stop();
        //        autoLogin();
        //        return;
        //    }
        //    else
        //    {
        //        reTryDelay++;
        //    }
        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (Properties.Settings.Default.isAutoLogin)
        //    {
        //        reTryDelay = 0;
        //        timer1.Stop();
        //        linkLabel1.Text = "";
        //        linkLabel1.Enabled = false;
        //        tx_username.Enabled = tx_password.Enabled = pictureBox1.Enabled = true;
        //    }
        //}
    }
}
