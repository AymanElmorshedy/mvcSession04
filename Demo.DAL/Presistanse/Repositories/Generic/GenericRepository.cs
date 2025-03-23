using Demo.DAL.Entites;
//using Demo.DAL.Entites.Ts;
using Demo.DAL.Presistanse.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Generic
{
    public class GenericRepository <T> :IGenericRepository<T> where T : ModelBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)//Ask Clr TO Create Object From DbContext
        {
            _dbContext = dbContext;
        }
        public ICollection<T> GetAll(bool AsNoTracking = true)
        {
            //IsDeleted ==> false
            if (AsNoTracking)
            {
                return _dbContext.Set<T>().Where(x=>!x.IsDeleted).AsNoTracking().ToList();
            }
            return _dbContext.Set<T>().Where(x=>!x.IsDeleted).ToList();
        }
        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>() .Add(entity);

        }
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            //_dbContext.Set<T>().Remove(entity);
            //_dbContext.SaveChanges();
            //IsDeleted ==> True ==>Deleted[DisApear From Users]
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges() ;
        }


        public IQueryable<T> GetAllQuerable()
        {
            return _dbContext.Set<T>();
        }
    }
}
