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
            // Validate StudentId presence
            if (studentInCourse.StudentId == 0)
            {
                return BadRequest("StudentId is required for the Course");
            }
            // Validate CourseId presence
            if (studentInCourse.CourseId == 0)
            {
                return BadRequest("CourseId is required for the Course");
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

        [HttpPut("{id}")]
        public IActionResult UpdateStudentInCourse(int id, StudentInCourse studentInCourse)
        {
            var existedStudentInCourse = _unitOfWork.StudentInCourseRepository.GetByID(id);
            if (existedStudentInCourse != null)
            {
                existedStudentInCourse.EnrollmentDate = studentInCourse.EnrollmentDate;
                existedStudentInCourse.Grade = studentInCourse.Grade;
                existedStudentInCourse.Note = studentInCourse.Note;
                existedStudentInCourse.StudentId = studentInCourse.StudentId;
                existedStudentInCourse.CourseId = studentInCourse.CourseId;
            }
            _unitOfWork.StudentInCourseRepository.Update(existedStudentInCourse);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudentInCourse(int id)
        {
            var existedStudentInCourseEntity = _unitOfWork.StudentInCourseRepository.GetByID(id);
            if (existedStudentInCourseEntity == null)
            {
                return NotFound();
            }
            _unitOfWork.StudentInCourseRepository.Delete(existedStudentInCourseEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
