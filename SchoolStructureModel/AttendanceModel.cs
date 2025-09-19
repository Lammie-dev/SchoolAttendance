using System.ComponentModel.DataAnnotations;

namespace SchoolAttendance.SchoolStructureModel
{
    public class AttendanceModel
    {
        [Key]
        public Guid AttendanceId { get; set; }
        public Guid? StudentId { get; set; }
        public StudentModel Student { get; set; }
        public Guid? LecturerId { get; set; }
        public StaffModel Lecturer { get; set; }
        public Guid CourseId { get; set; }
        public CourseModel Course { get; set; }
        public Role Role { get; set; }
        public AttendanceStatus Status { get; set; }
        public Guid SessionId { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdated { get; set; }


    }
}