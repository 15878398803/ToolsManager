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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("台账报表");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("综合管理");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("预送检表");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("预报废表");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "定期检查",
            "任务类型1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("送检反馈");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("逾期记录");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("增购申请");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaintain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.删除DToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.帮助LToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.修改OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.添加NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ll_End = new System.Windows.Forms.LinkLabel();
            this.ll_Next = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ll_Last = new System.Windows.Forms.LinkLabel();
            this.ll_First = new System.Windows.Forms.LinkLabel();
            this.lb_cur = new System.Windows.Forms.Label();
            this.lb_sum = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewLeft
            // 
            this.listViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLeft.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.listViewLeft.Location = new System.Drawing.Point(3, 3);
            this.listViewLeft.MultiSelect = false;
            this.listViewLeft.Name = "listViewLeft";
            this.tableLayoutPanel2.SetRowSpan(this.listViewLeft, 4);
            this.listViewLeft.Size = new System.Drawing.Size(114, 406);
            this.listViewLeft.SmallImageList = this.imageList1;
            this.listViewLeft.TabIndex = 0;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.SmallIcon;
            this.listViewLeft.DoubleClick += new System.EventHandler(this.listViewLeft_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(332, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "跳至";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 删除DToolStripButton1
            // 
            this.删除DToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("删除DToolStripButton1.Image")));
            this.删除DToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.删除DToolStripButton1.Name = "删除DToolStripButton1";
            this.删除DToolStripButton1.Size = new System.Drawing.Size(53, 47);
            this.删除DToolStripButton1.Text = "删除(&D)";
            this.删除DToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.删除DToolStripButton1.Click += new System.EventHandler(this.删除ToolStripButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("新宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(123, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "表格名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(51, 47);
            this.打印PToolStripButton.Text = "打印(&P)";
            this.打印PToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 保存SToolStripButton
            // 
            this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
            this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton.Name = "保存SToolStripButton";
            this.保存SToolStripButton.Size = new System.Drawing.Size(51, 47);
            this.保存SToolStripButton.Text = "保存(&S)";
            this.保存SToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.保存SToolStripButton.Click += new System.EventHandler(this.保存SToolStripButton_Click);
            // 
            // 修改OToolStripButton
            // 
            this.修改OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("修改OToolStripButton.Image")));
            this.修改OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.修改OToolStripButton.Name = "修改OToolStripButton";
            this.修改OToolStripButton.Size = new System.Drawing.Size(54, 47);
            this.修改OToolStripButton.Text = "修改(&O)";
            this.修改OToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.修改OToolStripButton.Click += new System.EventHandler(this.修改ToolStripButton1_Click);
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
            this.添加NToolStripButton.Click += new System.EventHandler(this.添加ToolStripButton1_Click);
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
            this.toolStrip1.Size = new System.Drawing.Size(514, 50);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.listViewLeft, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(634, 412);
            this.tableLayoutPanel2.TabIndex = 1;
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(123, 385);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(508, 24);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // ll_End
            // 
            this.ll_End.AutoSize = true;
            this.ll_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_End.Location = new System.Drawing.Point(474, 0);
            this.ll_End.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_End.Name = "ll_End";
            this.ll_End.Size = new System.Drawing.Size(29, 26);
            this.ll_End.TabIndex = 3;
            this.ll_End.TabStop = true;
            this.ll_End.Text = "末页";
            this.ll_End.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_End.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ll_End_MouseClick);
            // 
            // ll_Next
            // 
            this.ll_Next.AutoSize = true;
            this.ll_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ll_Next.Location = new System.Drawing.Point(423, 0);
            this.ll_Next.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_Next.Name = "ll_Next";
            this.ll_Next.Size = new System.Drawing.Size(41, 26);
            this.ll_Next.TabIndex = 0;
            this.ll_Next.TabStop = true;
            this.ll_Next.Text = "下一页";
            this.ll_Next.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_Next.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Next_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(367, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 20);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ll_Last
            // 
            this.ll_Last.AutoSize = true;
            this.ll_Last.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_Last.Location = new System.Drawing.Point(283, 0);
            this.ll_Last.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_Last.Name = "ll_Last";
            this.ll_Last.Size = new System.Drawing.Size(41, 26);
            this.ll_Last.TabIndex = 1;
            this.ll_Last.TabStop = true;
            this.ll_Last.Text = "上一页";
            this.ll_Last.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_Last.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Last_MouseClick);
            // 
            // ll_First
            // 
            this.ll_First.AutoSize = true;
            this.ll_First.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ll_First.Location = new System.Drawing.Point(232, 0);
            this.ll_First.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ll_First.Name = "ll_First";
            this.ll_First.Size = new System.Drawing.Size(41, 26);
            this.ll_First.TabIndex = 2;
            this.ll_First.TabStop = true;
            this.ll_First.Text = "第一页";
            this.ll_First.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_First.MouseClick += new System.Windows.Forms.MouseEventHandler(this.First_MouseClick);
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_cur.Location = new System.Drawing.Point(163, 0);
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
            this.lb_sum.Location = new System.Drawing.Point(118, 0);
            this.lb_sum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_sum.Name = "lb_sum";
            this.lb_sum.Size = new System.Drawing.Size(35, 26);
            this.lb_sum.TabIndex = 6;
            this.lb_sum.Text = "共0页";
            this.lb_sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(123, 82);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(508, 297);
            this.dataGridView1.TabIndex = 1;
            // 
            // FormMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMaintain";
            this.Text = "维护管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMaintain_FormClosing);
            this.Load += new System.EventHandler(this.FormMaintain_Load);
            this.Shown += new System.EventHandler(this.FormMaintain_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton 删除DToolStripButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton 帮助LToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripButton 修改OToolStripButton;
        private System.Windows.Forms.ToolStripButton 添加NToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel ll_End;
        private System.Windows.Forms.LinkLabel ll_Next;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.LinkLabel ll_Last;
        private System.Windows.Forms.LinkLabel ll_First;
        private System.Windows.Forms.Label lb_cur;
        private System.Windows.Forms.Label lb_sum;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}