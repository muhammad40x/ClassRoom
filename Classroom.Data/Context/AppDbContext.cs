using Classroom.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Data.Context;


public class AppDbContext :IdentityDbContext<User,IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<School> School { get; set; }
    public DbSet<UserSchool> UserSchool { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        base.OnModelCreating(builder);

        builder.Entity<User>()
            .ToTable("users");

        builder.Entity<User>()
            .Property(x => x.FirstName)
            .HasColumnName("firstname")
            .HasMaxLength(50)
            .IsRequired();


        builder.Entity<User>()
            .Property(x => x.LastName)
            .HasColumnName("lastname")
            .HasMaxLength(50)
            .IsRequired(false);


        builder.Entity<User>()
            .Property(x => x.PhotoUrl)
            .HasColumnName("photo_url")
            .IsRequired(false);
    }


}



