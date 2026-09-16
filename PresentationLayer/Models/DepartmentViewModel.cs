using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Name max length is 50 characters")]
        public string Name { get; set; }
     

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
