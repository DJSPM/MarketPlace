using System;
using System.Collections.Generic;
using Marketplace.Model;
using DataAccessLayer;

namespace Marketplace.Logic
{
    public class Cart
    {
        private IRepository<Product> repository;
        private double balance = 10000;

        /// <summary>
        /// Конструктор. Принимает репозиторий (EF или Dapper).
        /// </summary>
        /// <param name="repository">Репозиторий для работы с данными.</param>
        public Cart(IRepository<Product> repository)
        {
            this.repository = repository;
        }

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
        /// </summary>
        /// <param name="name">Название предмета.</param>
        /// <param name="hero">Герой, к которому относится предмет.</param>
        /// <param name="price">Цена за одну штуку.</param>
        /// <param name="count">Сколько штук добавить.</param>
        public void Add(string name, string hero, double price, int count)
        {
            Product product = new Product(0, name, hero, price, count);
            repository.Add(product);
        }

        /// <summary>
        /// Удаляет товар из корзины по его ID.
        /// </summary>
        /// <param name="id">Номер записи, которую надо удалить.</param>
        /// <returns>true, если товар найден и удалён, иначе false.</returns>
        public bool Remove(int id)
        {
            var product = repository.ReadById(id);
            if (product == null) return false;
            repository.Delete(id);
            return true;
        }

        /// <summary>
        /// Возвращает список всех товаров в корзине.
        /// </summary>
        /// <returns>Список объектов Product.</returns>
        public List<Product> GetAll()
        {
            return repository.ReadAll();
        }

        /// <summary>
        /// Ищет один товар по ID.
        /// </summary>
        /// <param name="id">Номер записи.</param>
        /// <returns>Найденный Product или null.</returns>
        public Product Find(int id)
        {
            return repository.ReadById(id);
        }

        /// <summary>
        /// Изменяет количество у товара с указанным ID.
        /// </summary>
        /// <param name="id">Номер записи.</param>
        /// <param name="newCount">Новое количество.</param>
        /// <returns>true при успехе, false — если товар не найден.</returns>
        public bool UpdateQuantity(int id, int newCount)
        {
            var product = repository.ReadById(id);
            if (product == null) return false;
            product.Count = newCount;
            repository.Update(product);
            return true;
        }

        /// <summary>
        /// Бизнес-функция 1 (часть): считает сумму всех товаров без скидки.
        /// </summary>
        /// <returns>Общая сумма всех позиций корзины.</returns>
        public double GetSubtotal()
        {
            double sum = 0;
            var products = repository.ReadAll();
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
        /// </summary>
        /// <returns>Текстовое сообщение о результате покупки.</returns>
        public string Checkout()
        {
            var products = repository.ReadAll();
            if (products.Count == 0)
                return "Корзина пуста";

            double total = GetTotal();

            if (total > balance)
                return "Не хватает денег. Нужно: " + total + ", у вас: " + balance;

            balance = balance - total;

            foreach (var product in products)
            {
                repository.Delete(product.Id);
            }

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