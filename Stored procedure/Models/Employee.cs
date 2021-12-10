using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stored_procedure.Models
{
    public class Employee
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public string Criminal_Record { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public string Opinion_On_Personality { get; set; }
    }
}
