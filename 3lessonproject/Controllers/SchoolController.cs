using _3lessonproject.Models;
using Classroom.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace _3lessonproject.Controllers
{
    public class SchoolController : Controller
    {
        private readonly AppDbContext _context;

        public SchoolController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult CreateSchool()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSchool([FromForm]CreateSchoolDto createSchoolDto)
        {

            return View();
        }
    }
}
