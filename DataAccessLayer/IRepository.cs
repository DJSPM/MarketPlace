using Marketplace.Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс репозитория. Описывает основные CRUD-операции.
    /// </summary>
    /// <typeparam name="T">Тип сущности (должен реализовать IDomainObject).</typeparam>
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавляет новую запись.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        void Add(T entity);

        /// <summary>
        /// Удаляет запись по ID.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        void Delete(int id);

        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        List<T> ReadAll();

        /// <summary>
        /// Возвращает одну запись по ID.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        /// <returns>Найденная сущность или null.</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновляет запись.
        /// </summary>
        /// <param name="entity">Сущность с новыми данными.</param>
        void Update(T entity);
    }
}