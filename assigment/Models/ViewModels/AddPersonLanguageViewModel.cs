using PeopleAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class AddPersonLanguageViewModel
    {
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
      public  List<Language> Languages { get; set; }

    }
}
