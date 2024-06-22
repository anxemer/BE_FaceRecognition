using CheckStudent.Repository.DTO.Student;
using CheckStudent.Repository.Models;
using CheckStudent.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckStudent.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _unitOfWork.StudentRepository.Get();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var responseStudent = _unitOfWork.StudentRepository.GetByID(id);
            return Ok(responseStudent);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentDTO student)
        {
            if (student.Code == null)
            {
                return BadRequest("Student data is null");
            }
            var addStudent = new Student
            {
                Code = student.Code,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Status = student.Status
            };
            _unitOfWork.StudentRepository.Insert(addStudent);
            _unitOfWork.Save();
            return Ok(student);
        }
    }
}
