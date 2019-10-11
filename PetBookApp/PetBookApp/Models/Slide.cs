using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Models
{
    public class Slide
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public string CarouselBG { get; set; }

        public Slide(string image, string description, int width, bool visible, string carouselBG)
        {
            this.Image = image;
            this.Description = description;
            this.Width = width;
            this.Visible = visible;
            this.CarouselBG = carouselBG;
        }
    }
}
