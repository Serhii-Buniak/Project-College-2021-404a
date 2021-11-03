using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZooStore.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}