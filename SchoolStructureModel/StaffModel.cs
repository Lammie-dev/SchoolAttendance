using SchoolAttendance;
using SchoolAttendance.SchoolStructureModel;
using System;
using System.ComponentModel.DataAnnotations;

public class StaffModel
{
    [Key]
public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StaffId { get; set; }
    public string Department {  get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
   public DateTime CreatedDate {  get; set; }
    public DateTime UpdatedDate { get; set; }


    public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();
    public ICollection<AttendanceModel> AttendanceRecords { get; set; } = new List<AttendanceModel>();
}
