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
    }
}
