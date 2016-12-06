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
    public partial class FormSelectWork : Form
    {
        public FormSelectWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个工作任务");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Global.SelectedWorkId = Convert.ToInt32(comboBox1.SelectedItem.ToString().Split('|')[0]);
            }
        }

        async private void FormSelectWork_Load(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            await Server.GetWorkTypeList();
            comboBox1.Items.Clear();
            foreach (var i in Global.WorkTypeList)
            {
                comboBox1.Items.Add(i.work_id + "|" + i.name);
            }
        }
    }
}
