using SchoolAttendance;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffService staffService;
        public StaffController (StaffService staffService)
        {
            this.staffService = staffService;
        }

        [HttpPost("api/lecturer/create")]
        public ActionResult CreateLecturer([FromBody] Lecturer lecturer)
        {
            var CreatedLecturer = staffService.CreateStaff(lecturer);
            return Ok(CreatedLecturer);
        }

        [HttpPost("api/admin/create")]
        public ActionResult CreateAdmin([FromBody] Admin admin)
        {
            var CreatedLecturer = staffService.CreateAdmin(admin);
            return Ok(CreatedLecturer);
        }
    }
}
