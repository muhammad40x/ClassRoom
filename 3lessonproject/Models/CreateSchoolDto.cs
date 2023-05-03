using System.ComponentModel.DataAnnotations;

namespace _3lessonproject.Models;

public class CreateSchoolDto
{

    [StringLength(50)]
    public string Name { get; set; }

    public string? Description { get; set; }
    public IFormFile? Photo { get; set; }
}
