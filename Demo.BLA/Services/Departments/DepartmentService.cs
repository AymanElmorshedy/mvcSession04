using Demo.BLA.Dto.Departments;
using Demo.DAL.Entites.Departments;
using Demo.DAL.Presistanse.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLA.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentToReutrnDto> GetAll()
        {
         var departments= _departmentRepository.GetAllQuerable().Where(d=>!d.IsDeleted).Select(department=> new DepartmentToReutrnDto()
         {
             Description = department.Description,
             CreationDate = department.CreationDate,
             Code = department.Code,
             Id = department.Id,
             Name = department.Name,
         }).AsNoTracking().ToList();
            return departments;
        }

        public DepartmentDetailToReturnDto GetById(int id)
        {
           var department= _departmentRepository.GetById(id);
            if (department is not null)
            {
                return new DepartmentDetailToReturnDto()
                {
                    Id = department.Id,
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    CreationDate= department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    IsDeleted = department.IsDeleted,
                    LastModifiedOn = department.LastModifiedOn  
                };
            }
            return null!;
        }
        public void Add(DepartmentToCreateDto department)
        {
            var DepartmentCreated = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                LastModifiedBy = 1,
                CreatedBy=1,
                LastModifiedOn=DateTime.UtcNow
            };
            _departmentRepository.Add(DepartmentCreated);

        }
        public void Update(DepartmentToUpdateDto department)
        {
            var DepartmentUpdated = new Department()
            {
                Id= department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                LastModifiedBy = 1,
                CreatedBy = 1,
                LastModifiedOn = DateTime.UtcNow
            };
            _departmentRepository.Update(DepartmentUpdated);
        }

        public void Delete(int id)
        {
            var department=_departmentRepository.GetById(id);
            if (department is not null)
            {
                _departmentRepository.Delete(department);
            }
        }

    }
}
