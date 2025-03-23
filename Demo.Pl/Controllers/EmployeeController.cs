using Demo.BLA.Dto.Employees;
using Demo.BLA.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Pl.Controllers
{
    //EmployeeController ==> Inheritance"is a"
    //EmployeeController ==> Composition"Has a Employee Service"
    public class EmployeeController :Controller
    {
          
        private readonly IEmployeeService _EmployeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _env;

        //Action ==> Master Action
        public EmployeeController(IEmployeeService EmployeeService, ILogger<EmployeeController> logger, IWebHostEnvironment env)
        {
            _EmployeeService = EmployeeService;
            _logger = logger;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _EmployeeService.GetAll();
            return View(Employees);
        }
        [HttpGet]//Show the form
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeToCreateDto EmployeeToCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(EmployeeToCreateDto);
            }
            try
            {
                _EmployeeService.Add(EmployeeToCreateDto);
                return View(EmployeeToCreateDto);
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                //lOG eXCEPTION
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(EmployeeToCreateDto);
                }
                else
                {

                    message = "Employee Can't be created";
                    return View("Error", message);
                }

            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();//400
            var Employee = _EmployeeService.GetById(id.Value);
            if (Employee is null)
                return NotFound();//404
            return View(Employee);

        }

        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id is null)
        //        return BadRequest();
        //    var Employee = _EmployeeService.GetById(id.Value);
        //    if (Employee is null)
        //        return NotFound();
        //    return View(new EmployeeEditViewModel()
        //    {
        //        Name = Employee.Name,
        //        Code = Employee.Code,
        //        CreationDate = Employee.CreationDate,
        //        Description = Employee.Description,
        //    });
        //}

        //[HttpPost]
        //public IActionResult Edit(EmployeeEditViewModel editViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(editViewModel);
        //    }
        //    var message = string.Empty;
        //    try
        //    {
        //        _EmployeeService.Update(new EmployeeToUpdateDto()
        //        {
        //            Name = editViewModel.Name,
        //            Code = editViewModel.Code,
        //            CreationDate = editViewModel.CreationDate,
        //            Description = editViewModel.Description,

        //        });
        //        return View(editViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        message = _env.IsDevelopment() ? ex.Message : "Employee Can't Be Updated";
        //    }
        //    return View(editViewModel);
        //}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var Employee = _EmployeeService.GetById(id.Value);
            if (Employee is null) return NotFound();
            return View(Employee);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _EmployeeService.Delete(id);
            return View(nameof(Index));
        }
    }
}

