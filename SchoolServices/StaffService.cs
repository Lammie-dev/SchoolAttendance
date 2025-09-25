//using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using SchoolAttendance;

public class StaffService
{
	private readonly DatabaseOperation context;
	public StaffService (DatabaseOperation context)
	{
		this.context = context;
	}

	public ActionResponse CreateStaff (Lecturer lecturer)
	{
		var CreateLecturer = new StaffModel
		{
			Id = Guid.NewGuid(),
			FirstName = lecturer.FirstName,
			LastName = lecturer.LastName,
			StaffId = lecturer.StaffId,
			Department = lecturer.Department,
			Email = lecturer.Email,
			Role = lecturer.Role,
            PasswordHash = "1234",
            CreatedDate = DateTime.UtcNow,
			UpdatedDate = DateTime.UtcNow
			
		};
		context.Staff.Add(CreateLecturer);
		context.SaveChanges();

		return new ActionResponse
		{
			Result = lecturer,
			//StatusCode = StatusCodes.Status404NotFound,
			//ErrorMessage = "Unable to save lecturer's data."
		};
	}
	public ActionResponse CreateAdmin (Admin admin)
	{
		var CreatedAdmin = new StaffModel
		{
			Id = Guid.NewGuid(),
			FirstName = admin.FirstName,
			LastName = admin.LastName,
			StaffId = admin.StaffID,
			Department = admin.Department,
			Email = admin.Email,
			Role = admin.Role,
			PasswordHash = "12345",
			CreatedDate = DateTime.UtcNow,
			UpdatedDate = DateTime.UtcNow
		};
		context.Staff.Add(CreatedAdmin);
		context.SaveChanges();

		return new ActionResponse
		{
			Result = admin,
			StatusCode = StatusCodes.Status201Created,
			ErrorMessage = "Successfully Created Admin data."

		};
	}
}
