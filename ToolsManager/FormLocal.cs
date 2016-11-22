using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormLocal : Form
    {
        private bool isDisconnected = false;
        public FormLocal()
        {
            InitializeComponent();
        }

        async private void FormLocal_Load(object sender, EventArgs e)
        {
            checkBox2.Checked = Properties.Settings.Default.isAutoLogin;

            textBox1.Text = Properties.Settings.Default.供电局名称;
            //textBox2.Text = Properties.Settings.Default.站点名称;
            if (await Server.GetStationList())
            {
                foreach (var i in Global.StationList)
                {
                    comboBox1.Items.Add(i.station_id + "|" + i.name.Trim());
                }
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            else
            {
                isDisconnected = true;
                MessageBox.Show("无法获取站点列表，请检查网络连接后再试。");
                Global.FormLogin.Show();
                //this.Close();
            }
            tx_num.Text = Properties.Settings.Default.单页容量.ToString();
            tx_ip.Text = Properties.Settings.Default.ServerIp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.供电局名称 = textBox1.Text;
            Properties.Settings.Default.ServerIp = tx_ip.Text.Trim();
            if (isDisconnected)
            {
                Properties.Settings.Default.Save();
                MessageBox.Show("修改完成。程序将自动关闭，请重新运行本程序即可生效。");
                Application.Exit();
            }
            else
            {
                var stationName = comboBox1.Items[comboBox1.SelectedIndex] as string;
                var s = stationName.Split('|');
                if (s.Length == 2)
                {
                    Properties.Settings.Default.站点ID = Convert.ToInt32(s[0]);
                    Properties.Settings.Default.站点名称 = s[1];

                }
                else
                {
                    MessageBox.Show("站点名称修改失败。");
                }
                if (checkBox1.Checked)
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(tx_password.Text));
                    Properties.Settings.Default.pwd = BitConverter.ToString(output).Replace("-", "").ToUpper();
                }
                Properties.Settings.Default.isAutoLogin = checkBox2.Checked;
                Properties.Settings.Default.单页容量 = Convert.ToInt32(tx_num.Text.Trim());

                if (Properties.Settings.Default.第一次运行)
                {
                    Properties.Settings.Default.第一次运行 = false;
                }
            }
            Properties.Settings.Default.Save();
            MessageBox.Show("修改完成。一些设置在重启后生效，建议重启本程序。");
            //Application.Exit();
        }

        private void FormLocal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (Global.LoginInfo == null)
            //    Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tx_password.Enabled = true;
                tx_password.Text = "";
            }
            else
            {
                tx_password.Enabled = false;
                tx_password.Text = "";
            }
        }
    }
}
