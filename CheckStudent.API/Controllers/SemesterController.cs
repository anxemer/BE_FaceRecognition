﻿using CheckStudent.Repository.DTO.Semester;
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

        [HttpGet("{id}")]
        public ActionResult GetSemesterById(int id)
        {
            var responseSemester = _unitOfWork.SemesterRepository.GetByID(id);
            return Ok(responseSemester);
        }

        [HttpPost]
        public IActionResult AddSemester([FromBody] SemesterDTO semester)
        {
            if (semester == null)
            {
                return BadRequest("Semester data is null");
            }
            // Validate CourseId presence
            if (semester.CourseId == 0)
            {
                return BadRequest("CourseId is required for the Semester");
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

        [HttpPut("{id}")]
        public IActionResult UpdateSemester(int id, Semester semester)
        {
            var existedSemester = _unitOfWork.SemesterRepository.GetByID(id);
            if (existedSemester != null)
            {
                existedSemester.Name = semester.Name;
                existedSemester.Description = semester.Description;
                existedSemester.StartTime = semester.StartTime;
                existedSemester.EndTime = semester.EndTime;
                existedSemester.CourseId = semester.CourseId;
            }
            _unitOfWork.SemesterRepository.Update(existedSemester);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSemester(int id)
        {
            var existedSemesterEntity = _unitOfWork.SemesterRepository.GetByID(id);
            if (existedSemesterEntity == null)
            {
                return NotFound();
            }
            _unitOfWork.SemesterRepository.Delete(existedSemesterEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
