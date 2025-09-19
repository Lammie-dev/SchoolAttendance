using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAttendance.Registration_Login.Register;
using SchoolAttendance.SchoolServices;
using System.Security.Claims;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "student")]
    public class StudCourseRegController : ControllerBase
    {
        private readonly CourseRegistrationService courseRegistrationService;
        public StudCourseRegController(CourseRegistrationService courseRegistrationService)
        {
            this.courseRegistrationService = courseRegistrationService;
        }

        [HttpPost("api/studentcourseregistration")]
        public ActionResult RegisterCourse([FromBody] CourseRegistration registration)
        {
            var studentIdToken = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (studentIdToken == null)
            {
                return Unauthorized("Invalid ID: Student not found.");
            }

            if (!Guid.TryParse(studentIdToken, out var studentId))
                {
                return Unauthorized("Invalid student ID.");
            }

            var courseReg = courseRegistrationService.RegisterCourse(studentId, registration.CourseCode);
            if (courseReg.StatusCode != StatusCodes.Status200OK)
                return StatusCode(courseReg.StatusCode, courseReg.ErrorMessage);
            return Ok(courseReg.Result);
        }
    }
}
    
