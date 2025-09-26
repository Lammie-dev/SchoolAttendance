using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin, lecturer")]
        [HttpGet("attendance/studentRecordById")]
        public ActionResult StudentById (Guid studentId)
        {
            var studentById = attendanceService.StudentById(studentId);
            return Ok(studentById);

        }
        [Authorize(Roles = "admin, lecturer")]
        [HttpGet("attendance/GetAllRecords")]
        public ActionResult GetAllRecords()
        {
            var allRecord = attendanceService.GetStudentRecord();
            return Ok(allRecord);
        }

        [Authorize(Roles ="admin")]
        [HttpGet("staff/lecturerById")]
        public ActionResult LecturerById(Guid lecturerId)
        {
            var lecturerById = attendanceService.LecturerById(lecturerId);
            return Ok(lecturerById);
        }
        [Authorize(Roles ="admin")]
        [HttpGet("staff/GetLecturerRecords")]
        public ActionResult GetLecturerRecord()
        {
            var getAllRecord = attendanceService.LecturerRecords();
            return Ok(getAllRecord);
        }
    }
}
