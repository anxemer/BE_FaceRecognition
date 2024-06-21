using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckStudent.Repository.DTO.StudentInCourse
{
    public class StudentInCourseDTO
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int? Grade { get; set; }
        public string Note { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
