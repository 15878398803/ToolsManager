using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
#if DEBUG
            Debug.WriteLine("使用默认账号yyq登录调试");
            tx_username.Text = "yyq";
            tx_password.Text = "123456";
#endif
            if (Server.Login(tx_username.Text, tx_password.Text))
            {
                //登录成功
                if (Global.formMain == null)
                {
                    Global.formMain = new FormMain();
#if DEBUG
                    Global.formMain.TopMost = false;
                    Global.formMain.FormBorderStyle = FormBorderStyle.FixedDialog;
#else
                Global.formMain.TopMost = true;
#endif
                    Global.formMain.Show();
                    this.Hide();
                }
            }
            else
            {
                //登录失败
            }


        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formLogin = null;
        }
    }
}
