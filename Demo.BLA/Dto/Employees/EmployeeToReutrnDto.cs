using Demo.DAL.Entites.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLA.Dto.Employees
{
    public class EmployeeToReutrnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }


        public string Gender { get; set; }
        public string EmployeeType { get; set; }
    }
}
