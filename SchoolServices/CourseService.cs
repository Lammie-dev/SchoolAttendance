
using System;
using SchoolAttendance;

public class CourseService
{
	private readonly DatabaseOperation context;
	public CourseService (DatabaseOperation context)
	{
		this.context = context;
	}  

	public ActionResponse CreateCourse (Course course, Guid currentLecturerId)
	{
		//to find lecturer
		var lecturer = context.Staff.FirstOrDefault(l => l.Id == currentLecturerId);
		if (lecturer == null)
		{
			return new ActionResponse
			{
				StatusCode = StatusCodes.Status404NotFound,
				ErrorMessage = "Lecturer not found."
			};
		}
		//to find course
		var coursse = context.Courses.FirstOrDefault(c => c.CourseCode == course.CourseCode);
		if (coursse != null)
			return new ActionResponse
			{
				StatusCode = StatusCodes.Status409Conflict,
				ErrorMessage = "Course with same course code already exists"
			};

		var CourseCreated = new CourseModel
		{
			CourseId = Guid.NewGuid(),
			CourseCode = course.CourseCode,
			CourseTitle = course.CourseTitle,
			Department = course.Department,
			LecturerId = currentLecturerId,
			ScheduledTime = course.ScheduledTime,
CreatedDate = DateTime.UtcNow,
UpdatedDate = DateTime.UtcNow
		};

		context.Courses.Add(CourseCreated);
		context.SaveChanges();

		return new ActionResponse
		{
			Result = course
		
		};
	}
}
