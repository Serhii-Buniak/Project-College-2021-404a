using System.ComponentModel.DataAnnotations;

namespace ZooStore.Models
{
    public class Accessory : Product
    {

        public double Weight { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Guarantee { get; set; }
        public string Country { get; set; }
        public string Producer { get; set; }
        
    }
}
