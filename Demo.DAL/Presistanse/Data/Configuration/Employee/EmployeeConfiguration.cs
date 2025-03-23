using Demo.DAL.Entites.Common.Enums;
using Demo.DAL.Entites.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.DAL.Presistanse.Data.Configuration.Employees
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(e => e.Address).HasColumnType("varchar(50)");
            builder.Property(e => e.Salary).HasColumnType("decimal(8,2)");
            builder.Property(e => e.Gender).HasConversion(
                (gender)=>gender.ToString(),
                (gender)=>(Gender)Enum.Parse(typeof(Gender),gender)
                );
            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GETDATE()");
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
