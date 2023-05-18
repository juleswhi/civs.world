using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClassLibrary
{
    public struct Name
    {
        public Name(string FirstName, string Surname, params string[]? Middlenames)
        {
            this.FirstName = FirstName;
            this.Surname = Surname;
        }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public List<string>? MiddleNames { get; set; }

    }
}
