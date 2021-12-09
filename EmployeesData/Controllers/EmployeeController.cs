using EmployeesData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }
        public JsonResult Details(int Id)
        {
            return Json(_employeeRepository.GetEmployee(Id));

        }

        [Route("[action]/{id?}")]
        public ViewResult Display(int? Id)
        {
            Employee model = _employeeRepository.GetEmployee(Id ?? 1);
            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,

                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Display", new { newEmployee.Id });
            }
            return View();
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            Employee editEmployee = new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,

            };
            return View(editEmployee);
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
               _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            return View();

        }
        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public ViewResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            return View(employee);
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employees)
        {
            Employee employee = _employeeRepository.GetEmployee(employees.Id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee.Id);
                return RedirectToAction("Index", employee);
            }
            return View();
        }
    }
}
