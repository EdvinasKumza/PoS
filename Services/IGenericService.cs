using System.Collections.Generic;
using WebApplication1.Models;

namespace PoS.Services
{
    public interface IGenericService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Create(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}