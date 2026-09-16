using DataAccessLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Max Legnth of Name is 50 chars")]
        [MinLength(5, ErrorMessage = "Min Legnth of Name is 5 chars")]
        public string Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,10}-[a-zA-Z]{1,40}-[a-zA-Z]{1,40}-[a-zA-Z]{1,40}$",
            ErrorMessage = "Address must be like 123-street-region-city")]

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        [Range(4000, 20000, ErrorMessage = "Salary must be between 4000 and 20,000")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;


        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; } // navigational property

    }
}
