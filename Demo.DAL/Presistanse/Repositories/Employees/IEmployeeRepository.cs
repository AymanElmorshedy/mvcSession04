using Demo.DAL.Entites.Employees;
using Demo.DAL.Presistanse.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //ICollection<Employee> GetAll(bool AsNoTracking=true);
        //IQueryable<Employee> GetAllQuerable();
        //Employee? GetById(int id);
        //void Add(Employee entity);
        //void Update(Employee entity);
        //void Delete(Employee entity);

    }
}
