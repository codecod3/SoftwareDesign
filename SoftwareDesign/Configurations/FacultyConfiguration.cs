using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareDesign.Configurations
{
    public class FacultyConfiguration: IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable(nameof(Faculty));
            //set the primary key
            builder.HasKey(c => c.FacultyId);
            builder.Property(c => c.FacultyName).HasColumnType("varchar(150)");
            builder.Property(c => c.Degree).HasColumnType("varchar(50)").HasDefaultValue("CpE");

           


        }
    }

    public class CertificationConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.ToTable(nameof(Certification));

            builder.HasKey(c => c.CertificationId);

            //foreign keys
            builder.HasOne<Faculty>().WithMany(c => c.CertificationList).HasForeignKey(c => c.FacultyId);
            builder.HasOne<Course>().WithMany(c => c.CertificationList).HasForeignKey(c => c.CourseId);
        }
    }

    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable(nameof(Section));

            builder.HasKey(c => c.SectionNo);
            builder.Property(c => c.Semester).HasColumnType("varchar(50)");

            //foreignKeys

            builder.HasOne<Course>().WithMany(c => c.SectionList).HasForeignKey(c => c.CourseId);

        }
    }

    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable(nameof(Registration));
            builder.HasKey(c => c.RegistrationId);

            //foreignKeys
            builder.HasOne<Section>().WithMany(c => c.RegistrationList).HasForeignKey(c => c.SectionNo);
            builder.HasOne<Student>().WithMany(c => c.RegistrationList).HasForeignKey(c=>c.StudentId);
        }
    }


    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Units).HasColumnType("smallint");
        }
    }

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(c => c.StudentId);

            

        }
    }
}
