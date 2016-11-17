using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormInsertUser : Form
    {
        public FormInsertUser()
        {
            InitializeComponent();
        }

        async private void FormInsertUser_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("普通专员");
            comboBox1.Items.Add("站点管理员");
            comboBox1.Items.Add("局管理员");
            comboBox1.Items.Add("其他专责");
            comboBox1.SelectedIndex = 0;

            if (await Server.GetStationList())
            {
                foreach (var i in Global.StationList)
                {
                    comboBox2.Items.Add(i.station_id + "|" + i.name.Trim());
                }
                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;
            }
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            if (txUser.Text.Trim() != "" && textName.Text.Trim() != "" && txPasswd.Text.Trim() != "" && textTeam.Text.Trim() != "" && textOpenId.Text.Trim() != "")
            {
                var stationName = comboBox2.Items[comboBox2.SelectedIndex] as string;
                var s = stationName.Split('|');

                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(txPasswd.Text));
                var pwd = BitConverter.ToString(output).Replace("-", "").ToUpper();

                if (await Server.InsertUser(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(s[0]), textName.Text, textTeam.Text, textOpenId.Text, txUser.Text, pwd, ( comboBox2.SelectedIndex + 1 ).ToString()))
                {
                    MessageBox.Show("添加用户成功！");
                    txUser.Focus();
                    txUser.Text = txPasswd.Text = textName.Text = textTeam.Text = textOpenId.Text = null;
                }
                else
                {
                    MessageBox.Show("添加用户失败！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
