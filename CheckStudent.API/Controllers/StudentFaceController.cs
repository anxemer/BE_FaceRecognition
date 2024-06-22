using CheckStudent.Repository.DTO.Student;
using CheckStudent.Repository.DTO.StudentFace;
using CheckStudent.Repository.Models;
using CheckStudent.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckStudent.API.Controllers
{
    [Route("api/studentFaces")]
    [ApiController]
    public class StudentFaceController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public StudentFaceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetStudentFaces()
        {
            var studentFaces = _unitOfWork.StudentFaceRepository.Get();
            return Ok(studentFaces);
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentFaceById(int id)
        {
            var responseStudentFace = _unitOfWork.StudentFaceRepository.GetByID(id);
            return Ok(responseStudentFace);
        }

        [HttpPost]
        public IActionResult AddStudentFace([FromBody] StudentFaceDTO studentFace)
        {
            if (studentFace == null)
            {
                return BadRequest("StudentFace data is null");
            }
            var addStudentFace = new StudentFace
            {
                FaceData = studentFace.FaceData,
                CaptureDate = studentFace.CaptureDate,
                StudentId = studentFace.StudentId
            };
            _unitOfWork.StudentFaceRepository.Insert(addStudentFace);
            _unitOfWork.Save();
            return Ok(studentFace);
        }
    }
}
