using AutoMapper;
using BuisnessAccessLayer.Interfaces;
using BuisnessAccessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }
        public IActionResult Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var mappedDepartment = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departmentRepository.GetAll());
                //ViewData["Message"] = "Hellow from DataView";
                return View(mappedDepartment);
            }
            else
            {
                var mappedDepartment = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departmentRepository.SearchDepartment(SearchValue));
                //ViewData["Message"] = "Hellow from DataView";
                return View(mappedDepartment);
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid) //server side validation
            {
                var department = mapper.Map<DepartmentViewModel, Department>(departmentVM);
                departmentRepository.Add(department);
                TempData["Message"] = "Department Created Successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(departmentVM);
        }

        public IActionResult Details(int? id, string view = "Details")
        {
            if (id == null)
                return NotFound();
            var departmentVM = mapper.Map<Department, DepartmentViewModel>(departmentRepository.Get(id));
            if (departmentVM == null)
                return NotFound();
            return View(view, departmentVM);

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
        public IActionResult Edit([FromRoute] int? id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedDepartment = mapper.Map<DepartmentViewModel, Department>(departmentVM);

                    departmentRepository.Update(mappedDepartment);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(departmentVM);

                }
            }
            return View(departmentVM);

        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.Id)
                return BadRequest();
            try
            {
                var mappedDepartment = mapper.Map<DepartmentViewModel, Department>(departmentVM);
                departmentRepository.Delete(mappedDepartment);
                TempData["DelMessage"] = "Department Deleted Succefully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(departmentVM);
            }
        }
    }
}