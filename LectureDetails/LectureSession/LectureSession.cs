using System;
using System.ComponentModel.DataAnnotations;

public class LectureSession
{
    [Key]
    public Guid SessionID { get; set; }
public string CourseCode { get; set; }
    public Course Courses { get; set; }
public string SessionDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
