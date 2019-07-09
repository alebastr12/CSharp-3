using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data.BaseEntityes;
using MailSenderLib.Data;
using System.Data.Entity;

namespace MailSenderLib.Services.EFServices
{
    public abstract class DataInEF<T> : IDataServices<T> where T : Entity
    {
        protected readonly Data.EF.MailSenderDB _db;
        protected readonly DbSet<T> dBSet;
        public DataInEF(Data.EF.MailSenderDB db)
        {
            _db = db;
            dBSet = _db.Set<T>();
        }

        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (item.Id != 0) return;
            dBSet.Add(item);
            _db.SaveChanges();
        }

        public async Task AddAsync(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (item.Id != 0) return;
            dBSet.Add(item);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Delete(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = GetById(item.Id);
            if (db_item is null) return;
            dBSet.Remove(db_item);
            _db.SaveChanges();
        }

        public async Task DeleteAsync(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = await GetByIdAsync(item.Id).ConfigureAwait(false);
            if (db_item is null) return;
            dBSet.Remove(db_item);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public abstract void Edit(T item);

        public abstract Task EditAsync(T item);

        public IEnumerable<T> GetAll()
        {
            return dBSet.ToArray();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dBSet.ToArrayAsync().ConfigureAwait(false);
        }
        public T GetById(int id)
        {
            return dBSet.FirstOrDefault(e => e.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dBSet.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
