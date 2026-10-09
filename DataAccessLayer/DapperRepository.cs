using System.Data;
using Dapper;
using Marketplace.Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий через Dapper.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly IDbConnection connection;

        /// <summary>
        /// Конструктор. Принимает подключение к БД.
        /// </summary>
        /// <param name="connection">Открытое подключение.</param>
        public DapperRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Добавляет новую запись.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Add(T entity)
        {
            var sql = $"INSERT INTO {typeof(T).Name}s (Name, Hero, Price, Count) VALUES (@Name, @Hero, @Price, @Count)";
            connection.Execute(sql, entity);
        }

        /// <summary>
        /// Удаляет запись по ID.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        public void Delete(int id)
        {
            var sql = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }

        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        public List<T> ReadAll()
        {
            var sql = $"SELECT * FROM {typeof(T).Name}s";
            return connection.Query<T>(sql).ToList();
        }

        /// <summary>
        /// Возвращает одну запись по ID.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        /// <returns>Найденная сущность или null.</returns>
        public T ReadById(int id)
        {
            var sql = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
            return connection.QueryFirstOrDefault<T>(sql, new { Id = id });
        }

        /// <summary>
        /// Обновляет запись.
        /// </summary>
        /// <param name="entity">Сущность с новыми данными.</param>
        public void Update(T entity)
        {
            var sql = $"UPDATE {typeof(T).Name}s SET Name = @Name, Hero = @Hero, Price = @Price, Count = @Count WHERE Id = @Id";
            connection.Execute(sql, entity);
        }
    }
}