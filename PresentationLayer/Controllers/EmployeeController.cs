using AutoMapper;
using BuisnessAccessLayer.Interfaces;
using BuisnessAccessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IMapper mapper;

        public IUnitOfWork UnitOfWork { get; }

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IActionResult Index(string SearchValue)
        {
            //Convert from Employee(from DB) to EmployeeViewModel (User View)
            if (string.IsNullOrEmpty(SearchValue))
            {
                var employees = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(UnitOfWork.EmployeeRepository.GetAll());
                return View(employees);
            }
            else
            {
                var employees = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(UnitOfWork.EmployeeRepository.SearchEmployee(SearchValue));
                return View(employees);

            }
        }

        public IActionResult Create()
        {
            ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            ///Manual mapping
            ///var mappedEmployee = new Employee
            ///{
            ///    Id = employee.Id,
            ///    Name = employee.Name,
            ///    Age = employee.Age,
            ///    Address = employee.Address,
            ///    IsActive = employee.IsActive,
            ///    Department = employee.Department,
            ///    Email = employee.Email,
            ///    DepartmentID = employee.DepartmentID,
            ///    Phone = employee.Phone,
            ///    Salary = employee.Salary,
            ///    HireDate = employee.HireDate
            ///};

            var mappedemployee = mapper.Map<EmployeeViewModel, Employee>(employee); // auto mapper


            if (ModelState.IsValid) //server side validation
            {
                UnitOfWork.EmployeeRepository.Add(mappedemployee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();

            return View(employee);
        }

        public IActionResult Details(int? id, string view = "Details")
        {
            if (id == null)
                return NotFound();
            var employee = UnitOfWork.EmployeeRepository.Get(id);
            if (employee == null)
                return NotFound();
            var mappedEmployee = mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(view, mappedEmployee);

        }
        public IActionResult Edit(int? id)
        {
            //if (id == null)
            //    return NotFound();
            //var employee = employeeRepository.Get(id);
            //if (employee == null)
            //    return NotFound();
            //return View(employee);
            ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();

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
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmployee = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    UnitOfWork.EmployeeRepository.Update(mappedEmployee);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();

                    return View(employeeVM);
                }
            }

            ViewBag.Departments = UnitOfWork.DepartmentRepository.GetAll();

            return View(employeeVM);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try
            {
                var mappedEmployee = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                UnitOfWork.EmployeeRepository.Delete(mappedEmployee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(employeeVM);
            }
        }
    }
}
