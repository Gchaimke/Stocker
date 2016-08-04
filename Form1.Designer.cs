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
            this.columnHeaderStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStockId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSizes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderColors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSelsectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetStock
            // 
            this.BtnGetStock.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnGetStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnGetStock.Location = new System.Drawing.Point(6, 400);
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
            this.columnHeaderStock,
            this.columnHeaderStockId,
            this.columnHeaderURL,
            this.columnHeaderSizes,
            this.columnHeaderColors});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 93);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(888, 300);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProduct
            // 
            this.columnHeaderProduct.Text = "Product name";
            this.columnHeaderProduct.Width = 120;
            // 
            // columnHeaderStock
            // 
            this.columnHeaderStock.Text = "Stock";
            this.columnHeaderStock.Width = 120;
            // 
            // columnHeaderStockId
            // 
            this.columnHeaderStockId.Text = "Stock id";
            this.columnHeaderStockId.Width = 90;
            // 
            // columnHeaderURL
            // 
            this.columnHeaderURL.Text = "Product URL";
            this.columnHeaderURL.Width = 320;
            // 
            // columnHeaderSizes
            // 
            this.columnHeaderSizes.Text = "Sizes";
            this.columnHeaderSizes.Width = 120;
            // 
            // columnHeaderColors
            // 
            this.columnHeaderColors.Text = "Colors";
            this.columnHeaderColors.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSelsectedItemsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 26);
            // 
            // deleteSelsectedItemsToolStripMenuItem
            // 
            this.deleteSelsectedItemsToolStripMenuItem.Name = "deleteSelsectedItemsToolStripMenuItem";
            this.deleteSelsectedItemsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteSelsectedItemsToolStripMenuItem.Text = "Delete selsected item(s)";
            this.deleteSelsectedItemsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelsectedItemsToolStripMenuItem_Click);
            // 
            // BtnAddProd
            // 
            this.BtnAddProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAddProd.Location = new System.Drawing.Point(778, 400);
            this.BtnAddProd.Name = "BtnAddProd";
            this.BtnAddProd.Size = new System.Drawing.Size(110, 43);
            this.BtnAddProd.TabIndex = 2;
            this.BtnAddProd.Text = "Add product";
            this.BtnAddProd.UseVisualStyleBackColor = true;
            this.BtnAddProd.Click += new System.EventHandler(this.BtnAddProd_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 449);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(882, 24);
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
            this.tBProductUrl.Size = new System.Drawing.Size(665, 20);
            this.tBProductUrl.TabIndex = 36;
            this.tBProductUrl.Text = "http://www.6pm.com/adidas-go-to-performance-tank-top-black?zlfid=192&ref=pd_sims_" +
    "p_1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(419, 400);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 480);
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
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stocker -check if you have stock";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnGetStock;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderProduct;
        private System.Windows.Forms.ColumnHeader columnHeaderStock;
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
        private System.Windows.Forms.ColumnHeader columnHeaderSizes;
        private System.Windows.Forms.ColumnHeader columnHeaderColors;
    }
}

