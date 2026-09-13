using BuisnessAccessLayer.Interfaces;
using BuisnessAccessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var department = departmentRepository.Get(id);
            if (department == null)
                return NotFound();
            return View(department);

        }
    }
}
