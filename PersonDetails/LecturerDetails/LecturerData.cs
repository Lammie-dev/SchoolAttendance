using System;
using System.ComponentModel.DataAnnotations;
using SchoolAttendance;

public class Lecturer
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string StaffId { get; set; }
	public string Department {  get; set; }
	public string Email { get; set; }
	
	public Role Role { get; set; }
	
	//public ICollection<Course> Courses { get; set; }

}
