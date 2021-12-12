using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Models.Repositories;

namespace ZooStore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository )
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult WhereWeAre()
        {
            return View(_departmentRepository.Departments);
        }
    }
}
