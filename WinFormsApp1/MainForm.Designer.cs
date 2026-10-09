using System.Drawing;
using System.Windows.Forms;

namespace Marketplace.WinForms
{
    partial class MainForm
    {
        private Label lblBalance;
        private ListBox lstProducts;
        private Button btnAdd;
        private Button btnCart;
        private Button btnTopUp;

        private void InitializeComponent()
        {
            this.lblBalance = new Label();
            this.lstProducts = new ListBox();
            this.btnAdd = new Button();
            this.btnCart = new Button();
            this.btnTopUp = new Button();

            this.lblBalance.Text = "Баланс: 0";
            this.lblBalance.Location = new Point(10, 10);
            this.lblBalance.AutoSize = true;

            this.lstProducts.Location = new Point(10, 40);
            this.lstProducts.Size = new Size(460, 250);
            this.lstProducts.Items.Add("Arcana (Earthshaker) — 500");
            this.lstProducts.Items.Add("Arcana (Phantom Assassin) — 2500");
            this.lstProducts.Items.Add("Courier Baby Roshan — 1200");
            this.lstProducts.Items.Add("Immortal Treasure II (Invoker) — 700");
            this.lstProducts.Items.Add("Ганджубасик — 30000");

            this.btnAdd.Text = "Добавить в корзину";
            this.btnAdd.Location = new Point(10, 300);
            this.btnAdd.Size = new Size(200, 30);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            this.btnCart.Text = "Корзина";
            this.btnCart.Location = new Point(220, 300);
            this.btnCart.Size = new Size(120, 30);
            this.btnCart.Click += new System.EventHandler(this.BtnCart_Click);

            this.btnTopUp.Text = "Пополнить";
            this.btnTopUp.Location = new Point(350, 300);
            this.btnTopUp.Size = new Size(120, 30);
            this.btnTopUp.Click += new System.EventHandler(this.BtnTopUp_Click);

            this.ClientSize = new Size(490, 350);
            this.Text = "Магазин Dota 2";

            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnTopUp);
        }
    }
}