using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAttendance;
using SchoolAttendance.Registration_Login.Register;
using SchoolAttendance.SchoolServices;
using System.Security.Claims;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "lecturer")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService courseService;
        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }
        [HttpPost("api/course/create")]
        public ActionResult CreateCourse([FromBody] Course course)

        {

            var lecturerToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (lecturerToken == null) { 
            return Unauthorized("Invalid ID: Lecturer can not be found");
               
            }
            //var lecturerId = Guid.Parse(lecturerToken);
            if (!Guid.TryParse(lecturerToken, out var lecturerId))
            {
                return Unauthorized("Invalid lecturer ID.");
            }
            var CourseCreated = courseService.CreateCourse(course, lecturerId);
            if (CourseCreated.StatusCode != StatusCodes.Status200OK)
                return StatusCode(CourseCreated.StatusCode, CourseCreated.ErrorMessage);

            return Ok(CourseCreated.Result);
        }
    }
}


 
    
