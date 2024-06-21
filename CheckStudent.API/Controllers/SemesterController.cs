using CheckStudent.Repository.DTO.Semester;
using CheckStudent.Repository.DTO.Student;
using CheckStudent.Repository.Models;
using CheckStudent.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckStudent.API.Controllers
{
    [Route("api/semesters")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SemesterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetSemesters()
        {
            var semesters = _unitOfWork.SemesterRepository.Get();
            return Ok(semesters);
        }

        [HttpPost]
        public IActionResult AddSemester([FromBody] SemesterDTO semester)
        {
            if (semester == null)
            {
                return BadRequest("Semester data is null");
            }
            var addSemester = new Semester
            {
                Name = semester.Name,
                Description = semester.Description,
                StartTime = semester.StartTime,
                EndTime = semester.EndTime,
                CourseId = semester.CourseId
            };
            _unitOfWork.SemesterRepository.Insert(addSemester);
            _unitOfWork.Save();
            return Ok(semester);
        }
    }
}
