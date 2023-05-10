using System.ComponentModel.DataAnnotations;

namespace _3lessonproject.Models;

public class UpdateSchoolDto
{
    [StringLength(50)]
    public string Name { get; set; }

    public string? Description { get; set; }
    public IFormFile? Photo { get; set; }

}
