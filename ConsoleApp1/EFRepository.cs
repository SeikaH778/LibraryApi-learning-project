using LibraryDataBase;

namespace ConsoleApp1
{
    public class EFRepository<T> : IRepository<T> where T : class , IEntity
    {
        
        public void Add (T item) 
        { 
            using (var db = new DB_context() )
            {
                db.Add (item);
                db.SaveChanges();
            }
        }
        public IEnumerable<T> GetAll()
        {
            using (var db = new DB_context())
            {
                return db.Set<T>().ToList();
            }
        }
        public T FindById (int id)
        {
            using (var db = new DB_context())
            {
                return db.Set<T>().Find(id);
            }
        }
        public void Delete (int id)
        {
            using (var db = new DB_context())
            {
                var entity = db.Set<T>().FirstOrDefault(t => t.Id == id);
                if (entity != null)
                {
                    db.Set<T>().Remove(entity);
                    db.SaveChanges();
                }
            }
        }
        public void Update(T item) 
        {
            using (var db = new DB_context())
            {
                 db.Set<T>().Update(item);
                 db.SaveChanges();
            }

        }
    }
}
