using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ImageUrl { get; set; }
        public int LikesAmount { get; set; }
        public int PetId { get; set; }
        public string UserId { get; set; }
    }
}
