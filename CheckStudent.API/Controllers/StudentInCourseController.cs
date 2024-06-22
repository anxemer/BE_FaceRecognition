using CheckStudent.Repository.DTO.StudentFace;
using CheckStudent.Repository.DTO.StudentInCourse;
using CheckStudent.Repository.Models;
using CheckStudent.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckStudent.API.Controllers
{
    [Route("api/studentInCourses")]
    [ApiController]
    public class StudentInCourseController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public StudentInCourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetStudentInCourses()
        {
            var studentInCourses = _unitOfWork.StudentInCourseRepository.Get();
            return Ok(studentInCourses);
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentInCourseById(int id)
        {
            var responseStudentInCourse = _unitOfWork.StudentInCourseRepository.GetByID(id);
            return Ok(responseStudentInCourse);
        }

        [HttpPost]
        public IActionResult AddStudentInCourse([FromBody] StudentInCourseDTO studentInCourse)
        {
            if (studentInCourse == null)
            {
                return BadRequest("Student In Course data is null");
            }
            var addStudentInCourse = new StudentInCourse
            {
                EnrollmentDate = studentInCourse.EnrollmentDate,
                Grade = studentInCourse.Grade,
                Note = studentInCourse.Note,
                StudentId = studentInCourse.StudentId,
                CourseId = studentInCourse.CourseId
            };
            _unitOfWork.StudentInCourseRepository.Insert(addStudentInCourse);
            _unitOfWork.Save();
            return Ok(studentInCourse);
        }
    }
}
