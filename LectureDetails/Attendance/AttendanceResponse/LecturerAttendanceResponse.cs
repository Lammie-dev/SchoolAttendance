namespace SchoolAttendance.LectureDetails.Attendance.AttendanceResponse
{
    public class LecturerAttendanceResponse
    {
        public Guid AttendanceId { get; set; }
        public string StaffId { get; set; }
        public string LecturerName { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        
          
        }
}
