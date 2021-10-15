using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Animal : Product
    {
        public int Age { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
    }
}
