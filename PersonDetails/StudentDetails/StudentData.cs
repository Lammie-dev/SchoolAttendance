using SchoolAttendance;
using System;
using System.ComponentModel.DataAnnotations;

public class Student
{

	//public Guid StudentId { get; set; }
	public string Firstname { get; set; }
	public string Lastname { get; set; }
	public string MatricNumber { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

	
	
}
