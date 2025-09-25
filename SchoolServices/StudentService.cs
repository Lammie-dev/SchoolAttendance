//using Microsoft.EntityFrameworkCore.Migrations.Operations;

using System;
using SchoolAttendance;

public class StudentService
{
    private readonly DatabaseOperation context; 
    public StudentService(DatabaseOperation context)
    {
        this.context = context;
    }

    public ActionResponse CreateStudent(Student students)
    {
        var CreatedStudent = new StudentModel
        {
            StudentId = Guid.NewGuid(),
            Firstname = students.Firstname,
            Lastname = students.Lastname,
            MatricNumber = students.MatricNumber,
            Department = students.Department,
            Role = students.Role,
            Email = students.Email,
           PasswordHash = "1234",
            DateCreated = DateTime.UtcNow,
            DateUpdated = DateTime.UtcNow
         

        };
        
       context.Students.Add(CreatedStudent);
        context.SaveChanges();

        return new ActionResponse
        {
            Result = students,
            StatusCode = StatusCodes.Status200OK,
           
        };
       
    }


    public ActionResponse GetStudentId(Guid studentId)
    {


        var studentID = context.Students.FirstOrDefault(s =>  s.StudentId == studentId);
        if (studentID == null)
        {
            return new ActionResponse
            {
                StatusCode = StatusCodes.Status404NotFound,
                ErrorMessage = "Student not found."
            };
        }

        return new ActionResponse
        {
            Result = studentID
        };
    }

    public ActionResponse GetAllStudents ()
    {
        var GetAllStudent = context.Students.ToList();
        return new ActionResponse
        {
            Result = GetAllStudent
        };
    }
}