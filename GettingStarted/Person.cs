using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class Person
    {
        private string _location = string.Empty;
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() => Name = "---";

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Relocate(string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                _location = location;
            }
        }
    }
}
