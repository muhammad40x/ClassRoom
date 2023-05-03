using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhotoUrl { get; set; }

        public List<UserSchool> UserSchools { get; set;}
        

    }
}
