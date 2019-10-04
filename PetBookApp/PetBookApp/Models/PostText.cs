using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Models
{
    public class PostText
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PetID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
