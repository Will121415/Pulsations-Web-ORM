using System.Dynamic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Person
    {
        [Key]
        public string Identification { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public decimal Pulsation {get; set; }

        public void CalculatePulsation()
        {
            Pulsation =  (Sex.Equals("F") || Sex.Equals("f")) ? (220 - (decimal)Age) / 10: (210 - (decimal)Age) / 10;
        }
    }
}
