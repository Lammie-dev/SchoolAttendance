using SchoolAttendance.SchoolStructureModel;
using System;
using System.ComponentModel.DataAnnotations;

public class CourseModel
{
    [Key]
    public Guid CourseId { get; set; }
    public string CourseCode { get; set; }
    public string CourseTitle { get; set; }
    public string Department { get; set; }
    public Guid  LecturerId { get; set; }
    public StaffModel Lecturer { get; set; }
    public TimeSpan ScheduledTime { get; set; }
    public DateTime CreatedDate { get; set; }
   public DateTime UpdatedDate { get; set; }

    public ICollection<StudentModel> Students { get; set; } = new List<StudentModel>();
    public ICollection<AttendanceModel> AttendanceRecords { get; set; } = new List<AttendanceModel>();
}

