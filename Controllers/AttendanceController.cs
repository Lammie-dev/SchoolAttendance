using Microsoft.AspNetCore.Mvc;
using SchoolAttendance.LectureDetails.Attendance;
using SchoolAttendance.SchoolServices;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService attendanceService;
        public AttendanceController(AttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        [HttpPost("api/studentattendance/create")]
        public ActionResult StudentAttendance([FromBody] StudentAttendance record)
        {
            var CreateAttendance = attendanceService.Attendances(record);
            return Ok(CreateAttendance);
        }

        [HttpPost("api/lecturerattendance/create")]
        public ActionResult LecturerAttendance([FromBody] LecturerAttendance record)
        {
            var LecturerAttend = attendanceService.Attendances(record);
            return Ok(LecturerAttend);
        }
    }
}
