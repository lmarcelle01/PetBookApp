using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserId { get; set; }


    }
}
