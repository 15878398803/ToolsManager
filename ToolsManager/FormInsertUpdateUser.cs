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
    public partial class FormInsertUpdateUser : Form
    {
        public bool UpdateUser = false;
        public JsonEntity.UserListItem updateUserItems;
        public FormInsertUpdateUser()
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

            if (UpdateUser)
            {
                if (updateUserItems != null)
                {
                    comboBox1.SelectedIndex = updateUserItems.role > 4 ? 4 : updateUserItems.role - 1;
                    foreach (var i in comboBox2.Items)
                    {
                        Debug.WriteLine(i);
                    }
                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        //Debug.WriteLine(i);
                        if (comboBox2.Items[i].ToString().StartsWith(updateUserItems.station_id))
                        {
                            comboBox2.SelectedIndex = i;
                            break;
                        }
                    }
                    textName.Text = updateUserItems.name;
                    textOpenId.Text = updateUserItems.openid;
                    textTeam.Text = updateUserItems.team;
                    txPasswd.Text = updateUserItems.userpwd;
                    txUser.Text = updateUserItems.username;
                    Text = "修改用户";
                    button1.Text = "修改";

                }
                else
                {
                    MessageBox.Show("获取待修改的用户信息失败，请重试");
                    Close();
                }
                //comboBox2.SelectedIndex = comboBox2.Items.// IndexOf();
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
                if (UpdateUser)
                {
                    if (await Server.UpdateUser(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(s[0]), textName.Text, textTeam.Text, textOpenId.Text, txUser.Text, pwd, ( comboBox1.SelectedIndex + 1 ).ToString(), Convert.ToInt32(updateUserItems.user_id)))
                    {
                        MessageBox.Show("修改用户成功！");
                        //txUser.Focus();
                        //txUser.Text = txPasswd.Text = textName.Text = textTeam.Text = textOpenId.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("修改用户失败！");
                    }
                }
                else
                {
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
