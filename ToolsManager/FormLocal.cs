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
    public partial class FormLocal : Form
    {
        public FormLocal()
        {
            InitializeComponent();
        }

        private void FormLocal_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.供电局名称;
            textBox2.Text = Properties.Settings.Default.站点名称;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.供电局名称 = textBox1.Text;
            Properties.Settings.Default.站点名称 = textBox2.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("修改完成。程序将自动关闭，请重新运行本程序即可生效。");
            Application.Exit();
        }

        private void FormLocal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
