using Demo.DAL.Entites.Employees;
using Demo.DAL.Presistanse.Data;
using Demo.DAL.Presistanse.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext dbContext) :base(dbContext) 
        {
            
        }

    }
}
