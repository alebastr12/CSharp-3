using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services
{
    public interface IDataServices<T>
    {
        /// <summary>Извлечь</summary>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Извлечь асинхронно
        /// </summary>
        /// <returns>Коллекция сущностей</returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Получить элемент по его Id
        /// </summary>
        /// <param name="id">Значение Id</param>
        /// <returns>Элемент</returns>
        T GetById(int id);

        Task<T> GetByIdAsync(int id);
        /// <summary>Создать (зарегистрировать)</summary>
        void Add(T item);
        Task AddAsync(T item);
        /// <summary>Обновить</summary>
        void Edit(T item);
        Task EditAsync(T item);
        /// <summary>Удалить</summary>
        void Delete(T item);
        Task DeleteAsync(T item);
    }
}
