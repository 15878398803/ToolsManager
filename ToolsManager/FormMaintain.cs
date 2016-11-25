﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ToolsManager
{
    public partial class FormMaintain : Form
    {
        private string lastTable;
        int page = 1;
        private int curPage, maxPageNum;
        public FormMaintain()
        {
            InitializeComponent();
            //           this.button1.Visible = false;
            //           this.button2.Visible = false;
            //           this.button3.Visible = false;
        }

        private void FormMaintain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormMaintain = null;
        }

        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            if (sender != null)
                page = 1;
            label1.Text = listViewLeft.SelectedItems[0].Text;
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "台账报表":
                    lastTable = "台账报表";
                    await TableToolsList(page);
                    break;
                case "综合管理":
                    lastTable = "综合管理";
                    break;
                case "预送检表":
                    lastTable = "预送检表";
                    await ReadyTestToolsList();
                    break;
                case "预报废表":
                    lastTable = "预报废表";
                    await ReadyDeathToolsList();
                    break;
                case "定期检查":
                    lastTable = "定期检查";
                    break;
                case "送检反馈":
                    lastTable = "送检反馈";
                    break;
                case "逾期记录":
                    lastTable = "逾期记录";
                    break;
                case "增购申请":
                    lastTable = "增购申请";
                    break;
            }
        }

        private void FormMaintain_Load(object sender, EventArgs e)
        {

        }

        private void FormMaintain_Shown(object sender, EventArgs e)
        {

        }

        private void Last_MouseClick(object sender, MouseEventArgs e)
        {
            if (page > 0)
            {
                page--;
                listViewLeft_DoubleClick(null, null);
            }
        }

        private void Next_MouseClick(object sender, MouseEventArgs e)
        {
            if (page < maxPageNum)
            {
                page++;
                listViewLeft_DoubleClick(null, null);
            }
        }

        private void First_MouseClick(object sender, MouseEventArgs e)
        {
            page = 1;
            listViewLeft_DoubleClick(null, null);
        }

        private void ll_End_MouseClick(object sender, MouseEventArgs e)
        {
            //            page = (Global.ToolsList.num.list_num / Convert.ToInt32(Global.ToolsList.num.page_num)) + 1;
            page = maxPageNum;
            listViewLeft_DoubleClick(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = Convert.ToInt32(comboBox1.Text);
            listViewLeft_DoubleClick(null, null);
        }

        private void ll_Goto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void 刷新ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (listViewLeft.SelectedItems.Count > 0)
                listViewLeft_DoubleClick(null, null);
        }

        private void 添加ToolStripButton1_Click(object sender, EventArgs e)
        {
            switch (lastTable)
            {
                case "台账报表":
                    FormInsertUpdateTools UT = new FormInsertUpdateTools();                         //增加
                    UT.ShowDialog();
                    break;
                case "综合管理":
                    break;
                case "预送检表":
                    break;
                case "预报废表":
                    break;
                case "定期检查":
                    break;
                case "送检反馈":
                    break;
                case "逾期记录":
                    break;
                case "增购申请":
                    break;
            }
            
        }

        private void 修改ToolStripButton1_Click(object sender, EventArgs e)
        {
            switch (lastTable)
            {
                case "台账报表":
                    FormInsertUpdateTools UT = new FormInsertUpdateTools();
                    UT.isUpdateTool = true;
                    UT.updateTool = Global.ToolsList.list.Find(t => t.tool_id == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value as string);
                    UT.ShowDialog();
                    break;
                case "综合管理":
                    break;
                case "预送检表":
                    break;
                case "预报废表":
                    break;
                case "定期检查":
                    break;
                case "送检反馈":
                    break;
                case "逾期记录":
                    break;
                case "增购申请":
                    break;
            }
        }

        async private void 删除ToolStripButton1_Click(object sender, EventArgs e)
        {
            switch (lastTable)
            {
                case "台账报表":
                    var Tool = Global.ToolsList.list.Find(t => t.tool_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);

                    if (MessageBox.Show("您确定要删除工具 " + Tool.name + " 吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (await Server.DeleteTool(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(Tool.tool_id)))
                        {
                            MessageBox.Show("删除工具 " + Tool.name + " 成功");
                            await TableToolsList(page);
                        }

                    }
                    break;
                case "综合管理":
                    break;
                case "预送检表":
                    break;
                case "预报废表":
                    break;
                case "定期检查":
                    break;
                case "送检反馈":
                    break;
                case "逾期记录":
                    break;
                case "增购申请":
                    break;
            }

        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1!=null)
            {
                Excel.DataGridViewToExcelCSV(dataGridView1);
            }
        }

        async public Task<bool> ReadyDeathToolsList()
        {
            if (await Server.GetReadyDeathTools(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1))
            {
                //               maxPageNum = (Global.ToolsList.num.list_num / Convert.ToInt32(Global.ToolsList.num.page_num)) + 1;
                int list_num = Global.ReadyDeathTools.Count;
                page = 1;
                maxPageNum = (list_num / 100) + 1;
                lb_cur.Text = "第" + page + "页";
                //              var sum = Global.ToolsList.num.list_num / Global.PageNum;
                //             maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                // curPage = cur;
                if (maxPageNum != comboBox1.Items.Count)
                {
                    Global.AddComboxNum(comboBox1, maxPageNum);
                }
                
                dataGridView1.DataSource = Global.ReadyDeathTools;
                //                dataGridView1.RowHeadersVisible = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    var t = dataGridView1.Rows[i].Cells;
                }
                if (Global.ReadyDeathTools.Count>=0)
                {
                    dataGridView1.Columns[0].HeaderText = "工具标识";
                    dataGridView1.Columns[1].HeaderText = "传感器标识";
                    dataGridView1.Columns[2].HeaderText = "站点id标识";
                    dataGridView1.Columns[3].HeaderText = "科目id标识";
                    dataGridView1.Columns[4].HeaderText = "领用人id标识";
                    dataGridView1.Columns[5].HeaderText = "工具名称";
                    dataGridView1.Columns[6].HeaderText = "工具型号";
                    dataGridView1.Columns[7].HeaderText = "工具编号";
                    dataGridView1.Columns[8].HeaderText = "工具类别";
                    dataGridView1.Columns[9].HeaderText = "出厂日期";
                    dataGridView1.Columns[10].HeaderText = "购买日期";
                    dataGridView1.Columns[11].HeaderText = "试验日期";
                    dataGridView1.Columns[12].HeaderText = "试验周期(月)";
                    dataGridView1.Columns[13].HeaderText = "生命周期(月)";
                    dataGridView1.Columns[14].HeaderText = "生产厂商";
                    dataGridView1.Columns[15].HeaderText = "传感器名称";
                    dataGridView1.Columns[16].HeaderText = "科目名称";
                    dataGridView1.Columns[17].HeaderText = "下次试验日期";
                    dataGridView1.Columns[18].HeaderText = "报废日期";
                    dataGridView1.Columns[19].HeaderText = "是否在库";
                    dataGridView1.Columns[20].HeaderText = "去向";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }               
            }
            return true;
        }
        async public Task<bool> ReadyTestToolsList()
        {
            if (await Server.GetReadyTestTools(Global.LoginInfo.user_id, Global.LoginInfo.user_code, 1))
            {
                //               maxPageNum = (Global.ToolsList.num.list_num / Convert.ToInt32(Global.ToolsList.num.page_num)) + 1;
                int list_num = Global.ReadyTestTools.Count;
                page = 1;
                maxPageNum = (list_num / 100) + 1;
                lb_cur.Text = "第" + page + "页";
                //              var sum = Global.ToolsList.num.list_num / Global.PageNum;
                //             maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                // curPage = cur;
                if (maxPageNum != comboBox1.Items.Count)
                {
                    Global.AddComboxNum(comboBox1, maxPageNum);
                }
                                //foreach (var Tool in Global.ReadyTestTools)
                //{
                //    if (Tool.user_id == "0")
                //    {
                //        Tool.user_id = "无人领用";
                //    }
                //    if (Tool.in_depot == "true")
                //    {
                //        Tool.in_depot = "是";
                //    }
                //    else
                //    {
                //        Tool.in_depot = "否";
                //    }

                //    if (Tool.user_name == "false")
                //    {
                //        Tool.user_name = "无去向(在库)";
                //    }
                //    if (Global.StationList.Find(t => t.station_id == Convert.ToInt32(Tool.station_id)) != null)
                //    {
                //        Tool.station_id = Global.StationList.Find(t => t.station_id == Convert.ToInt32(Tool.station_id)).name + '(' + Tool.station_id + ')';
                //    }
                //    else
                //    {
                //        Tool.station_id = "其他";
                //    }

                //}
                dataGridView1.DataSource = Global.ReadyTestTools;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                    var t = dataGridView1.Rows[i].Cells;
                }
                if (Global.ReadyTestTools.Count >= 0)
                {
                    dataGridView1.Columns[0].HeaderText = "工具标识";
                    dataGridView1.Columns[1].HeaderText = "传感器标识";
                    dataGridView1.Columns[2].HeaderText = "站点id标识";
                    dataGridView1.Columns[3].HeaderText = "科目id标识";
                    dataGridView1.Columns[4].HeaderText = "领用人id标识";
                    dataGridView1.Columns[5].HeaderText = "工具名称";
                    dataGridView1.Columns[6].HeaderText = "工具型号";
                    dataGridView1.Columns[7].HeaderText = "工具编号";
                    dataGridView1.Columns[8].HeaderText = "工具类别";
                    dataGridView1.Columns[9].HeaderText = "出厂日期";
                    dataGridView1.Columns[10].HeaderText = "购买日期";
                    dataGridView1.Columns[11].HeaderText = "试验日期";
                    dataGridView1.Columns[12].HeaderText = "试验周期(月)";
                    dataGridView1.Columns[13].HeaderText = "生命周期(月)";
                    dataGridView1.Columns[14].HeaderText = "生产厂商";
                    //               dataGridView1.Columns[15].HeaderText = "是否删除";
                    dataGridView1.Columns[15].HeaderText = "传感器名称";
                    dataGridView1.Columns[16].HeaderText = "科目名称";
                    dataGridView1.Columns[17].HeaderText = "下次试验日期";
                    dataGridView1.Columns[18].HeaderText = "报废日期";
                    dataGridView1.Columns[19].HeaderText = "是否在库";
                    dataGridView1.Columns[20].HeaderText = "去向";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }

            }
            return true;
        }
        async public Task<bool> TableToolsList(int cur)
        {
            int x = 1;
            if (cur <= 0)
                cur = 1;
            if (await Server.GetToolsList(Global.LoginInfo.user_id, Global.LoginInfo.user_code, cur, Global.PageNum))
            {
                maxPageNum = (Global.ToolsList.num.list_num / Convert.ToInt32(Global.ToolsList.num.page_num)) + 1;
                //               int list_num = Global.ToolsList.list.Count;
                //               page = 1;
                //               maxPageNum = (list_num / Global.PageNum) + 1;
                lb_cur.Text = "第" + Global.ToolsList.num.page + "页";
                //              var sum = Global.ToolsList.num.list_num / Global.PageNum;
                //             maxPageNum = sum == 0 ? 1 : sum;
                lb_sum.Text = "共" + maxPageNum + "页";
                curPage = cur;
                if (maxPageNum != comboBox1.Items.Count)
                {
                    Global.AddComboxNum(comboBox1, maxPageNum);
                }
                await Server.GetStationList();
                foreach (var Tool in Global.ToolsList.list)
                {
                    Tool.order = (x+Convert.ToInt32(Global.ToolsList.num.page_num)* (cur-1)).ToString();
                    x++;
                    if (Tool.user_id == "0")
                    {
                        Tool.user_id = "无人领用";
                    }      
                    if (Tool.in_depot == "true")
                    {
                        Tool.in_depot = "是";
                    }   
                    else
                    {
                        Tool.in_depot = "否";
                    }
                        
                    if(Tool.user_name=="false")
                    {
                        Tool.user_name = "无去向(在库)";
                    }
                    if(Global.StationList.Find(t => t.station_id == Convert.ToInt32(Tool.station_id))!=null)
                    {
                        Tool.station_id = Global.StationList.Find(t => t.station_id == Convert.ToInt32(Tool.station_id)).name + '(' + Tool.station_id + ')';
                    }
                    else
                    {
                        Tool.station_id = "其他";
                    }

                }
                dataGridView1.DataSource = Global.ToolsList.list;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                    var t = dataGridView1.Rows[i].Cells;
                }
                //               dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].HeaderText = "序号";
                dataGridView1.Columns[1].HeaderText = "工具标识";
                dataGridView1.Columns[2].HeaderText = "传感器标识";
                dataGridView1.Columns[3].HeaderText = "站点id标识";
                dataGridView1.Columns[4].HeaderText = "科目id标识";
                dataGridView1.Columns[5].HeaderText = "领用人id标识";
                dataGridView1.Columns[6].HeaderText = "工具名称";
                dataGridView1.Columns[7].HeaderText = "工具型号";
                dataGridView1.Columns[8].HeaderText = "工具编号";
                dataGridView1.Columns[9].HeaderText = "工具类别";
                dataGridView1.Columns[10].HeaderText = "出厂日期";
                dataGridView1.Columns[11].HeaderText = "购买日期";
                dataGridView1.Columns[12].HeaderText = "试验日期";
                dataGridView1.Columns[13].HeaderText = "试验周期(月)";
                dataGridView1.Columns[14].HeaderText = "生命周期(月)";
                dataGridView1.Columns[15].HeaderText = "生产厂商";
                //dataGridView1.Columns[15].HeaderText = "是否删除";
                dataGridView1.Columns[16].HeaderText = "传感器名称";
                dataGridView1.Columns[17].HeaderText = "科目名称";
                dataGridView1.Columns[18].HeaderText = "下次试验日期";
                dataGridView1.Columns[19].HeaderText = "报废日期";
                dataGridView1.Columns[20].HeaderText = "是否在库";
                dataGridView1.Columns[21].HeaderText = "去向";
            }
            return true;
        }
    }
}
