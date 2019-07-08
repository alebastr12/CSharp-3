using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data.BaseEntityes;

namespace MailSenderLib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataServices<T> where T : Entity
    {
        protected readonly List<T> _Items = new List<T>();

        public IEnumerable<T> GetAll() => _Items;
        public void Add(T item)
        {
            if (_Items.Any(i => i.Id == item.Id)) return;
            item.Id = item.Id == 0 ? 1 : _Items.Max(i => i.Id) + 1;
            _Items.Add(item);
        }

        public void Delete(T item)
        {
            _Items.Remove(item);
        }

        public abstract void Edit(T item);

        public T GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Значение id должно быть больше нуля.");
            return _Items.FirstOrDefault(i => i.Id == id);
        }
    }
}
