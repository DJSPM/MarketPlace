using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Model
{
    /// <summary>
    /// Интерфейс для всех сущностей предметной области.
    /// Обязывает сущность иметь свойство ID.
    /// </summary>
    public interface IDomainObject
    {
        int Id { get; set; }
    }
}
