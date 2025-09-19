using SchoolAttendance;
using SchoolAttendance.SchoolStructureModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class StudentModel
{
    [Key]
    public Guid StudentId { get; set; } 
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string MatricNumber { get; set; }
    public string Department { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
  public string PasswordHash { get; set; }
    public DateTime DateCreated {get; set; }
    public DateTime DateUpdated {get; set; }


    public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();
    public ICollection<AttendanceModel> AttendanceRecords { get; set; } = new List<AttendanceModel>();
}
