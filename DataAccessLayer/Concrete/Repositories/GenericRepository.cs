using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = c.Set<T>(); //değer ataması için constracture bir metod oluşturduk 
        }    
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p); //Silme işlemi 2
            deletedEntity.State = EntityState.Deleted;
           // _object.Remove(p); //Silme İşlemi 1
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //verilen değere göre tek bir değer getirme
        }

     

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p); //Ekleme İşlemi 2
            addedEntity.State = EntityState.Added;
            //_object.Add(p); //Ekleme İşlemi 1
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p); //Update işlemi
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges(); //Sadece bunu yazıp çalıştıramayız
        }
    }
}
