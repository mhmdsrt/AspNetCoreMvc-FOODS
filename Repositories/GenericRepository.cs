using AspNetCoreFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreFood.Repositories
{

    public class GenericRepository<T> where T : class, new()
    {
        Context context = new Context();

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public List<T> GetAll(string tableName)
        {
            return context.Set<T>().Include(tableName).ToList(); // Buradaki Include() metodu içine parametre olarak aldığın tablo ile ilişkili verileri yükler.
            // İlişkisi olan tüm satırların tüm sütunlarını getirir
        }
        public T GetById(int id)
        {
            var log = context.Set<T>().Find(id);
            return log;
        }
        public void Insert(T entity)  
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = context.Set<T>().Find(id);
            context.Set<T>().Remove(entityToDelete);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

    }
}
