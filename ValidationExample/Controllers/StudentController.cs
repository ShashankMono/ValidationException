using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationExample.Models;
using ValidationExample.Services;

namespace ValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService service)
        {
            _studentService = service;   
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAllStudents());
        }
        [HttpPost]
        public IActionResult Post(Student student) {
            if (!ModelState.IsValid) {
                var errors = string.Join(";", ModelState
                    .Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                throw new ValidationException($"{errors}");
            }
            return Ok(_studentService.AddStudent(student));
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) {
            return Ok(_studentService.GetStudent(id));
        }
    }
}
