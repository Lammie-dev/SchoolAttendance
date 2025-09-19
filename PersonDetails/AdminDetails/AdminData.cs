using System;
using System.ComponentModel.DataAnnotations;
using SchoolAttendance;

public class Admin
{
	
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string StaffID { get; set; }
	public string Department {  get; set; }
	public string Email { get; set; }
	public Role Role { get; set; }
	

	//public ICollection<Role> Roles { get; set; }
}
