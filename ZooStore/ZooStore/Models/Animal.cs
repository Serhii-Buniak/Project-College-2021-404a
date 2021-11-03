using System;
using System.ComponentModel.DataAnnotations;

namespace ZooStore.Models
{
    public class Animal : Product
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDay { get; set; }
        public string Species { get; set; }
        public string Sex { get; set; }
        
    }
}
