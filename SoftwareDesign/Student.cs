using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Program { get; set; }
        //Relationships
        public List<Registration> RegistrationList { get; set; }


    }

    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get;set; }
        public string Degree { get; set; }

        public List<Certification> CertificationList {get; set; }


    }

    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Units { get; set; }

        //Relationships
        public List<Certification> CertificationList {get; set; }
        public List<Section> SectionList { get; set; }

    }

    public class Registration
    {
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int SectionNo { get; set;}
        public DateTime RegistrationDate { get; set; }
        public string? EncodedBy { get; set; }
    }

    public class Section
    {
        public int SectionNo { get; set; }
        public required string Semester { get; set; }
        //Relationships
        public string CourseId {get; set; }
        public Course CourseLink {get; set; }

        public List<Registration> RegistrationList { get; set; }
        public int MaxStudents { get; set; }
    }

    public class Certification
    {
        public int CertificationId { get; set; }
        public DateTime DateQualified {get; set; }
        //Relationships
        public int  FacultyId { get; set; }
        public Faculty FacultyLink {get; set; }
        public string CourseId { get; set; }
        public Course CourseLink {get; set; }
    }
}
