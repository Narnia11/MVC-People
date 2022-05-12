using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAssignment.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string City { get; set; }
    }
}
