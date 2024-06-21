using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckStudent.Repository.DTO.Course
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Instructor { get; set; }
        public string InstructorName { get; set; }
        public string Room { get; set; }
        public string Schedule { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SubjectId { get; set; }
    }
}
