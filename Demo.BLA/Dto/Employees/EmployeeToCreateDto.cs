using Demo.DAL.Entites.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLA.Dto.Employees
{
    public class EmployeeToCreateDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Max length must be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 character")]
        public string Name { get; set; } = null!;
        [Range(22, 30)]
        public int? Age { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Avtive")]
        public bool IsActive { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
