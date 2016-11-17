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
    public partial class FormUpdateInsertDefect : Form
    {

        public bool IsUpdate = false;
        public JsonEntity.Defect Defect;
        public FormUpdateInsertDefect()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            var ss = comboBoxClass.Items[comboBoxClass.SelectedIndex] as string;
            var s = ss.Split('|');
            if (IsUpdate)
            {
                if(await Server.UpdateDefect(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(Defect.defect_id), Convert.ToInt32(s[0]), textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("修改缺陷成功");
                }else
                {
                    MessageBox.Show("修改缺陷失败");

                }
            }
            else
            {
                if(await Server.InsertDefect(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(s[0]), textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("添加缺陷成功");
                }else
                {
                    MessageBox.Show("添加缺陷失败");
                }
            }
        }

        async private void FormUpdateInsertDefect_Load(object sender, EventArgs e)
        {
            await Server.GetToolClasses();
            foreach (var i in Global.ToolClass)
            {
                comboBoxClass.Items.Add(i.class_id + "|" + i.class_name);
            }
            if (comboBoxClass.Items.Count > 0)
                comboBoxClass.SelectedIndex = 0;
            if (IsUpdate)
            {

                for (int i = 0; i < comboBoxClass.Items.Count; i++)
                {
                    if (comboBoxClass.Items[i].ToString().StartsWith(Defect.class_id))
                    {
                        comboBoxClass.SelectedIndex = i;
                        break;
                    }
                }

                textBox1.Text = Defect.defect_name;
                textBox2.Text = Defect.memo;
                Text = "修改缺陷";
                button1.Text = "修改";
            }
        }
    }
}
