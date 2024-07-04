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
            // Validate StudentId presence
            if (studentFace.StudentId == 0)
            {
                return BadRequest("StudentId is required for the StudentFace");
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

        [HttpPut("{id}")]
        public IActionResult UpdateStudentFace(int id, StudentFace studentFace)
        {
            var existedStudentFace = _unitOfWork.StudentFaceRepository.GetByID(id);
            if (existedStudentFace != null)
            {
                existedStudentFace.FaceData = studentFace.FaceData;
                existedStudentFace.CaptureDate = studentFace.CaptureDate;
                existedStudentFace.StudentId = studentFace.StudentId;
            }
            _unitOfWork.StudentFaceRepository.Update(existedStudentFace);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudentFace(int id)
        {
            var existedStudentFaceEntity = _unitOfWork.StudentFaceRepository.GetByID(id);
            if (existedStudentFaceEntity == null)
            {
                return NotFound();
            }
            _unitOfWork.StudentFaceRepository.Delete(existedStudentFaceEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
