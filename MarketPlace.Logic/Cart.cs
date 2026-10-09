using System;
using System.Collections.Generic;
using Marketplace.Model;

namespace Marketplace.Logic
{
    public class Cart
    {
        private List<Product> products = new List<Product>();
        private int nextId = 1;
        private double balance = 10000;

        /// <summary>
        /// Возвращает текущий баланс пользователя.
        /// </summary>
        /// <returns>Сколько денег на балансе.</returns>
        public double GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// Добавляет новый товар в корзину.
        /// Создаёт объект Product с текущим номером и кладёт его в список.
        /// </summary>
        /// <param name="name">Название предмета (например, "Arcana").</param>
        /// <param name="hero">Герой, к которому относится предмет.</param>
        /// <param name="price">Цена за одну штуку.</param>
        /// <param name="count">Сколько штук добавить в корзину.</param>
        public void Add(string name, string hero, double price, int count)
        {
            Product product = new Product(nextId, name, hero, price, count);
            nextId = nextId + 1;
            products.Add(product);
        }

        /// <summary>
        /// Удаляет товар из корзины по его ID.
        /// </summary>
        /// <param name="id">Номер записи, которую надо удалить.</param>
        /// <returns>true, если товар найден и удалён, иначе false.</returns>
        public bool Remove(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    products.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает список всех товаров в корзине.
        /// </summary>
        /// <returns>Список объектов Product.</returns>
        public List<Product> GetAll()
        {
            return products;
        }

        /// <summary>
        /// Ищет один товар по ID.
        /// </summary>
        /// <param name="id">Номер записи.</param>
        /// <returns>Найденный Product или null, если товара нет.</returns>
        public Product Find(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                    return products[i];
            }
            return null;
        }

        /// <summary>
        /// Изменяет количество у товара с указанным ID.
        /// </summary>
        /// <param name="id">Номер записи.</param>
        /// <param name="newCount">Новое количество.</param>
        /// <returns>true при успехе, false — если товар не найден.</returns>
        public bool UpdateQuantity(int id, int newCount)
        {
            Product product = Find(id);
            if (product == null) return false;
            product.Count = newCount;
            return true;
        }

        /// <summary>
        /// Бизнес-функция 1 (часть): считает сумму всех товаров без скидки.
        /// </summary>
        /// <returns>Общая сумма всех позиций корзины.</returns>
        public double GetSubtotal()
        {
            double sum = 0;
            for (int i = 0; i < products.Count; i++)
            {
                sum = sum + products[i].GetTotalPrice();
            }
            return sum;
        }

        /// <summary>
        /// Бизнес-функция 1 (часть): считает размер скидки.
        /// </summary>
        /// <returns>10% от суммы, если она больше 5000, иначе 0.</returns>
        public double GetDiscount()
        {
            double subtotal = GetSubtotal();
            if (subtotal > 5000)
                return subtotal * 0.10;
            return 0;
        }

        /// <summary>
        /// Бизнес-функция 1 (итог): возвращает сумму к оплате.
        /// </summary>
        /// <returns>Сумма без скидки минус скидка.</returns>
        public double GetTotal()
        {
            return GetSubtotal() - GetDiscount();
        }

        /// <summary>
        /// Бизнес-функция 2: оформление покупки.
        /// Проверяет корзину и баланс, списывает деньги и очищает корзину.
        /// </summary>
        /// <returns>Текстовое сообщение о результате покупки.</returns>
        public string Checkout()
        {
            if (products.Count == 0)
                return "Корзина пуста";

            double total = GetTotal();

            if (total > balance)
                return "Не хватает денег. Нужно: " + total + ", у вас: " + balance;

            balance = balance - total;
            products.Clear();
            return "Покупка на сумму " + total;
        }

        /// <summary>
        /// Пополняет баланс пользователя на указанную сумму.
        /// </summary>
        /// <param name="amount">Сколько денег добавить к балансу.</param>
        public void TopUpBalance(double amount)
        {
            balance = balance + amount;
        }
    }
}