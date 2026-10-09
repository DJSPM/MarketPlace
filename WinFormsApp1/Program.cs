using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Marketplace.Logic;
using Marketplace.Model;

namespace Marketplace.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа WinForms-приложения. Создаёт репозиторий, корзину и запускает главную форму.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // === Сценарий 1: Entity Framework ===
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=marketplace.db")
                .Options;
            var context = new AppDbContext(options);
            IRepository<Product> repository = new EntityRepository<Product>(context);

            // === Сценарий 2: Dapper (раскомментируй, если нужно) ===
            // IDbConnection connection = new SqliteConnection("Data Source=marketplace.db");
            // IRepository<Product> repository = new DapperRepository<Product>(connection);

            MainForm.cart = new Cart(repository);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}