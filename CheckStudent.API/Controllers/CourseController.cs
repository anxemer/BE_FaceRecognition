using CheckStudent.Repository.DTO.Course;
using CheckStudent.Repository.DTO.Student;
using CheckStudent.Repository.Models;
using CheckStudent.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckStudent.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _unitOfWork.CourseRepository.Get();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult GetCourseById(int id)
        {
            var responseCourse = _unitOfWork.CourseRepository.GetByID(id);
            return Ok(responseCourse);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] CourseDTO course)
        {
            if (course == null)
            {
                return BadRequest("Course data is null");
            }

            // Validate SubjectId presence
            if (course.SubjectId == 0)
            {
                return BadRequest("SubjectId is required for the Course");
            }

            var addCourse = new Course
            {
                Instructor = course.Instructor,
                InstructorName = course.InstructorName,
                Room = course.Room,
                Schedule = course.Schedule,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
                SubjectId = course.SubjectId // Assign SubjectId from CourseDTO
            };

            _unitOfWork.CourseRepository.Insert(addCourse);
            _unitOfWork.Save();
            // Return the added Course (you might want to return the newly created Course object instead of the DTO)
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var existedCourseEntity = _unitOfWork.CourseRepository.GetByID(id);
            _unitOfWork.CourseRepository.Delete(existedCourseEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
