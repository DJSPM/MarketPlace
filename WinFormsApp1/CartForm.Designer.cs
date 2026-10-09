namespace Marketplace.WinForms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gridCart = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).BeginInit();
            this.SuspendLayout();

            this.gridCart.Location = new System.Drawing.Point(10, 10);
            this.gridCart.Name = "gridCart";
            this.gridCart.Size = new System.Drawing.Size(660, 250);
            this.gridCart.TabIndex = 0;
            this.gridCart.AllowUserToAddRows = false;
            this.gridCart.ReadOnly = true;
            this.gridCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCart.AutoGenerateColumns = false;
            this.gridCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId,
                this.colName,
                this.colHero,
                this.colPrice,
                this.colCount,
                this.colTotal
            });

            this.colId.HeaderText = "Номер";
            this.colName.HeaderText = "Название";
            this.colHero.HeaderText = "Герой";
            this.colPrice.HeaderText = "Цена";
            this.colCount.HeaderText = "Кол-во";
            this.colTotal.HeaderText = "Сумма";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(10, 270);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 15);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Итого: 0";

            this.btnRemove.Location = new System.Drawing.Point(10, 300);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);

            this.btnUpdateQty.Location = new System.Drawing.Point(170, 300);
            this.btnUpdateQty.Name = "btnUpdateQty";
            this.btnUpdateQty.Size = new System.Drawing.Size(150, 30);
            this.btnUpdateQty.TabIndex = 3;
            this.btnUpdateQty.Text = "Изменить кол-во";
            this.btnUpdateQty.UseVisualStyleBackColor = true;
            this.btnUpdateQty.Click += new System.EventHandler(this.BtnUpdateQty_Click);

            this.btnCheckout.Location = new System.Drawing.Point(330, 300);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(150, 30);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Купить";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 350);
            this.Controls.Add(this.gridCart);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdateQty);
            this.Controls.Add(this.btnCheckout);
            this.Name = "CartForm";
            this.Text = "Корзина";

            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.DataGridView gridCart;
        public System.Windows.Forms.DataGridViewTextBoxColumn colId;
        public System.Windows.Forms.DataGridViewTextBoxColumn colName;
        public System.Windows.Forms.DataGridViewTextBoxColumn colHero;
        public System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        public System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnUpdateQty;
        public System.Windows.Forms.Button btnCheckout;
    }
}