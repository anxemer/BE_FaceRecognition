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
    }
}
