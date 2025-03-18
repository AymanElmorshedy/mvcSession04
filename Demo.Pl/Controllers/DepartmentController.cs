using Demo.BLA.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Pl.Controllers
{
    //DepartmentController ==> Inheritance"is a"
    //DepartmentController ==> Composition"Has a Department Service"
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        //Action ==> Master Action
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
    }
}
