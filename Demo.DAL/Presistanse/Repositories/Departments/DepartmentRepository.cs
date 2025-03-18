using Demo.DAL.Entites.Departments;
using Demo.DAL.Presistanse.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Repositories.Departments
{
    //Database ==> Repository ==> Services ==> Controller
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)//Ask clr to create opject from application dbcontext
        {
            _dbContext = dbContext;
        }
        public void Add(Department entity)
        {
         _dbContext.Departments.Add(entity);//Saved Locally
            _dbContext.SaveChanges();
        }

        public void Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ICollection<Department> GetAll(bool AsNoTracking = true)
        {
            if (AsNoTracking)
            {
                return _dbContext.Departments.AsNoTracking().ToList();//Diatached
            }
            return _dbContext.Departments.ToList();//Unchanged
        }

        public IQueryable<Department> GetAllQueryable()
        {
           return _dbContext.Departments;
        }

        public Department? GetById(int id)
        {
            //return _dbContext.Departments.Local.FirstOrDefault(d=>d.Id == id);//lOCAL ==> tO CHECK if it's Already exsist
            return _dbContext.Departments.Find( id);//TAke Id Direct And Check In Local Before Sent Rrequeist to Database

        }

        public void Update(Department entity)
        {
           _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
