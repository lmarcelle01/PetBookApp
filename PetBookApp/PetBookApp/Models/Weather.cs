using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp
{
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class City
    {
        public List<Weather> weather { get; set; }
        public Wind wind { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
