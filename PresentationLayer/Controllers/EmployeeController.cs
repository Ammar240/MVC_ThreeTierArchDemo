using BuisnessAccessLayer.Interfaces;
using BuisnessAccessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            return View(employeeRepository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Departments = departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) //server side validation
            {
                employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = departmentRepository.GetAll();

            return View(employee);
        }

        public IActionResult Details(int? id, string view = "Details")
        {
            if (id == null)
                return NotFound();
            var employee = employeeRepository.Get(id);
            if (employee == null)
                return NotFound();
            return View(view, employee);

        }
        public IActionResult Edit(int? id)
        {
            //if (id == null)
            //    return NotFound();
            //var employee = employeeRepository.Get(id);
            //if (employee == null)
            //    return NotFound();
            //return View(employee);
            ViewBag.Departments = departmentRepository.GetAll();

            return Details(id, "Edit");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit([FromRoute] int? id, Employee employee)
        //{
        //    if (id != employee.Id)
        //        return BadRequest();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            employeeRepository.Update(employee);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (Exception ex)
        //        {
        //            return View(employee);

        //        }
        //    }
        //    return View(employee);

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    employeeRepository.Update(employee);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Departments = departmentRepository.GetAll();

                    return View(employee);
                }
            }

            ViewBag.Departments = departmentRepository.GetAll();

            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();
            try
            {
                employeeRepository.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(employee);
            }
        }
    }
}
