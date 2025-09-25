using Microsoft.AspNetCore.Authorization;
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
            if (student == null) 
                return BadRequest("Invalid student data");
            var CreatedStudentData = studentService.CreateStudent(student);
            return Ok(CreatedStudentData);
        }


        [Authorize(Roles = "admin")]
        [HttpGet("api/student/{studentId}")]
        public ActionResult GetStudentsId (Guid studentId)
        {
            var GetStudentId = studentService.GetStudentId(studentId);
            return Ok(GetStudentId);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("api/student/GetAllStudent")]
        public ActionResult GetAllStudents()
        {
            var GetAllStudent = studentService.GetAllStudents();
            return Ok(GetAllStudent);
        }
    }
}
