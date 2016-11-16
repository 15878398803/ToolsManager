namespace ToolsManager
{
    partial class FormMaintain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("上一页");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("下一页");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("台账报表");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("综合管理");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("预送检表");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("预报废表");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("定期检查");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("送检反馈");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("逾期记录");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("增购申请");
            this.listViewTop = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ll_Next = new System.Windows.Forms.LinkLabel();
            this.ll_Last = new System.Windows.Forms.LinkLabel();
            this.ll_First = new System.Windows.Forms.LinkLabel();
            this.ll_End = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ll_Goto = new System.Windows.Forms.LinkLabel();
            this.lb_sum = new System.Windows.Forms.Label();
            this.lb_cur = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTop
            // 
            this.listViewTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTop.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listViewTop.LargeImageList = this.imageList1;
            this.listViewTop.Location = new System.Drawing.Point(3, 3);
            this.listViewTop.Name = "listViewTop";
            this.listViewTop.Size = new System.Drawing.Size(629, 81);
            this.listViewTop.TabIndex = 1;
            this.listViewTop.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.85442F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.14558F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 462);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.36728F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.63272F));
            this.tableLayoutPanel2.Controls.Add(this.listViewLeft, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 90);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(629, 369);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listViewLeft
            // 
            this.listViewLeft.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLeft.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.listViewLeft.Location = new System.Drawing.Point(3, 3);
            this.listViewLeft.MultiSelect = false;
            this.listViewLeft.Name = "listViewLeft";
            this.tableLayoutPanel2.SetRowSpan(this.listViewLeft, 2);
            this.listViewLeft.Size = new System.Drawing.Size(122, 363);
            this.listViewLeft.SmallImageList = this.imageList1;
            this.listViewLeft.TabIndex = 0;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.SmallIcon;
            this.listViewLeft.DoubleClick += new System.EventHandler(this.listViewLeft_DoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(131, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(495, 333);
            this.dataGridView1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ll_End);
            this.flowLayoutPanel1.Controls.Add(this.ll_Next);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.ll_Goto);
            this.flowLayoutPanel1.Controls.Add(this.ll_Last);
            this.flowLayoutPanel1.Controls.Add(this.ll_First);
            this.flowLayoutPanel1.Controls.Add(this.lb_cur);
            this.flowLayoutPanel1.Controls.Add(this.lb_sum);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(131, 342);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(495, 24);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // ll_Next
            // 
            this.ll_Next.AutoSize = true;
            this.ll_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ll_Next.Location = new System.Drawing.Point(410, 0);
            this.ll_Next.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_Next.Name = "ll_Next";
            this.ll_Next.Size = new System.Drawing.Size(41, 26);
            this.ll_Next.TabIndex = 0;
            this.ll_Next.TabStop = true;
            this.ll_Next.Text = "下一页";
            this.ll_Next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ll_Last
            // 
            this.ll_Last.AutoSize = true;
            this.ll_Last.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Last.Location = new System.Drawing.Point(288, 0);
            this.ll_Last.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_Last.Name = "ll_Last";
            this.ll_Last.Size = new System.Drawing.Size(41, 26);
            this.ll_Last.TabIndex = 1;
            this.ll_Last.TabStop = true;
            this.ll_Last.Text = "上一页";
            this.ll_Last.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ll_First
            // 
            this.ll_First.AutoSize = true;
            this.ll_First.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_First.Location = new System.Drawing.Point(237, 0);
            this.ll_First.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_First.Name = "ll_First";
            this.ll_First.Size = new System.Drawing.Size(41, 26);
            this.ll_First.TabIndex = 2;
            this.ll_First.TabStop = true;
            this.ll_First.Text = "第一页";
            this.ll_First.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ll_End
            // 
            this.ll_End.AutoSize = true;
            this.ll_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_End.Location = new System.Drawing.Point(461, 0);
            this.ll_End.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_End.Name = "ll_End";
            this.ll_End.Size = new System.Drawing.Size(29, 26);
            this.ll_End.TabIndex = 3;
            this.ll_End.TabStop = true;
            this.ll_End.Text = "末页";
            this.ll_End.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(368, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "1";
            // 
            // ll_Goto
            // 
            this.ll_Goto.AutoSize = true;
            this.ll_Goto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Goto.Location = new System.Drawing.Point(339, 0);
            this.ll_Goto.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ll_Goto.Name = "ll_Goto";
            this.ll_Goto.Size = new System.Drawing.Size(29, 26);
            this.ll_Goto.TabIndex = 5;
            this.ll_Goto.TabStop = true;
            this.ll_Goto.Text = "跳至";
            this.ll_Goto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_sum
            // 
            this.lb_sum.AutoSize = true;
            this.lb_sum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_sum.Location = new System.Drawing.Point(123, 0);
            this.lb_sum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_sum.Name = "lb_sum";
            this.lb_sum.Size = new System.Drawing.Size(35, 26);
            this.lb_sum.TabIndex = 6;
            this.lb_sum.Text = "共0页";
            this.lb_sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_cur.Location = new System.Drawing.Point(168, 0);
            this.lb_cur.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_cur.Name = "lb_cur";
            this.lb_cur.Size = new System.Drawing.Size(59, 26);
            this.lb_cur.TabIndex = 7;
            this.lb_cur.Text = "当前第0页";
            this.lb_cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMaintain";
            this.Text = "维护管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMaintain_FormClosing);
            this.Load += new System.EventHandler(this.FormMaintain_Load);
            this.Shown += new System.EventHandler(this.FormMaintain_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTop;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel ll_End;
        private System.Windows.Forms.LinkLabel ll_Next;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel ll_Goto;
        private System.Windows.Forms.LinkLabel ll_Last;
        private System.Windows.Forms.LinkLabel ll_First;
        private System.Windows.Forms.Label lb_sum;
        private System.Windows.Forms.Label lb_cur;
    }
}