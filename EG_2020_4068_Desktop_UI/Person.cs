using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EG_2020_4068_Desktop_UI
{
    
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public double GpaValue { get; set; }
        public string Image { get; set; }


        public string ImageURL
        {
            get
            {
                return $"/StudentImages/{Image}.png";
            }
        }
    }
    
}
