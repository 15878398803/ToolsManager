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
    public partial class FormTaskReceiveList : Form
    {
        public FormTaskReceiveList()
        {
            InitializeComponent();
        }

        private void FormTaskReceiveList_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        async private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.LoginInfo != null)
            {

                if (await Server.GetTaskReceiveList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(Global.AutoLogin.task_id)))
                {
                    dataGridView1.DataSource = Global.TaskReceiveList;

                }
            }
        }

        private void FormTaskReceiveList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormTaskReceiveList = null;
            
        }
    }
}
