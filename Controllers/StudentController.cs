using Microsoft.AspNetCore.Mvc;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
private readonly StudentService studentService;
        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("api/student/create")]
        public ActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest("Invalid student data");
            var CreatedStudentData = studentService.CreateStudent(student);
            return Ok(CreatedStudentData);
        }
    }
}
