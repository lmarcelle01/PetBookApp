using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string ContentText { get; set; }
        public int PetId { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
