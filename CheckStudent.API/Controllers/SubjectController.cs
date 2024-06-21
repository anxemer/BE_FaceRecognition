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
    }
}
