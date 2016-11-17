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
    public partial class FormInsertUpdateToolClass : Form
    {
        public bool isUpdate = false;
        public JsonEntity.ToolClass toolclass = null;
        public FormInsertUpdateToolClass()
        {
            InitializeComponent();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                if(await Server.UpdateToolClass(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(toolclass.class_id.Trim()), textBox1.Text.Trim(), textBox2.Text))
                {
                    MessageBox.Show("修改工具类别成功");
                }
                else
                {
                    MessageBox.Show("修改工具类别失败");

                }
            }
            else
            {
                if (await Server.InsertToolClass(Global.LoginInfo.user_id, Global.LoginInfo.user_code, textBox1.Text.Trim(), textBox2.Text))
                {
                    MessageBox.Show("添加工具类别成功");
                }
                else
                {
                    MessageBox.Show("添加工具类别失败");

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormInsertUpdateToolClass_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                Text = "修改工具类别";
                button1.Text = "修改";
                if (toolclass != null)
                {
                    textBox1.Text = toolclass.class_name;
                    textBox2.Text = toolclass.memo;
                }
                else
                {
                    MessageBox.Show("获取现有工具类别失败，请重试");
                }
            }

        }
    }
}
