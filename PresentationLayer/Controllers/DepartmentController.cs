using BuisnessAccessLayer.Interfaces;
using BuisnessAccessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            return View(departmentRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) //server side validation
            {
                departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? id, string view = "Details")
        {
            if (id == null)
                return NotFound();
            var department = departmentRepository.Get(id);
            if (department == null)
                return NotFound();
            return View(view, department);

        }
        public IActionResult Edit(int? id)
        {
            //if (id == null)
            //    return NotFound();
            //var department = departmentRepository.Get(id);
            //if (department == null)
            //    return NotFound();
            //return View(department);

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, Department department)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(department);

                }
            }
            return View(department);

        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, Department department)
        {
            if (id != department.Id)
                return BadRequest();
            try
            {
                departmentRepository.Delelte(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(department);
            }
        }
    }
}
