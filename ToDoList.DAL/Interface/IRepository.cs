using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        T Get(int? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, Boolean> func);

    }
}
