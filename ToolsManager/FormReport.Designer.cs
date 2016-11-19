namespace ToolsManager
{
    partial class FormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("申购计划");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("局申购汇总");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("报废记录");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("局报废汇总");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("工作类别");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("缺陷类别");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("员工权限");
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ll_End = new System.Windows.Forms.LinkLabel();
            this.ll_Next = new System.Windows.Forms.LinkLabel();
            this.ll_Last = new System.Windows.Forms.LinkLabel();
            this.ll_First = new System.Windows.Forms.LinkLabel();
            this.lb_cur = new System.Windows.Forms.Label();
            this.lb_sum = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.添加NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.修改OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.帮助LToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.删除DToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ll_End);
            this.flowLayoutPanel1.Controls.Add(this.ll_Next);
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.ll_Last);
            this.flowLayoutPanel1.Controls.Add(this.ll_First);
            this.flowLayoutPanel1.Controls.Add(this.lb_cur);
            this.flowLayoutPanel1.Controls.Add(this.lb_sum);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(123, 438);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(523, 24);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // ll_End
            // 
            this.ll_End.AutoSize = true;
            this.ll_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_End.Location = new System.Drawing.Point(489, 0);
            this.ll_End.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_End.Name = "ll_End";
            this.ll_End.Size = new System.Drawing.Size(29, 26);
            this.ll_End.TabIndex = 3;
            this.ll_End.TabStop = true;
            this.ll_End.Text = "末页";
            this.ll_End.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ll_Next
            // 
            this.ll_Next.AutoSize = true;
            this.ll_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ll_Next.Location = new System.Drawing.Point(438, 0);
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
            this.ll_Last.Location = new System.Drawing.Point(298, 0);
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
            this.ll_First.Location = new System.Drawing.Point(247, 0);
            this.ll_First.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_First.Name = "ll_First";
            this.ll_First.Size = new System.Drawing.Size(41, 26);
            this.ll_First.TabIndex = 2;
            this.ll_First.TabStop = true;
            this.ll_First.Text = "第一页";
            this.ll_First.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_cur.Location = new System.Drawing.Point(178, 0);
            this.lb_cur.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_cur.Name = "lb_cur";
            this.lb_cur.Size = new System.Drawing.Size(59, 26);
            this.lb_cur.TabIndex = 7;
            this.lb_cur.Text = "当前第0页";
            this.lb_cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_sum
            // 
            this.lb_sum.AutoSize = true;
            this.lb_sum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_sum.Location = new System.Drawing.Point(133, 0);
            this.lb_sum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_sum.Name = "lb_sum";
            this.lb_sum.Size = new System.Drawing.Size(35, 26);
            this.lb_sum.TabIndex = 6;
            this.lb_sum.Text = "共0页";
            this.lb_sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "未标题-2.jpg");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(123, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(523, 350);
            this.dataGridView1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.listViewLeft, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(649, 465);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加NToolStripButton,
            this.修改OToolStripButton,
            this.删除DToolStripButton1,
            this.保存SToolStripButton,
            this.打印PToolStripButton,
            this.帮助LToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(120, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(529, 50);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 添加NToolStripButton
            // 
            this.添加NToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("添加NToolStripButton.Image")));
            this.添加NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.添加NToolStripButton.Name = "添加NToolStripButton";
            this.添加NToolStripButton.Size = new System.Drawing.Size(54, 47);
            this.添加NToolStripButton.Text = "添加(&N)";
            this.添加NToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.添加NToolStripButton.ToolTipText = "添加(N)";
            this.添加NToolStripButton.Click += new System.EventHandler(this.添加NToolStripButton_Click);
            // 
            // 修改OToolStripButton
            // 
            this.修改OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("修改OToolStripButton.Image")));
            this.修改OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.修改OToolStripButton.Name = "修改OToolStripButton";
            this.修改OToolStripButton.Size = new System.Drawing.Size(54, 47);
            this.修改OToolStripButton.Text = "修改(&O)";
            this.修改OToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.修改OToolStripButton.Click += new System.EventHandler(this.修改OToolStripButton_Click);
            // 
            // 保存SToolStripButton
            // 
            this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
            this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton.Name = "保存SToolStripButton";
            this.保存SToolStripButton.Size = new System.Drawing.Size(51, 47);
            this.保存SToolStripButton.Text = "保存(&S)";
            this.保存SToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(51, 47);
            this.打印PToolStripButton.Text = "打印(&P)";
            this.打印PToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 帮助LToolStripButton
            // 
            this.帮助LToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("帮助LToolStripButton.Image")));
            this.帮助LToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.帮助LToolStripButton.Name = "帮助LToolStripButton";
            this.帮助LToolStripButton.Size = new System.Drawing.Size(50, 47);
            this.帮助LToolStripButton.Text = "帮助(&L)";
            this.帮助LToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("新宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(123, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "表格名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 删除DToolStripButton1
            // 
            this.删除DToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("删除DToolStripButton1.Image")));
            this.删除DToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.删除DToolStripButton1.Name = "删除DToolStripButton1";
            this.删除DToolStripButton1.Size = new System.Drawing.Size(53, 47);
            this.删除DToolStripButton1.Text = "删除(&D)";
            this.删除DToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.删除DToolStripButton1.Click += new System.EventHandler(this.删除DToolStripButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(382, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 20);
            this.comboBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(347, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "跳至";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewLeft
            // 
            this.listViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLeft.HideSelection = false;
            this.listViewLeft.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.listViewLeft.Location = new System.Drawing.Point(3, 3);
            this.listViewLeft.MultiSelect = false;
            this.listViewLeft.Name = "listViewLeft";
            this.tableLayoutPanel2.SetRowSpan(this.listViewLeft, 4);
            this.listViewLeft.Size = new System.Drawing.Size(114, 459);
            this.listViewLeft.SmallImageList = this.imageList1;
            this.listViewLeft.TabIndex = 0;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.SmallIcon;
            this.listViewLeft.DoubleClick += new System.EventHandler(this.listViewLeft_DoubleClick);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 465);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(545, 417);
            this.Name = "FormReport";
            this.Text = "业务报表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReport_FormClosing);
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.Shown += new System.EventHandler(this.FormReport_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel ll_End;
        private System.Windows.Forms.LinkLabel ll_Next;
        private System.Windows.Forms.LinkLabel ll_Last;
        private System.Windows.Forms.LinkLabel ll_First;
        private System.Windows.Forms.Label lb_cur;
        private System.Windows.Forms.Label lb_sum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 添加NToolStripButton;
        private System.Windows.Forms.ToolStripButton 修改OToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.ToolStripButton 帮助LToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton 删除DToolStripButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewLeft;
    }
}