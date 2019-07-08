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

        T GetById(int id);

        /// <summary>Создать (зарегистрировать)</summary>
        void Add(T item);

        /// <summary>Обновить</summary>
        void Edit(T item);

        /// <summary>Удалить</summary>
        void Delete(T item);
    }
}
