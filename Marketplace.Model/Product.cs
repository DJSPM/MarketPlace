namespace Marketplace.Model
{
    public class Product : IDomainObject
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
        /// Пустой конструктор — нужен для EF и Dapper.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Конструктор. Создаёт товар с заданными характеристиками.
        /// </summary>
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