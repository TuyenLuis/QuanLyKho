namespace QuanLyKho
{
    partial class ucXuatKho
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucXuatKho));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Thoat_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ThemMoi_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lvXuatKho = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.colMANV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHOTEN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNGAYSINH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGIOITINH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMND = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDIENTHOAI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1309, 178);
            this.label1.TabIndex = 4;
            this.label1.Text = "XUẤT KHO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Thoat_toolStripButton,
            this.ThemMoi_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 178);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1309, 28);
            this.toolStrip1.TabIndex = 73;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Thoat_toolStripButton
            // 
            this.Thoat_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("Thoat_toolStripButton.Image")));
            this.Thoat_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Thoat_toolStripButton.Name = "Thoat_toolStripButton";
            this.Thoat_toolStripButton.Size = new System.Drawing.Size(77, 25);
            this.Thoat_toolStripButton.Text = "Thoát";
            this.Thoat_toolStripButton.Click += new System.EventHandler(this.Thoat_toolStripButton_Click);
            // 
            // ThemMoi_toolStripButton
            // 
            this.ThemMoi_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ThemMoi_toolStripButton.Image")));
            this.ThemMoi_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThemMoi_toolStripButton.Name = "ThemMoi_toolStripButton";
            this.ThemMoi_toolStripButton.Size = new System.Drawing.Size(108, 25);
            this.ThemMoi_toolStripButton.Text = "Thêm mới";
            this.ThemMoi_toolStripButton.Click += new System.EventHandler(this.ThemMoi_toolStripButton_Click);
            // 
            // lvXuatKho
            // 
            // 
            // 
            // 
            this.lvXuatKho.Border.Class = "ListViewBorder";
            this.lvXuatKho.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvXuatKho.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMANV,
            this.colHOTEN,
            this.colNGAYSINH,
            this.colGIOITINH,
            this.colCMND,
            this.colDIENTHOAI,
            this.columnHeader1});
            this.lvXuatKho.DisabledBackColor = System.Drawing.Color.Empty;
            this.lvXuatKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvXuatKho.FullRowSelect = true;
            this.lvXuatKho.GridLines = true;
            this.lvXuatKho.HideSelection = false;
            this.lvXuatKho.Location = new System.Drawing.Point(0, 206);
            this.lvXuatKho.Margin = new System.Windows.Forms.Padding(4);
            this.lvXuatKho.Name = "lvXuatKho";
            this.lvXuatKho.Size = new System.Drawing.Size(1309, 516);
            this.lvXuatKho.TabIndex = 74;
            this.lvXuatKho.UseCompatibleStateImageBehavior = false;
            this.lvXuatKho.View = System.Windows.Forms.View.Details;
            this.lvXuatKho.DoubleClick += new System.EventHandler(this.lvXuatKho_DoubleClick);
            // 
            // colMANV
            // 
            this.colMANV.Text = "Mã";
            this.colMANV.Width = 57;
            // 
            // colHOTEN
            // 
            this.colHOTEN.Text = "Ngày Xuất";
            this.colHOTEN.Width = 200;
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.Text = "Kho";
            this.colNGAYSINH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNGAYSINH.Width = 130;
            // 
            // colGIOITINH
            // 
            this.colGIOITINH.Text = "Nhân Viên";
            this.colGIOITINH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colGIOITINH.Width = 129;
            // 
            // colCMND
            // 
            this.colCMND.Text = "Địa Chỉ";
            this.colCMND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCMND.Width = 150;
            // 
            // colDIENTHOAI
            // 
            this.colDIENTHOAI.Text = "Tổng Tiền";
            this.colDIENTHOAI.Width = 181;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ghi Chú";
            // 
            // ucXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvXuatKho);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucXuatKho";
            this.Size = new System.Drawing.Size(1309, 722);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Thoat_toolStripButton;
        private System.Windows.Forms.ToolStripButton ThemMoi_toolStripButton;
        public DevComponents.DotNetBar.Controls.ListViewEx lvXuatKho;
        private System.Windows.Forms.ColumnHeader colMANV;
        private System.Windows.Forms.ColumnHeader colHOTEN;
        private System.Windows.Forms.ColumnHeader colNGAYSINH;
        private System.Windows.Forms.ColumnHeader colGIOITINH;
        private System.Windows.Forms.ColumnHeader colCMND;
        private System.Windows.Forms.ColumnHeader colDIENTHOAI;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
