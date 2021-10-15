using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Food : Product
    {
        public double Weight { get; set; }
        public string Producer { get; set; }
        public string Country { get; set; }
        public int Category { get; set; }
    }
}
