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
    public partial class FormInsertUpdateStations : Form
    {
        public bool isUpdate = false;
        public JsonEntity.Station station = null;
        public FormInsertUpdateStations()
        {
            InitializeComponent();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                if (await Server.UpdateStation(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(station.station_id), textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("修改站点信息成功");
                }
                else
                {
                    MessageBox.Show("修改站点信息失败");

                }
            }
            else
            {
                if (await Server.InsertStation(Global.LoginInfo.user_id, Global.LoginInfo.user_code, textBox1.Text.Trim(), textBox2.Text))
                {
                    MessageBox.Show("添加站点信息成功");
                }
                else
                {
                    MessageBox.Show("添加站点信息失败");

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormInsertUpdateStations_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                Text = "修改站点信息";
                button1.Text = "修改";
                if (station != null)
                {
                    textBox1.Text = station.name.ToString();
                    textBox2.Text = station.memo;
                }
                else
                {
                    MessageBox.Show("获取现有站点信息失败，请重试");
                }
            }
        }
    }
}
