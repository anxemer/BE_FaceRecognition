using CheckStudent.Repository.DTO.StudentInCourse;
using CheckStudent.Repository.DTO.Subject;
using CheckStudent.Repository.Models;
using CheckStudent.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckStudent.API.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _unitOfWork.SubjectRepository.Get();
            return Ok(subjects);
        }

        [HttpPost]
        public IActionResult AddSubject([FromBody] SubjectDTO subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject data is null");
            }
            var addSubject = new Subject
            {
                Code = subject.Code,
                Name = subject.Name,
                Description = subject.Description,
                Prerequisite = subject.Prerequisite
            };
            _unitOfWork.SubjectRepository.Insert(addSubject);
            _unitOfWork.Save();
            return Ok(subject);
        }
    }
}
