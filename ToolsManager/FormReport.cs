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
    public partial class FormReport : Form
    {
        private string lastTable;
        /// <summary>
        /// 当前页码
        /// </summary>
        private int maxPageNum;
        /// <summary>
        /// 标记位，防止comboBox1的comboBox1_SelectedIndexChanged误触发
        /// </summary>
        private int page = 0;
        private DataGridViewCellStyle color_danger = new DataGridViewCellStyle();

        public FormReport()
        {
            InitializeComponent();
            color_danger.BackColor = Color.Red;
            color_danger.ForeColor = Color.White;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FormReport = null;
        }
        async public Task<bool> WorkTypeList()
        {
            if (await Server.GetWorkTypeList())
            {
                flowLayoutPanel1.Enabled = true;
                lb_cur.Text = "第1页";
                lb_sum.Text = "共1页";

                dataGridView1.DataSource = Global.WorkTypeList;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                    var t = dataGridView1.Rows[i].Cells;

                }

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    //全部列不可修改
                    dataGridView1.Columns[i].ReadOnly = true;
                    //拉伸列宽来填满表格
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }

            }
            return true;
        }

        async private void listViewLeft_DoubleClick(object sender, EventArgs e)
        {
            ll_First.Text = "第一页";
            switch (listViewLeft.SelectedItems[0].Text)
            {
                case "申购计划":
                    lastTable = "申购计划";
                    break;
                case "局申购汇总":
                    lastTable = "局申购汇总";
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    break;
                case "局报废汇总":
                    lastTable = "局报废汇总";
                    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别";
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    break;
            }
        }

        private void FormReport_Shown(object sender, EventArgs e)
        {

        }

        async private void 添加NToolStripButton_Click(object sender, EventArgs e)
        {
            switch (lastTable)
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
                    var f = new FormWorkType();
                    f.ShowDialog();
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    var t = new FormUpdateInsertDefect();
                    t.ShowDialog();
                    //                   await ReadDefectsList(page);
                    break;
                case "员工权限":
                    break;
            }
        }

        async private void 修改OToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                switch (lastTable)
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
                        var f = new FormWorkType();
                        f.IsUpdate = true;
                        f.WorkType = Global.WorkTypeList.Find(t => t.work_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);
                        f.ShowDialog();
                        await WorkTypeList();
                        break;
                    case "缺陷类别":
                        var d = new FormUpdateInsertDefect();
                        if (page != 0)
                        {
                            d.Defect = Global.DefectList.Find(t => t.defect_id == dataGridView1.SelectedRows[0].Cells[0].Value as string);
                            d.ShowDialog();
                        }

                        //                       await ReadDefectsList(page);
                        break;
                    case "员工权限":
                        break;
                }
            }
            else
            {
                MessageBox.Show("请先选择要修改的数据");
            }
        }

        async private void 删除DToolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                switch (lastTable)
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

                        var worktype = Global.WorkTypeList.Find(t => t.work_id == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value as string);

                        if (MessageBox.Show("您确定要删除工作类别 " + worktype.name + " 吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (await Server.DeleteWork(Global.LoginInfo.user_id, Global.LoginInfo.user_code, Convert.ToInt32(worktype.work_id)))
                            {
                                MessageBox.Show("删除工作类别 " + worktype.name + " 成功");
                                await WorkTypeList();
                            }

                        }
                        break;
                    case "缺陷类别":
                        break;
                    case "员工权限":
                        break;
                }
            }
            else
            {
                MessageBox.Show("请先选择要修改的数据");
            }
        }

        private void 刷新toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listViewLeft.SelectedItems.Count > 0)
                listViewLeft_DoubleClick(null, null);
        }
        async private void ll_Next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page++;
            switch (lastTable)
            {
                case "申购计划":
                    lastTable = "申购计划";
                    break;
                case "局申购汇总":
                    lastTable = "局申购汇总";
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    break;
                case "局报废汇总":
                    lastTable = "局报废汇总";
                    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别";
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    break;
            }
        }

        async private void ll_End_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            switch (lastTable)
            {
                case "申购计划":
                    lastTable = "申购计划";
                    break;
                case "局申购汇总":
                    lastTable = "局申购汇总";
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    break;
                case "局报废汇总":
                    lastTable = "局报废汇总";
                    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别"; 
                    await ReadDefectsList(Global.ToolClass.Count);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    break;
            }
        }

        async private void ll_Last_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page--;
            switch (lastTable)
            {
                case "申购计划":
                    lastTable = "申购计划";
                    break;
                case "局申购汇总":
                    lastTable = "局申购汇总";
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    break;
                case "局报废汇总":
                    lastTable = "局报废汇总";
                    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别";
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    break;
            }
        }

        async private void ll_First_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            page = 0;
            switch (lastTable)
            {
                case "申购计划":
                    lastTable = "申购计划";
                    break;
                case "局申购汇总":
                    lastTable = "局申购汇总";
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    break;
                case "局报废汇总":
                    lastTable = "局报废汇总";
                    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别";
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    break;
            }
        }

        async private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = Convert.ToInt32(comboBox1.Text);
            switch (lastTable)
            {
                case "申购计划":
                    lastTable = "申购计划";
                    break;
                case "局申购汇总":
                    lastTable = "局申购汇总";
                    break;
                case "报废记录":
                    lastTable = "报废记录";
                    break;
                case "局报废汇总":
                    lastTable = "局报废汇总";
                    break;
                case "工作类别":
                    lastTable = "工作类别";
                    await WorkTypeList();
                    break;
                case "缺陷类别":
                    lastTable = "缺陷类别";
                    await ReadDefectsList(page);
                    break;
                case "员工权限":
                    lastTable = "员工权限";
                    break;
            }
        }


        async public Task<bool> ReadDefectsList(int page)
        {
            ll_First.Text = "首页";
            if (page == 0)
            {
                await Server.GetToolClasses();
                for (int x = 1; x <= Global.ToolClass.Count; x++)
                {
                    Global.ToolClass[x - 1].page_num = x;
                }

                lb_cur.Text = "目录页";
                lb_sum.Text = "共" + Global.ToolClass.Count + "页";

                comboBox1.Items.Clear();
                for (int i = 0; i <= Global.ToolClass.Count; i++)
                {
                    comboBox1.Items.Add(i);
                }

                dataGridView1.DataSource = Global.ToolClass;
                dataGridView1.RowHeadersVisible = false;
                if (Global.ToolClass.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "页码";
                    dataGridView1.Columns[1].HeaderText = "科目id标识";
                    dataGridView1.Columns[2].HeaderText = "科目名称";
                    dataGridView1.Columns[3].HeaderText = "备注";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }

            }
            else if (await Server.GetDefectList(Convert.ToInt32(Global.ToolClass.Find(t => t.page_num == page).class_id)))
            {
                //int list_num = Global.DefectList.Count;
                //maxPageNum = ( list_num / 100 ) + 1;
                //lb_cur.Text = "第" + page + "页";
                //lb_sum.Text = "共" + Global.ToolClass.Count + "页";
                //if (Global.ToolClass.Count != comboBox1.Items.Count)
                //{
                //    comboBox1.Items.Clear();
                //    for (int i = 0; i <= Global.ToolClass.Count; i++)
                //    {
                //        comboBox1.Items.Add(i);
                //    }
                //}
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
