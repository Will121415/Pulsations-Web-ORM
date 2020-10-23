using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulsaciones.Models
{
    public class PersonInputModel
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }

    public class PersonViewModel : PersonInputModel
    {
        public PersonViewModel()
        {

        }
        public PersonViewModel(Person person)
        {
            Identification = person.Identification;
            Name = person.Name;
            Sex = person.Sex;
            Age = person.Age;
            Pulsation = person.Pulsation;
        }
        public decimal Pulsation { get; set; }
    }
}

