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
    }
}
