namespace Stocker
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnGetStock = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStockId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderColors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSelsectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openURLInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAddProd = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cBTemplateSettings = new System.Windows.Forms.ComboBox();
            this.tBstockId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbProdName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBProductUrl = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tBColorId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBSizeId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.columnHeaderColorId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSizeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetStock
            // 
            this.BtnGetStock.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnGetStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnGetStock.Location = new System.Drawing.Point(6, 101);
            this.BtnGetStock.Name = "BtnGetStock";
            this.BtnGetStock.Size = new System.Drawing.Size(75, 43);
            this.BtnGetStock.TabIndex = 1;
            this.BtnGetStock.Text = "Get";
            this.BtnGetStock.UseVisualStyleBackColor = false;
            this.BtnGetStock.Click += new System.EventHandler(this.BtnGetStock_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProduct,
            this.columnHeaderStockId,
            this.columnHeaderURL,
            this.columnHeaderColors,
            this.columnHeaderColorId,
            this.columnHeaderSizeId});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 180);
            this.listView1.MinimumSize = new System.Drawing.Size(893, 300);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1207, 300);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProduct
            // 
            this.columnHeaderProduct.Text = "Product name";
            this.columnHeaderProduct.Width = 80;
            // 
            // columnHeaderStockId
            // 
            this.columnHeaderStockId.Text = "Stock id";
            this.columnHeaderStockId.Width = 81;
            // 
            // columnHeaderURL
            // 
            this.columnHeaderURL.Text = "Product URL";
            this.columnHeaderURL.Width = 200;
            // 
            // columnHeaderColors
            // 
            this.columnHeaderColors.Text = "Colors/Sizes in Stock";
            this.columnHeaderColors.Width = 700;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSelsectedItemsToolStripMenuItem,
            this.openURLInBrowserToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 48);
            // 
            // deleteSelsectedItemsToolStripMenuItem
            // 
            this.deleteSelsectedItemsToolStripMenuItem.Name = "deleteSelsectedItemsToolStripMenuItem";
            this.deleteSelsectedItemsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteSelsectedItemsToolStripMenuItem.Text = "Delete selsected item(s)";
            this.deleteSelsectedItemsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelsectedItemsToolStripMenuItem_Click);
            // 
            // openURLInBrowserToolStripMenuItem
            // 
            this.openURLInBrowserToolStripMenuItem.Name = "openURLInBrowserToolStripMenuItem";
            this.openURLInBrowserToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openURLInBrowserToolStripMenuItem.Text = "Open URL in browser";
            this.openURLInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openURLInBrowserToolStripMenuItem_Click);
            // 
            // BtnAddProd
            // 
            this.BtnAddProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAddProd.Location = new System.Drawing.Point(1092, 101);
            this.BtnAddProd.Name = "BtnAddProd";
            this.BtnAddProd.Size = new System.Drawing.Size(110, 43);
            this.BtnAddProd.TabIndex = 2;
            this.BtnAddProd.Text = "Add product";
            this.BtnAddProd.UseVisualStyleBackColor = true;
            this.BtnAddProd.Click += new System.EventHandler(this.BtnAddProd_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 150);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1196, 24);
            this.progressBar1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Select template";
            // 
            // cBTemplateSettings
            // 
            this.cBTemplateSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBTemplateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cBTemplateSettings.FormattingEnabled = true;
            this.cBTemplateSettings.Items.AddRange(new object[] {
            "6pm.com",
            "saucony.com",
            "victoriassecret.com",
            "zappos.com"});
            this.cBTemplateSettings.Location = new System.Drawing.Point(14, 67);
            this.cBTemplateSettings.Name = "cBTemplateSettings";
            this.cBTemplateSettings.Size = new System.Drawing.Size(203, 21);
            this.cBTemplateSettings.TabIndex = 43;
            this.cBTemplateSettings.Text = "Custom";
            // 
            // tBstockId
            // 
            this.tBstockId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBstockId.Location = new System.Drawing.Point(223, 67);
            this.tBstockId.Name = "tBstockId";
            this.tBstockId.Size = new System.Drawing.Size(140, 20);
            this.tBstockId.TabIndex = 39;
            this.tBstockId.Text = "transBtns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(220, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "search stock id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Product URL";
            // 
            // TbProdName
            // 
            this.TbProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbProdName.Location = new System.Drawing.Point(14, 26);
            this.TbProdName.Name = "TbProdName";
            this.TbProdName.Size = new System.Drawing.Size(203, 20);
            this.TbProdName.TabIndex = 45;
            this.TbProdName.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Product Name";
            // 
            // tBProductUrl
            // 
            this.tBProductUrl.Location = new System.Drawing.Point(223, 26);
            this.tBProductUrl.Name = "tBProductUrl";
            this.tBProductUrl.Size = new System.Drawing.Size(979, 20);
            this.tBProductUrl.TabIndex = 36;
            this.tBProductUrl.Text = "http://www.6pm.com/adidas-go-to-performance-tank-top-black?zlfid=192&ref=pd_sims_" +
    "p_1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(400, 134);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Status";
            // 
            // tBColorId
            // 
            this.tBColorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBColorId.Location = new System.Drawing.Point(403, 67);
            this.tBColorId.Name = "tBColorId";
            this.tBColorId.Size = new System.Drawing.Size(140, 20);
            this.tBColorId.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(400, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "color id";
            // 
            // tBSizeId
            // 
            this.tBSizeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBSizeId.Location = new System.Drawing.Point(572, 67);
            this.tBSizeId.Name = "tBSizeId";
            this.tBSizeId.Size = new System.Drawing.Size(140, 20);
            this.tBSizeId.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(569, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "size id";
            // 
            // columnHeaderColorId
            // 
            this.columnHeaderColorId.Text = "Color id";
            // 
            // columnHeaderSizeId
            // 
            this.columnHeaderSizeId.Text = "Size id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 480);
            this.Controls.Add(this.tBSizeId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBColorId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TbProdName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBTemplateSettings);
            this.Controls.Add(this.tBstockId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBProductUrl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnAddProd);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.BtnGetStock);
            this.MinimumSize = new System.Drawing.Size(909, 519);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stocker -check if you have stock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnGetStock;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderProduct;
        private System.Windows.Forms.Button BtnAddProd;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBTemplateSettings;
        private System.Windows.Forms.TextBox tBstockId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBProductUrl;
        private System.Windows.Forms.ColumnHeader columnHeaderStockId;
        private System.Windows.Forms.ColumnHeader columnHeaderURL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteSelsectedItemsToolStripMenuItem;
        private System.Windows.Forms.TextBox TbProdName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderColors;
        private System.Windows.Forms.ToolStripMenuItem openURLInBrowserToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderColorId;
        private System.Windows.Forms.ColumnHeader columnHeaderSizeId;
        private System.Windows.Forms.TextBox tBColorId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBSizeId;
        private System.Windows.Forms.Label label6;
    }
}

