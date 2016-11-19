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
        private int curPage;
        /// <summary>
        /// 总页数
        /// </summary>
        private int maxPageNum;
        /// <summary>
        /// 标记位，防止comboBox1的comboBox1_SelectedIndexChanged误触发
        /// </summary>
        private bool isInit;
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
                flowLayoutPanel1.Enabled = false;
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
                    break;
                case "员工权限":
                    break;
            }
        }

        async private void 修改OToolStripButton_Click(object sender, EventArgs e)
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
                        var f = new FormWorkType();
                        f.IsUpdate = true;
                        f.WorkType = Global.WorkTypeList.Find(t => t.work_id == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value as string);
                        f.ShowDialog();
                        await WorkTypeList();
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
    }
}
