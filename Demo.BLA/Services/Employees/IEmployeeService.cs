using Demo.BLA.Dto.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLA.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeToReutrnDto> GetAll();
        EmployeeDetailToReturnDto GetById(int id);
        void Add(EmployeeToCreateDto Employee);
        void Update(EmployeeToUpdateDto Employee);
        void Delete(int id);
    }
}
