using Demo.DAL.Entites.Departments;
using Demo.DAL.Presistanse.Data;
using Demo.DAL.Presistanse.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Departments
{
    //Database ==> Repository ==> Services ==> Controller
    public class DepartmentRepository  : GenericRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) :base(dbContext) 
        {
            
        }
    }
}
