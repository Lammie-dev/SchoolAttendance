using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Course
{


	
	public string CourseCode { get; set; }
	public string CourseTitle { get; set; }
	public string Department { get; set; }
	public TimeSpan ScheduledTime { get; set; }
}
