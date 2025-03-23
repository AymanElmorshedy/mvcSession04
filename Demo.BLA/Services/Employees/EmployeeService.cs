using Demo.BLA.Dto.Employees;
using Demo.DAL.Entites.Employees;
using Demo.DAL.Presistanse.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLA.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository Employeerepository)
        {
            _employeeRepository = Employeerepository;
        }
        public void Add(EmployeeToCreateDto EmployeeDto)
        {
            Employee employee = new Employee()
            {
                Name=EmployeeDto.Name,
                Address=EmployeeDto.Address,
                Age=EmployeeDto.Age,
                IsActive=EmployeeDto.IsActive,
                Salary=EmployeeDto.Salary,
                PhoneNumber=EmployeeDto.PhoneNumber,
                HiringDate=EmployeeDto.HiringDate,
                Gender = EmployeeDto.Gender,
                EmployeeType=EmployeeDto.EmployeeType,
                CreatedBy=1,
                LastModifiedBy=1,
                LastModifiedOn=DateTime.UtcNow,
                Email=EmployeeDto.Email,
               

            
            };

            _employeeRepository.Add(employee);
   
        }

        public void Delete(int id)
        {
            var employee=_employeeRepository.GetById(id);
            if (employee is not null)
            {
                _employeeRepository.Delete(employee);
            }
        }

        public IEnumerable<EmployeeToReutrnDto> GetAll()
        {
          return _employeeRepository.GetAllQuerable().Where(e=>e.IsDeleted==false).Select(employee=> new EmployeeToReutrnDto()
           {
              Id=employee.Id,
              Name=employee.Name,
              Address=employee.Address,
              Age =employee.Age,
              IsActive=employee.IsActive,
              Salary=employee.Salary,
              Email=employee.Email,
              EmployeeType=employee.EmployeeType.ToString(),
              Gender=employee.Gender.ToString(),
              
           });

        }

        public EmployeeDetailToReturnDto GetById(int id)
        {
           var employee = _employeeRepository.GetById(id);
            if (employee is not null)
            {
                return new EmployeeDetailToReturnDto()
                {
                     Id=id,
                    Name=employee.Name,
                    Address=employee.Address,
                    Age=employee.Age,
                    IsActive=employee.IsActive, 
                    Salary=employee.Salary,
                    Email=employee.Email,
                    EmployeeType=employee.EmployeeType.ToString(),
                    Gender=employee.Gender.ToString(),
                    CreatedBy=employee.CreatedBy,
                    CreatedOn=employee.CreatedOn,
                    HiringDate=employee.HiringDate,
                    LastModifiedBy=employee.LastModifiedBy,
                    LastModifiedOn=employee.LastModifiedOn, 
                    PhoneNumber=employee.PhoneNumber,
                    IsDeleted=employee.IsDeleted
                };
              
            }
            return null;
        }

        public void Update(EmployeeToUpdateDto EmployeeDto)
        {
            var employee = new Employee()
            {
                Id=EmployeeDto.Id,
                Name = EmployeeDto.Name,
                Address = EmployeeDto.Address,
                Age = EmployeeDto.Age,
                IsActive = EmployeeDto.IsActive,
                Salary = EmployeeDto.Salary,
                PhoneNumber = EmployeeDto.PhoneNumber,
                HiringDate = EmployeeDto.HiringDate,
                Gender = EmployeeDto.Gender,
                EmployeeType = EmployeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
                Email = EmployeeDto.Email,
            };
            _employeeRepository.Update(employee);
        }
    }
}
