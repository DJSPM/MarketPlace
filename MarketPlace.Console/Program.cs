using System;
using Marketplace.Logic;
using Marketplace.Model;

namespace Marketplace.ConsoleApp
{
    class Program
    {
        static Cart cart = new Cart();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МАГАЗИН DOTA 2 ===");
                Console.WriteLine("Баланс: " + cart.GetBalance());
                Console.WriteLine();
                Console.WriteLine("1. Посмотреть витрину");
                Console.WriteLine("2. Показать корзину");
                Console.WriteLine("3. Изменить количество");
                Console.WriteLine("4. Удалить из корзины");
                Console.WriteLine("5. Итог корзины");
                Console.WriteLine("6. Купить");
                Console.WriteLine("7. Пополнить баланс");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                if (choice == "1") Showcase();
                else if (choice == "2") ShowCart();
                else if (choice == "3") ChangeQuantity();
                else if (choice == "4") RemoveItem();
                else if (choice == "5") ShowTotal();
                else if (choice == "6") Buy();
                else if (choice == "7") TopUp();
                else if (choice == "0") break;
                else Console.WriteLine("Нет такого пункта");

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Показывает витрину и добавляет выбранный товар в корзину.
        /// </summary>
        static void Showcase()
        {
            Console.WriteLine("Что продаётся:");
            Console.WriteLine("1. PlanetFall (EarthShaker) — 500");
            Console.WriteLine("2. Arcana (Phantom Assassin) — 2500");
            Console.WriteLine("3. Courier Baby Roshan — 1200");
            Console.WriteLine("4. Immortal Treasure II (Invoker) — 700");
            Console.WriteLine("5. Battle Pass Level 100 — 30000");

            Console.Write("Номер предмета: ");
            string itemNumber = Console.ReadLine();

            string name = "";
            string hero = "";
            double price = 0;

            if (itemNumber == "1")
            {
                name = "PlanetFall";
                hero = "Earthshaker";
                price = 500;
            }
            else if (itemNumber == "2")
            {
                name = "Arcana";
                hero = "Phantom Assassin";
                price = 2500;
            }
            else if (itemNumber == "3")
            {
                name = "Courier Baby Roshan";
                hero = "-";
                price = 1200;
            }
            else if (itemNumber == "4")
            {
                name = "Immortal Treasure II";
                hero = "Invoker";
                price = 700;
            }
            else if (itemNumber == "5")
            {
                name = "Ганджубасик";
                hero = "-";
                price = 30000;
            }
            else
            {
                Console.WriteLine("Нет такого номера");
                return;
            }

            Console.Write("Сколько штук: ");
            int count;

            if (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Это не число");
                return;
            }

            if (count <= 0)
            {
                Console.WriteLine("Количество должно быть больше 0");
                return;
            }

            cart.Add(name, hero, price, count);
            Console.WriteLine("Добавлено в корзину");
        }

        /// <summary>
        /// Выводит содержимое корзины в консоль.
        /// </summary>
        static void ShowCart()
        {
            var allProducts = cart.GetAll();
            if (allProducts.Count == 0)
            {
                Console.WriteLine("Корзина пуста");
                return;
            }

            for (int i = 0; i < allProducts.Count; i++)
            {
                Product product = allProducts[i];
                Console.WriteLine(product.Id + ". " + product.Name + " (" + product.Hero + ") - " + product.Price + " x " + product.Count + " = " + product.GetTotalPrice());
            }
        }

        /// <summary>
        /// Запрашивает ID и новое количество, передаёт в Cart.UpdateQuantity.
        /// </summary>
        static void ChangeQuantity()
        {
            ShowCart();

            Console.Write("Номер записи: ");
            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Это не число");
                return;
            }

            Console.Write("Новое количество: ");
            int count;

            if (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Это не число");
                return;
            }

            if (count <= 0)
            {
                Console.WriteLine("Количество должно быть больше 0");
                return;
            }

            bool success = cart.UpdateQuantity(id, count);

            if (success) Console.WriteLine("Изменено");
            else Console.WriteLine("Не найдено");
        }

        /// <summary>
        /// Запрашивает ID и удаляет запись через Cart.Remove.
        /// </summary>
        static void RemoveItem()
        {
            ShowCart();

            Console.Write("Номер записи для удаления: ");
            int id;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Это не число");
                return;
            }

            bool success = cart.Remove(id);

            if (success) Console.WriteLine("Удалено");
            else Console.WriteLine("Не найдено");
        }

        /// <summary>
        /// Показывает итог корзины: сумму без скидки, скидку и итог.
        /// </summary>
        static void ShowTotal()
        {
            Console.WriteLine("Без скидки: " + cart.GetSubtotal());
            Console.WriteLine("Скидка: " + cart.GetDiscount());
            Console.WriteLine("Итого: " + cart.GetTotal());
        }

        /// <summary>
        /// Оформляет покупку через Cart.Checkout и выводит результат.
        /// </summary>
        static void Buy()
        {
            string result = cart.Checkout();
            Console.WriteLine(result);
            Console.WriteLine("Баланс: " + cart.GetBalance());
        }

        /// <summary>
        /// Запрашивает сумму и пополняет баланс через Cart.TopUpBalance.
        /// </summary>
        static void TopUp()
        {
            Console.Write("Сумма пополнения: ");
            double amount;

            if (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Это не число");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше 0");
                return;
            }

            cart.TopUpBalance(amount);
            Console.WriteLine("Баланс: " + cart.GetBalance());
        }
    }
}