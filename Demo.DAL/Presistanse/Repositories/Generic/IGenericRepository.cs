using Demo.DAL.Entites;
//using Demo.DAL.Entites.Ts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        ICollection<T> GetAll(bool AsNoTracking = true);
        IQueryable<T> GetAllQuerable();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
