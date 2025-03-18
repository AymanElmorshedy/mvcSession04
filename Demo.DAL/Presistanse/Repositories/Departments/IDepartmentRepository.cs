using Demo.DAL.Entites.Departments;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        ICollection<Department> GetAll(bool AsNoTracking = true);
        IQueryable<Department> GetAllQueryable();
        Department? GetById(int id);
        void Add(Department entity);
        void Update(Department entity);
        void Delete(Department entity);

    }
}
