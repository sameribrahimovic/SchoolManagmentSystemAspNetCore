﻿using Microsoft.EntityFrameworkCore;
using SchoolMS.Models;

namespace SchoolMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
    }
}
