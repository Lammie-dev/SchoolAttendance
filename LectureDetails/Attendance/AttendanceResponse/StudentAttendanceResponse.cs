namespace SchoolAttendance.LectureDetails.Attendance.AttendanceResponse
{
    public class StudentAttendanceResponse
    {
        public Guid AttendanceId { get; set; }
        public string MatricNumber { get; set; }
        public string StudentName { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}
