using System;
using System.Windows.Forms;

namespace Marketplace.WinForms
{
    public partial class BalanceForm : Form
    {
        /// <summary>
        /// Конструктор. Создаёт элементы формы и обновляет надпись с балансом.
        /// </summary>
        public BalanceForm()
        {
            InitializeComponent();
            RefreshBalance();
        }

        /// <summary>
        /// Обновляет надпись с текущим балансом на форме.
        /// </summary>
        public void RefreshBalance()
        {
            lblCurrent.Text = "Баланс: " + MainForm.cart.GetBalance();
        }

        /// <summary>
        /// Обработчик кнопки "Пополнить".
        /// Проверяет введённую сумму и пополняет баланс через Cart.TopUpBalance.
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события (не используются).</param>
        private void BtnTopUp_Click(object sender, EventArgs e)
        {
            double amount;
            if (!double.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Введите число");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Сумма должна быть больше 0");
                return;
            }

            MainForm.cart.TopUpBalance(amount);
            RefreshBalance();
            MessageBox.Show("Баланс пополнен");
        }
    }
}