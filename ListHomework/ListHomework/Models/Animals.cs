using System;
using System.Collections.Generic;
using System.Text;

namespace ListHomework.Models
{
    public class Animals
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }

        public Animals(string name, string location, string details, string imageUrl)
        {
            this.Name = name;
            this.Location = location;
            this.Details = details;
            this.ImageUrl = imageUrl;
        }

        public Animals()
        {

        }
    }
}
