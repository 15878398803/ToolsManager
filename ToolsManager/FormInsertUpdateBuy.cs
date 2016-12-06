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
    public partial class FormInsertUpdateBuy : Form
    {
        public JsonEntity.BuyListItem BuyListItem;
        public bool isUpdate = false;
        public FormInsertUpdateBuy()
        {
            InitializeComponent();
        }

        private async void FormInsertUpdateBuy_Load(object sender, EventArgs e)
        {

            if (await Server.GetStationList())
            {
                foreach (var i in Global.StationList)
                {
                    comboBox1.Items.Add(i.station_id + "|" + i.name.Trim());
                }
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            comboBox2.SelectedIndex = 0;
            if (isUpdate)
            {
                if (BuyListItem != null)
                {
                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        if (comboBox2.Items[i].ToString().StartsWith(BuyListItem.station_id))
                        {
                            comboBox2.SelectedIndex = i;
                            break;
                        }
                    }

                    textBox1.Text = BuyListItem.name;
                    textBox2.Text = BuyListItem.model;
                    textBox3.Text = BuyListItem.number;
                    textBox4.Text = BuyListItem.sensor_id;
                    var type = Convert.ToInt32(BuyListItem.type.Trim());
                    comboBox2.SelectedIndex = type - 1 >= 0 ? type - 1 : 0;
                }
                else
                {
                    MessageBox.Show("找不到要修改的申购计划");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var i = new FormSensor();
            i.Text = "请双击选择传感器";
            if (i.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = Global.SensorIdSelected.Trim();

            }
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(textBox4.Text))
                        {
                            string stationid = comboBox1.SelectedItem.ToString().Split('|')[0];
                            if (isUpdate)
                            {
                                if (await Server.UpdateBuyPlan(Global.LoginInfo.user_id, Global.LoginInfo.user_code, stationid, textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text, ( comboBox2.SelectedIndex + 1 ).ToString(), BuyListItem.buyplan_id))
                                {
                                    MessageBox.Show("修改成功");
                                }else
                                {
                                    MessageBox.Show("修改失败");
                                }


                            }
                            else
                            {
                                if(await Server.InsertBuyPlan(Global.LoginInfo.user_id, Global.LoginInfo.user_code, stationid, textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text, ( comboBox2.SelectedIndex + 1 ).ToString()))
                                {
                                    MessageBox.Show("增加成功");
                                }else
                                {
                                    MessageBox.Show("增加失败");
                                }

                            }
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("信息填写不完整，请检查");
        }
    }
}
