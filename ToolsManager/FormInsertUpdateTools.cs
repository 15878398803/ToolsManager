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
    public partial class FormInsertUpdateTools : Form
    {
        public bool isUpdateTool = false;
        public JsonEntity.ToolListItem updateTool = null;
        public FormInsertUpdateTools()
        {
            InitializeComponent();
        }

        async private void FormInsertUpdateTools_Load(object sender, EventArgs e)
        {
            await Server.GetToolClasses();

            foreach (var i in Global.ToolClass)
            {
                comboBoxClass.Items.Add(i.class_id + "|" + i.class_name);
            }
            if (comboBoxClass.Items.Count > 0)
                comboBoxClass.SelectedIndex = 0;

            if (isUpdateTool)
            {
                Text = "修改工具";
                button1.Text = "修改";
                if (updateTool != null)
                {
                    textBox6.Text = updateTool.sensor_id;
                    //textBox5.Text = updateTool.class_id;
                    textBox1.Text = updateTool.name;
                    textBox2.Text = updateTool.model;
                    textBox4.Text = updateTool.number;
                    textBox3.Text = updateTool.subject;
                    dateTimePicker1.Value = DateTime.Parse(updateTool.factory_time);
                    dateTimePicker2.Value = DateTime.Parse(updateTool.buy_time);
                    dateTimePicker4.Value = DateTime.Parse(updateTool.test_time);
                    textBox7.Text = updateTool.test_cycle;
                    textBox8.Text = updateTool.life_cycle;
                    textBox9.Text = updateTool.vender;
                }
                else
                {
                    MessageBox.Show("读取工具信息失败，无法修改工具，请先选取工具再修改。");
                }
            }
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            var stationName = comboBoxClass.Items[comboBoxClass.SelectedIndex] as string;
            var s = stationName.Split('|');
            if (isUpdateTool)
            {
                if (await Server.UpdateTool(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(updateTool.tool_id.Trim()), Convert.ToInt32(textBox6.Text.Trim()), Convert.ToInt32(s[0]), textBox1.Text, textBox2.Text, textBox4.Text, Convert.ToInt32(textBox3.Text.Trim()), dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker4.Value, Convert.ToInt32(textBox7.Text.Trim()), Convert.ToInt32(textBox8.Text.Trim()), textBox9.Text))
                {
                    MessageBox.Show("修改工具成功");
                }
            }
            else
            {
                if (await Server.AddTool(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(textBox6.Text.Trim()), Convert.ToInt32(s[0]), textBox1.Text, textBox2.Text, textBox4.Text, Convert.ToInt32(textBox3.Text.Trim()), dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker4.Value, Convert.ToInt32(textBox7.Text.Trim()), Convert.ToInt32(textBox8.Text.Trim()), textBox9.Text))
                {
                    MessageBox.Show("添加工具成功");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
