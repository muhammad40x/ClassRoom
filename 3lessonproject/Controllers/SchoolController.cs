using _3lessonproject.Helpers;
using _3lessonproject.Models;
using Classroom.Data.Context;
using Classroom.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace _3lessonproject.Controllers;

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
    public async Task<IActionResult> CreateSchool([FromForm] CreateSchoolDto createSchoolDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createSchoolDto);
        }

        var school = new School()
        {
            Name = createSchoolDto.Name,
            Description = createSchoolDto.Description
        };

        if (createSchoolDto.Photo != null)
        {
            school.PhotoUrl = await FileHelper.SaveSchoolFile(createSchoolDto.Photo);
        }

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        school.UserSchools = new List<UserSchool>()
{
   new UserSchool()
   {
       UserId = userId,
       Type = EUserSchool.Creater
   }
};

        _context.School.Add(school);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Index()
    {
        var schools = await _context.School
            .Include(school => school.UserSchools)
            .ToListAsync();

        return View(schools);
    }
}
