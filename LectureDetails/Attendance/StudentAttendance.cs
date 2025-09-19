using SchoolAttendance;
using System;
using System.ComponentModel.DataAnnotations;

public class StudentAttendance
{

    public string MatricNumber { get; set; }
	public string CourseCode { get; set; }
    public AttendanceStatus Status { get; set; }
   

}
