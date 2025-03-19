using Demo.BLA.Dto.Departments;
using Demo.BLA.Services.Departments;
using Demo.Pl.View_Model.Departments;
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
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment env)
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
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentToCreateDto);
                }
                else
                {

                    message = "Department Can't be created";
                    return View("Error", message);
                }

            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();//400
            var department = _departmentService.GetById(id.Value);
            if (department is null)
                return NotFound();//404
            return View(department);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentService.GetById(id.Value);
            if (department is null)
                return NotFound();
            return View(new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description,
            });
        }

        [HttpPost]
        public IActionResult Edit(DepartmentEditViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            var message = string.Empty;
            try
            {
                _departmentService.Update(new DepartmentToUpdateDto()
                {
                    Name = editViewModel.Name,
                    Code = editViewModel.Code,
                    CreationDate = editViewModel.CreationDate,
                    Description = editViewModel.Description,

                });
                return View(editViewModel);
            }
            catch (Exception ex)
            {
                message = _env.IsDevelopment() ? ex.Message : "Department Can't Be Updated";
            }
            return View(editViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id is null)
                return BadRequest();
            var department =_departmentService.GetById(id.Value);
            if(department is null) return NotFound();
            return View(department);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return View(nameof(Index));
        }
    }
}
