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
    public partial class FormSelectStation : Form
    {
        public FormSelectStation()
        {
            InitializeComponent();
        }

        async private void FormSelectStation_Load(object sender, EventArgs e)
        {
            await Server.GetStationList();
            foreach (var i in Global.StationList)
            {
                comboBox1.Items.Add(i.station_id + "|" + i.name.Trim());
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            Global.StationSelected = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Global.StationSelected = comboBox1.SelectedItem.ToString().Split('|')[0];
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
