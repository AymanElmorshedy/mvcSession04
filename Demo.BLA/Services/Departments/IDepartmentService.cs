using Demo.BLA.Dto.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLA.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReutrnDto> GetAll();
        DepartmentDetailToReturnDto GetById(int id);
        void Add(DepartmentToCreateDto department);
        void Update(DepartmentToUpdateDto department);
        void Delete(int id);

    }
}
