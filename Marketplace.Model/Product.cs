namespace Marketplace.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hero { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Считает стоимость этой позиции.
        /// </summary>
        /// <returns>Цена, умноженная на количество.</returns>
        public double GetTotalPrice()
        {
            return Price * Count;
        }

        /// <summary>
        /// Конструктор. Создаёт товар с заданными характеристиками.
        /// </summary>
        /// <param name="id">Уникальный номер записи.</param>
        /// <param name="name">Название предмета.</param>
        /// <param name="hero">Герой, к которому относится предмет.</param>
        /// <param name="price">Цена за одну штуку.</param>
        /// <param name="count">Количество штук.</param>
        public Product(int id, string name, string hero, double price, int count)
        {
            Id = id;
            Name = name;
            Hero = hero;
            Price = price;
            Count = count;
        }
    }
}