using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Accessories : Product
    {
        public double Weight { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Guarantee { get; set; }
        public string Country { get; set; }
        public string Producer { get; set; }

    }
}
