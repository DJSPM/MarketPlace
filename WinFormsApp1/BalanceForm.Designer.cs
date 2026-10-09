namespace Marketplace.WinForms
{
    partial class BalanceForm
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
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(10, 10);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(100, 15);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "Баланс: 0";

            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(10, 50);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 15);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Сумма:";

            this.txtAmount.Location = new System.Drawing.Point(120, 47);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 23);
            this.txtAmount.TabIndex = 2;

            this.btnTopUp.Location = new System.Drawing.Point(120, 90);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(150, 30);
            this.btnTopUp.TabIndex = 3;
            this.btnTopUp.Text = "Пополнить";
            this.btnTopUp.UseVisualStyleBackColor = true;
            this.btnTopUp.Click += new System.EventHandler(this.BtnTopUp_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnTopUp);
            this.Name = "BalanceForm";
            this.Text = "Пополнение баланса";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.Label lblCurrent;
        public System.Windows.Forms.Label lblAmount;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Button btnTopUp;
    }
}