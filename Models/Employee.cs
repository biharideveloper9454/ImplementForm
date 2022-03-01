using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationForm.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name *")]
        public string Name { get; set; }

        [DisplayName("City *")]
        public string City { get; set; }
    }
}
