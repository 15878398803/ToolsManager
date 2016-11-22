namespace ToolsManager
{
    partial class FormRecord
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("领还明细");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("现存库存");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("我的领用");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("单号事件记录表");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecord));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.lb_cur = new System.Windows.Forms.Label();
            this.lb_sum = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.添加NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.修改OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.删除DToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.刷新ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.帮助LToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            listViewItem1.Tag = "Details";
            listViewItem2.Tag = "inventory";
            listViewItem3.Tag = "mine";
            listViewItem4.Tag = "event";
            this.listViewLeft.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listViewLeft.Location = new System.Drawing.Point(3, 3);
            this.listViewLeft.MultiSelect = false;
            this.listViewLeft.Name = "listViewLeft";
            this.tableLayoutPanel3.SetRowSpan(this.listViewLeft, 4);
            this.listViewLeft.Size = new System.Drawing.Size(144, 431);
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
            this.label2.Location = new System.Drawing.Point(275, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "跳至";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("新宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(153, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(451, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "表格名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.listViewLeft, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.toolStrip1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridView1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(607, 437);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel2.Controls.Add(this.linkLabel2);
            this.flowLayoutPanel2.Controls.Add(this.comboBox1);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.linkLabel3);
            this.flowLayoutPanel2.Controls.Add(this.linkLabel4);
            this.flowLayoutPanel2.Controls.Add(this.lb_cur);
            this.flowLayoutPanel2.Controls.Add(this.lb_sum);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(153, 410);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(451, 24);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Location = new System.Drawing.Point(417, 0);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 26);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "末页";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel2.Location = new System.Drawing.Point(366, 0);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 26);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "下一页";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(310, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 20);
            this.comboBox1.TabIndex = 8;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel3.Location = new System.Drawing.Point(226, 0);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(41, 26);
            this.linkLabel3.TabIndex = 1;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "上一页";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel4.Location = new System.Drawing.Point(175, 0);
            this.linkLabel4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(41, 26);
            this.linkLabel4.TabIndex = 2;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "第一页";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_cur.Location = new System.Drawing.Point(106, 0);
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
            this.lb_sum.Location = new System.Drawing.Point(61, 0);
            this.lb_sum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_sum.Name = "lb_sum";
            this.lb_sum.Size = new System.Drawing.Size(35, 26);
            this.lb_sum.TabIndex = 6;
            this.lb_sum.Text = "共0页";
            this.lb_sum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加NToolStripButton,
            this.修改OToolStripButton,
            this.删除DToolStripButton1,
            this.刷新ToolStripButton1,
            this.保存SToolStripButton,
            this.打印PToolStripButton,
            this.帮助LToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(150, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(457, 50);
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
            // 
            // 修改OToolStripButton
            // 
            this.修改OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("修改OToolStripButton.Image")));
            this.修改OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.修改OToolStripButton.Name = "修改OToolStripButton";
            this.修改OToolStripButton.Size = new System.Drawing.Size(54, 47);
            this.修改OToolStripButton.Text = "修改(&O)";
            this.修改OToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 删除DToolStripButton1
            // 
            this.删除DToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("删除DToolStripButton1.Image")));
            this.删除DToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.删除DToolStripButton1.Name = "删除DToolStripButton1";
            this.删除DToolStripButton1.Size = new System.Drawing.Size(53, 47);
            this.删除DToolStripButton1.Text = "删除(&D)";
            this.删除DToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // 刷新ToolStripButton1
            // 
            this.刷新ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("刷新ToolStripButton1.Image")));
            this.刷新ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.刷新ToolStripButton1.Name = "刷新ToolStripButton1";
            this.刷新ToolStripButton1.Size = new System.Drawing.Size(36, 47);
            this.刷新ToolStripButton1.Text = "刷新";
            this.刷新ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.刷新ToolStripButton1.Click += new System.EventHandler(this.刷新ToolStripButton1_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(153, 82);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(451, 322);
            this.dataGridView1.TabIndex = 1;
            // 
            // FormRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 437);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MinimumSize = new System.Drawing.Size(545, 417);
            this.Name = "FormRecord";
            this.Text = "领还记录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRecord_FormClosing);
            this.Load += new System.EventHandler(this.FormRecord_Load);
            this.Shown += new System.EventHandler(this.FormRecord_Shown);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label lb_cur;
        private System.Windows.Forms.Label lb_sum;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 添加NToolStripButton;
        private System.Windows.Forms.ToolStripButton 修改OToolStripButton;
        private System.Windows.Forms.ToolStripButton 删除DToolStripButton1;
        private System.Windows.Forms.ToolStripButton 刷新ToolStripButton1;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.ToolStripButton 帮助LToolStripButton;
    }
}