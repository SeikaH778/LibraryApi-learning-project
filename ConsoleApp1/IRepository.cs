
namespace ConsoleApp1
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Delete(int id);
        
        void Update(T item);
    }
}
