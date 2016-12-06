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
    public partial class FormSensor : Form
    {
        public FormSensor()
        {
            InitializeComponent();
        }
        private int CurPage = 1;
        private int maxPageNum;

        private void FormSensor_Load(object sender, EventArgs e)
        {
            GetSensorList();
            Global.SensorIdSelected = "";
        }
        async private void GetSensorList()
        {
            if (await Server.GetSensorList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, CurPage, Global.PageNum))
            {
                dataGridView1.DataSource = Global.SensorList.list;
                lb_cur.Text = "第" + Global.SensorList.num.page + "页";
                maxPageNum = Global.SensorList.num.list_num / Global.PageNum + 1;
                lb_sum.Text = "共" + maxPageNum + "页";
                comboBox1.Items.Clear();
                Global.AddComboxNum(comboBox1, maxPageNum);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;

                }
                dataGridView1.Columns[0].HeaderText = "传感器ID";
                dataGridView1.Columns[1].HeaderText = "站点ID";
                dataGridView1.Columns[2].HeaderText = "名称";
                dataGridView1.Columns[3].HeaderText = "序列码";
                dataGridView1.Columns[4].HeaderText = "编号";
                dataGridView1.Columns[5].HeaderText = "备注";
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                { 
                    //拉伸列宽来填满表格
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurPage = CurPage - 1 > 0 ? CurPage - 1 : 1;
            GetSensorList();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurPage = CurPage + 1 < maxPageNum ? CurPage + 1 : maxPageNum;
            GetSensorList();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurPage = 1;
            GetSensorList();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurPage = maxPageNum;
            GetSensorList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurPage = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            GetSensorList();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Global.SensorIdSelected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择一个传感器");
            }
        }
    }
}
