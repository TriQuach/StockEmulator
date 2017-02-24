using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.ViewModels
{
    public class PersonModel
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Location { get; private set; }

        public PersonModel(string name, int age, string location)
        {
            Name = name;
            Age = age;
            Location = location;
        }   
        public override string ToString()
        {
            return Name;
        }
    }
}
    