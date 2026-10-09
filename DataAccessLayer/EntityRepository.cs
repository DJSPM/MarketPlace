using Marketplace.Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий через Entity Framework.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Конструктор. Принимает контекст БД.
        /// </summary>
        /// <param name="context">Контекст Entity Framework.</param>
        public EntityRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Добавляет новую запись.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Удаляет запись по ID.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        public void Delete(int id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        public List<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        /// <summary>
        /// Возвращает одну запись по ID.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        /// <returns>Найденная сущность или null.</returns>
        public T ReadById(int id)
        {
            return context.Set<T>().Find(id);
        }

        /// <summary>
        /// Обновляет запись.
        /// </summary>
        /// <param name="entity">Сущность с новыми данными.</param>
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}