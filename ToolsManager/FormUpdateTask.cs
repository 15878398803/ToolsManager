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
    public partial class FormUpdateTask : Form
    {
        public JsonEntity.TaskListItem tasklist;
        public FormUpdateTask()
        {
            InitializeComponent();
        }

        async private void FormUpdateTask_Load(object sender, EventArgs e)
        {
            if (tasklist == null)
            {
                MessageBox.Show("获取当前所选的工作票信息失败，请重试");
            }
            else
            {
                label2.Text = "工作票ID：" + tasklist.task_id;
                await Server.GetWorkTypeList();
                foreach (var i in Global.WorkTypeList)
                {
                    comboBox1.Items.Add(i.work_id + "|" + i.name);
                    if (tasklist.work_id == i.work_id)
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    }
                }

                comboBox2.SelectedIndex = 0;
                textBox1.Text = tasklist.task_num;
                textBox2.Text = tasklist.team;
                textBox3.Text = tasklist.memo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            var workTypeId = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split('|')[0];
            if (await Server.UpdateTask(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(tasklist.task_id), Convert.ToInt32(workTypeId), textBox1.Text, textBox2.Text, comboBox2.SelectedIndex + 1, textBox3.Text))
            {
                MessageBox.Show("修改工作票信息成功");
            }else
            {
                MessageBox.Show("修改工作票信息失败");

            }
        }
    }
}
