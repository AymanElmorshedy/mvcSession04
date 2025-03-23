using Demo.DAL.Entites.Departments;
using Demo.DAL.Entites.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Presistanse.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Repositories ==> ApplicatioDbContext
        //DepartmentRepositories ==> Open Connection With Data Base
        //EmployeeRepositories ==> Open Connection With Data Base
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .; Database=MvcProject02; Trusted_Connection=true; TrustServerCertificate=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Apply all configuration classes
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
