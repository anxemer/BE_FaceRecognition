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

        [HttpGet("{id}")]
        public ActionResult GetSubjectById(int id)
        {
            var responseSubject = _unitOfWork.SubjectRepository.GetByID(id);
            return Ok(responseSubject);
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

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, Subject subject)
        {
            var existedSubject = _unitOfWork.SubjectRepository.GetByID(id);
            if (existedSubject != null)
            {
                existedSubject.Code = subject.Code;
                existedSubject.Name = subject.Name;
                existedSubject.Description = subject.Description;
                existedSubject.Prerequisite = subject.Prerequisite;
            }
            _unitOfWork.SubjectRepository.Update(existedSubject);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            var existedSubjectEntity = _unitOfWork.SubjectRepository.GetByID(id);
            _unitOfWork.SubjectRepository.Delete(existedSubjectEntity);
            if (existedSubjectEntity == null)
            {
                return NotFound();
            }
            _unitOfWork.Save();
            return Ok();
        }
    }
}
