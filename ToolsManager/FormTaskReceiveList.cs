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
    public partial class FormTaskReceiveList : Form
    {
        private DataGridViewCellStyle color_danger = new DataGridViewCellStyle();

        public FormTaskReceiveList()
        {
            InitializeComponent();
            color_danger.BackColor = Color.Red;
            color_danger.ForeColor = Color.White;
        }

        private void FormTaskReceiveList_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        async private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.LoginInfo != null && Global.AutoLogin != null)
            {

                if (await Server.GetTaskReceiveList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(Global.AutoLogin.task_id)))
                {
                    dataGridView1.DataSource = Global.TaskReceiveList;


                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;

                        var t = dataGridView1.Rows[i].Cells;
                        var type = t[10].Value as string;
                        if (type == "1")//type
                        {

                            t[10].Style = color_danger;
                            //对value的修改会影响绑定的List，务必注意
                            t[9].Value = t[7].Value = t[14].Value = t[5].Value = "";
                            t[10].Value = "未归还";
                        }
                        else if (type == "2")
                        {
                            //对value的修改会影响绑定的List，务必注意
                            t[10].Value = "已归还";
                            if (t[9].Value as string == "1")
                            {
                                t[9].Value = "完好";
                            }
                            else
                            {
                                t[9].Value = "否";
                                t[9].Style = color_danger;
                            }
                        }
                        if (t[8].Value as string == "1")//领用时
                        {
                            t[8].Value = "完好";
                        }
                        else
                        {
                            t[8].Value = "否";
                            t[9].Style = color_danger;

                        }
                        if (DateTime.Parse(t[16].Value as string) > DateTime.Now)
                        {
                            t[16].Style = color_danger;
                        }
                        if (DateTime.Parse(t[17].Value as string) > DateTime.Now)
                        {
                            t[17].Style = color_danger;

                        }

                    }
                    if (dataGridView1.ColumnCount == 17)
                    {
                        dataGridView1.Columns[0].HeaderText = "记录id";
                        dataGridView1.Columns[1].HeaderText = "工具id";
                        dataGridView1.Columns[2].HeaderText = "站点id";
                        dataGridView1.Columns[3].HeaderText = "工作票号id";
                        dataGridView1.Columns[4].HeaderText = "领用人id";
                        dataGridView1.Columns[5].HeaderText = "归还人id";
                        dataGridView1.Columns[6].HeaderText = "领用时间";
                        dataGridView1.Columns[7].HeaderText = "归还时间";
                        dataGridView1.Columns[8].HeaderText = "领用时是否完好";
                        dataGridView1.Columns[9].HeaderText = "归还时是否完好";
                        dataGridView1.Columns[10].HeaderText = "是否归还";
                        dataGridView1.Columns[11].HeaderText = "工具名称";
                        dataGridView1.Columns[12].HeaderText = "工具编号";
                        dataGridView1.Columns[13].HeaderText = "领用人名称";
                        dataGridView1.Columns[14].HeaderText = "归还人名称";
                        dataGridView1.Columns[15].HeaderText = "工作票号";
                        dataGridView1.Columns[16].HeaderText = "下次试验时间";
                        dataGridView1.Columns[17].HeaderText = "工器具报废时间";
                    }

                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        //全部列不可修改
                        dataGridView1.Columns[i].ReadOnly = true;
                        //拉伸列宽来填满表格
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }
                }
            }
        }

        private void FormTaskReceiveList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormTaskReceiveList = null;

        }
    }
}
