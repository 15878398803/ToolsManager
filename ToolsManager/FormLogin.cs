using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Global.formLogin = this;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (Global.formMain == null)
            {
                Global.formMain = new FormMain();
                Global.formMain.TopMost = true;
                Global.formMain.Show();
                this.Hide();
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.formLogin = null;
        }
    }
}
