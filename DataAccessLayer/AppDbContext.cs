using Microsoft.EntityFrameworkCore;
using Marketplace.Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Контекст базы данных для Entity Framework.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Таблица товаров.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Конструктор. Принимает настройки подключения.
        /// </summary>
        /// <param name="options">Опции контекста (строка подключения).</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}