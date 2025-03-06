using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareDesign.Configurations;

namespace SoftwareDesign
{
    public class SchoolContext: DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\JAMSERVER;Database=SoftwareDesign;User Id=sa;Password=@dDU2202301488077;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new CertificationConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}
