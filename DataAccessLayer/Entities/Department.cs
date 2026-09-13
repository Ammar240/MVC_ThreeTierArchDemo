using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Code is Required")]
        public string  Code { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50,ErrorMessage ="Name max length is 50 characters")]
        public string Name { get; set; }
        public DateTime DateOFCreation { get; set; }

    }
}
