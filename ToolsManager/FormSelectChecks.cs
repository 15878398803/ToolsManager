using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsManager
{
    public partial class FormSelectChecks : Form
    {
        private int maxPageNum;
        private int page = 0;
        private string SelectedWorkTypeId;
        public FormSelectChecks()
        {
            InitializeComponent();
        }

        async private void FormSelectChecks_Load(object sender, EventArgs e)
        {
            await Server.GetWorkTypeList();
            comboBox1.Items.Clear();
            var r = Global.WorkTypeList.Where(t => t.special == "2").ToList();
            foreach (var i in r)
            {
                comboBox1.Items.Add(i.work_id + "|" + i.name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一个工作票");
            }
            else
            {
                Global.SelectedTaskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        async private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个工作任务");
            }
            else
            {
                SelectedWorkTypeId = comboBox1.SelectedItem.ToString().Split('|')[0];
                page = 0;
                //await Server.GetTaskList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1, 100, SelectedWorkTypeId);
                //dataGridView1.DataSource = Global.TaskList.list;

                //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
                await GetTaskList(page);
            }
        }
        async public Task<bool> GetTaskList(int cur)
        {
            if (SelectedWorkTypeId == null)
            {
                MessageBox.Show("请选择一个工作任务");
                return false;
            }
            if (cur <= 0)
                cur = 1;
            if (await Server.GetTaskList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, cur, Global.PageNum, SelectedWorkTypeId))
            {
                if (Global.TaskList.list == null)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("无工作票记录");

                    return false;
                }
                maxPageNum = ( Global.TaskList.num.list_num / Convert.ToInt32(Global.TaskList.num.page_num) ) + 1;
                //               int list_num = Global.ToolsList.list.Count;
                //               page = 1;
                //               maxPageNum = (list_num / Global.PageNum) + 1;
                lb_cur.Text = "第" + Global.TaskList.num.page + "页";
                //              var sum = Global.ToolsList.num.list_num / Global.PageNum;
                //             maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                if (maxPageNum != comboBox2.Items.Count)
                {
                    Global.AddComboxNum(comboBox2, maxPageNum);
                }
                dataGridView1.DataSource = Global.TaskList.list;
                if (Global.TaskList.list.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "事件编号ID";
                    dataGridView1.Columns[1].HeaderText = "工作类型";
                    dataGridView1.Columns[2].HeaderText = "作业票单号";
                    dataGridView1.Columns[3].HeaderText = "生产班组";
                    dataGridView1.Columns[4].HeaderText = "创建时间";
                    dataGridView1.Columns[5].HeaderText = "站点";
                    dataGridView1.Columns[6].HeaderText = "工作是否完成";
                    dataGridView1.Columns[7].HeaderText = "备注";
                    //dataGridView1.Columns[5].Visible = false;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                        var t = dataGridView1.Rows[i].Cells;
                        switch (t[6].Value.ToString())
                        {
                            case "1":
                                t[6].Value = "未完成";
                                break;
                            case "2":
                                t[6].Value = "已完成";

                                break;
                            default:
                                break;
                        }

                    }
                }

            }
            return true;
        }

        async private void ll_First_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = 1;
            await GetTaskList(page);
        }

        async private void ll_Last_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (page > 0)
            {
                page--;
                await GetTaskList(page);
            }

        }

        async private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = Convert.ToInt32(comboBox2.Text);
            await GetTaskList(page);
        }

        async private void ll_Next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (page < maxPageNum)
            {
                page++;
                await GetTaskList(page);
            }
        }

        async private void ll_End_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = maxPageNum;
            await GetTaskList(page);
        }
    }
}
