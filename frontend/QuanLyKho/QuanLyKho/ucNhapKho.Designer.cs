namespace QuanLyKho
{
    partial class ucNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNhapKho));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Thoat_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.LamTuoi_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lvNhapKho = new DevComponents.DotNetBar.Controls.ListViewEx();
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
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1359, 145);
            this.label1.TabIndex = 3;
            this.label1.Text = "NHẬP KHO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Thoat_toolStripButton,
            this.LamTuoi_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 145);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1359, 25);
            this.toolStrip1.TabIndex = 72;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Thoat_toolStripButton
            // 
            this.Thoat_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("Thoat_toolStripButton.Image")));
            this.Thoat_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Thoat_toolStripButton.Name = "Thoat_toolStripButton";
            this.Thoat_toolStripButton.Size = new System.Drawing.Size(61, 22);
            this.Thoat_toolStripButton.Text = "Thoát";
            this.Thoat_toolStripButton.Click += new System.EventHandler(this.Thoat_toolStripButton_Click);
            // 
            // LamTuoi_toolStripButton
            // 
            this.LamTuoi_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("LamTuoi_toolStripButton.Image")));
            this.LamTuoi_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LamTuoi_toolStripButton.Name = "LamTuoi_toolStripButton";
            this.LamTuoi_toolStripButton.Size = new System.Drawing.Size(86, 22);
            this.LamTuoi_toolStripButton.Text = "Thêm mới";
            this.LamTuoi_toolStripButton.Click += new System.EventHandler(this.LamTuoi_toolStripButton_Click);
            // 
            // lvNhapKho
            // 
            // 
            // 
            // 
            this.lvNhapKho.Border.Class = "ListViewBorder";
            this.lvNhapKho.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvNhapKho.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMANV,
            this.colHOTEN,
            this.colNGAYSINH,
            this.colGIOITINH,
            this.colCMND,
            this.colDIENTHOAI,
            this.columnHeader1});
            this.lvNhapKho.DisabledBackColor = System.Drawing.Color.Empty;
            this.lvNhapKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNhapKho.FullRowSelect = true;
            this.lvNhapKho.GridLines = true;
            this.lvNhapKho.HideSelection = false;
            this.lvNhapKho.Location = new System.Drawing.Point(0, 170);
            this.lvNhapKho.Name = "lvNhapKho";
            this.lvNhapKho.Size = new System.Drawing.Size(1359, 581);
            this.lvNhapKho.TabIndex = 73;
            this.lvNhapKho.UseCompatibleStateImageBehavior = false;
            this.lvNhapKho.View = System.Windows.Forms.View.Details;
            this.lvNhapKho.DoubleClick += new System.EventHandler(this.lvNhapKho_DoubleClick);
            // 
            // colMANV
            // 
            this.colMANV.Text = "Mã";
            this.colMANV.Width = 57;
            // 
            // colHOTEN
            // 
            this.colHOTEN.Text = "Ngày Nhập";
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
            this.colGIOITINH.Width = 80;
            // 
            // colCMND
            // 
            this.colCMND.Text = "Nhà Cung Cấp";
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
            // ucNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvNhapKho);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "ucNhapKho";
            this.Size = new System.Drawing.Size(1359, 751);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Thoat_toolStripButton;
        private System.Windows.Forms.ToolStripButton LamTuoi_toolStripButton;
        public DevComponents.DotNetBar.Controls.ListViewEx lvNhapKho;
        private System.Windows.Forms.ColumnHeader colMANV;
        private System.Windows.Forms.ColumnHeader colHOTEN;
        private System.Windows.Forms.ColumnHeader colNGAYSINH;
        private System.Windows.Forms.ColumnHeader colGIOITINH;
        private System.Windows.Forms.ColumnHeader colCMND;
        private System.Windows.Forms.ColumnHeader colDIENTHOAI;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
