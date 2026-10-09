using System;
using System.Windows.Forms;
using Marketplace.Logic;

namespace Marketplace.WinForms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Корзина. Создаётся в Program.cs и передаётся сюда.
        /// </summary>
        public static Cart cart;

        /// <summary>
        /// Конструктор. Создаёт элементы формы и обновляет надпись с балансом.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            UpdateBalance();
        }

        /// <summary>
        /// Обновляет надпись с текущим балансом на форме.
        /// </summary>
        public void UpdateBalance()
        {
            lblBalance.Text = "Баланс: " + cart.GetBalance();
        }

        /// <summary>
        /// Обработчик кнопки "Добавить в корзину".
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события.</param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите предмет из списка");
                return;
            }

            string name = "";
            string hero = "";
            double price = 0;

            if (lstProducts.SelectedIndex == 0)
            {
                name = "Planetfall";
                hero = "Earthshaker";
                price = 500;
            }
            else if (lstProducts.SelectedIndex == 1)
            {
                name = "Arcana";
                hero = "Phantom Assassin";
                price = 2500;
            }
            else if (lstProducts.SelectedIndex == 2)
            {
                name = "Courier Baby Roshan";
                hero = "-";
                price = 1200;
            }
            else if (lstProducts.SelectedIndex == 3)
            {
                name = "Immortal Treasure II";
                hero = "Invoker";
                price = 700;
            }
            else if (lstProducts.SelectedIndex == 4)
            {
                name = "Battle Pass Level 100";
                hero = "-";
                price = 30000;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Сколько штук?", "Ввод", "1");

            int count;
            if (!int.TryParse(input, out count)) return;
            if (count <= 0) return;

            cart.Add(name, hero, price, count);
            MessageBox.Show("Добавлено в корзину");
        }

        /// <summary>
        /// Обработчик кнопки "Корзина".
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события.</param>
        private void BtnCart_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.ShowDialog();
            UpdateBalance();
        }

        /// <summary>
        /// Обработчик кнопки "Пополнить".
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события.</param>
        private void BtnTopUp_Click(object sender, EventArgs e)
        {
            BalanceForm form = new BalanceForm();
            form.ShowDialog();
            UpdateBalance();
        }
    }
}