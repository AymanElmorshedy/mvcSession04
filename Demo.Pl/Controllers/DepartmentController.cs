using Demo.BLA.Dto.Departments;
using Demo.BLA.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Pl.Controllers
{
    //DepartmentController ==> Inheritance"is a"
    //DepartmentController ==> Composition"Has a Department Service"
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _env;

        //Action ==> Master Action
        public DepartmentController(IDepartmentService departmentService ,ILogger<DepartmentController> logger , IWebHostEnvironment env)
        {
            _departmentService = departmentService;
            _logger = logger;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
        [HttpGet]//Show the form
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentToCreateDto departmentToCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentToCreateDto);
            }
            try
            {
                _departmentService.Add(departmentToCreateDto);
                return View(departmentToCreateDto);
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                //lOG eXCEPTION
                _logger.LogError(ex,ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentToCreateDto);
                }
                else 
                {

                    message = "Department Can't be created";
                    return View("Error",message);
                }

            }
        }
    }
}
