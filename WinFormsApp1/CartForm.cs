using System;
using System.Windows.Forms;
using Marketplace.Model;

namespace Marketplace.WinForms
{
    public partial class CartForm : Form
    {
        /// <summary>
        /// Конструктор. Создаёт элементы формы и заполняет таблицу.
        /// </summary>
        public CartForm()
        {
            InitializeComponent();
            RefreshCart();
        }

        /// <summary>
        /// Обновляет таблицу товаров и надпись с итогом.
        /// </summary>
        public void RefreshCart()
        {
            gridCart.Rows.Clear();

            var allProducts = MainForm.cart.GetAll();

            for (int i = 0; i < allProducts.Count; i++)
            {
                Product product = allProducts[i];
                gridCart.Rows.Add(product.Id, product.Name, product.Hero, product.Price, product.Count, product.GetTotalPrice());
            }

            lblTotal.Text = "Без скидки: " + MainForm.cart.GetSubtotal() + " | Скидка: " + MainForm.cart.GetDiscount() + " | Итого: " + MainForm.cart.GetTotal();
        }

        /// <summary>
        /// Обработчик кнопки "Удалить".
        /// Удаляет выбранную запись из корзины по её ID.
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события (не используются).</param>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (gridCart.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(gridCart.SelectedRows[0].Cells[0].Value);
            MainForm.cart.Remove(id);
            RefreshCart();
        }

        /// <summary>
        /// Обработчик кнопки "Изменить кол-во".
        /// Спрашивает новое количество и передаёт его в Cart.UpdateQuantity.
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события (не используются).</param>
        private void BtnUpdateQty_Click(object sender, EventArgs e)
        {
            if (gridCart.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(gridCart.SelectedRows[0].Cells[0].Value);

            string input = Microsoft.VisualBasic.Interaction.InputBox("Новое количество:", "Ввод", "1");
            int count;
            if (!int.TryParse(input, out count)) return;
            if (count <= 0) return;

            MainForm.cart.UpdateQuantity(id, count);
            RefreshCart();
        }

        /// <summary>
        /// Обработчик кнопки "Купить".
        /// Вызывает Cart.Checkout, показывает результат и обновляет таблицу.
        /// </summary>
        /// <param name="sender">Кнопка, по которой кликнули.</param>
        /// <param name="e">Данные события (не используются).</param>
        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            string result = MainForm.cart.Checkout();
            MessageBox.Show(result);
            RefreshCart();
        }
    }
}