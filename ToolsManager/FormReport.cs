using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ToolsManager
{
    public partial class FormReport : Form
    {
        int page = 0;
        private int maxPageNum;
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
 //           StandingBook standingbook = new StandingBook();
   //         dataGridView1.DataSource = standingbook.ToWindow();
     //       dataGridView1.RowHeadersVisible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormReport = null;
        }

        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "申购计划":
                    break;
                case "局申购汇总":
                    break;
                case "报废记录":
                    break;
                case "局报废汇总":
                    break;
                case "工作类别":
                    break;
                case "缺陷类别":
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    break;
            }
        }

        private void FormReport_Shown(object sender, EventArgs e)
        {

        }

        private void ll_Next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page++;
            listViewLeft_DoubleClick(null, null);
        }

        private void ll_End_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                page = Global.ToolClass.Count;
                listViewLeft_DoubleClick(null, null);
            }
            catch
            {

            }
            
        }

        private void ll_Last_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page--;
            listViewLeft_DoubleClick(null, null);
        }

        private void ll_First_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page=1;
            listViewLeft_DoubleClick(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = Convert.ToInt32(comboBox1.Text);
            listViewLeft_DoubleClick(null, null);
        }


        async public Task<bool> ReadDefectsList(int classID)
        {
            if (classID == 0)
            {
                await Server.GetToolClasses();
                //                int list_num = Global.ToolClass.Count;
                lb_cur.Text = "第" + 0 + "页";
                lb_sum.Text = "共" + Global.ToolClass.Count + "页";
                if (Global.ToolClass.Count != comboBox1.Items.Count)
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i <= Global.ToolClass.Count; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                dataGridView1.DataSource = Global.ToolClass;
                dataGridView1.RowHeadersVisible = false;
                if (Global.ToolClass.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "科目id标识";
                    dataGridView1.Columns[1].HeaderText = "科目名称";
                    dataGridView1.Columns[2].HeaderText = "备注";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }

            }
            else if (await Server.GetDefectList(classID))
            {
                int list_num = Global.DefectList.Count;
                maxPageNum = (list_num / 100) + 1;
                lb_cur.Text = "第" + page + "页";
                lb_sum.Text = "共" + Global.ToolClass.Count + "页";
                if (Global.ToolClass.Count != comboBox1.Items.Count)
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i <= Global.ToolClass.Count; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                dataGridView1.DataSource = Global.DefectList;
                dataGridView1.RowHeadersVisible = false;
                if (Global.DefectList.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "缺陷id 标识";
                    dataGridView1.Columns[1].HeaderText = "科目id标识";
                    dataGridView1.Columns[2].HeaderText = "缺陷名称";
                    dataGridView1.Columns[3].HeaderText = "备注";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                
            }
            return true;
        }
    }
}
