using Microsoft.AspNetCore.Http.HttpResults;
using SchoolAttendance.LectureDetails.Attendance;
using SchoolAttendance.LectureDetails.Attendance.AttendanceResponse;
using SchoolAttendance.SchoolStructureModel;
using System.Security.Cryptography.X509Certificates;

namespace SchoolAttendance.SchoolServices
{
    public class AttendanceService
    {
        private readonly DatabaseOperation context;
        public AttendanceService(DatabaseOperation context)
        {
            this.context = context;
        }


        public ActionResponse Attendances(StudentAttendance record)
        {

            //I'm introducing a look up for both student and lecturer
            // in other for them to use the same attendance model

            //Student and lecturer will sihn in differently,
            // but all data will be connected to one table model

            //Student look-up
            var student = context.Students.FirstOrDefault(s => s.MatricNumber == record.MatricNumber);
            if (student == null)
            {
                return new ActionResponse
                {
                    ErrorMessage = "Unable to find student"
                };
            }
            //course look-up
            var course = context.Courses.FirstOrDefault(c => c.CourseCode == record.CourseCode);
            if (course == null)
            {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"Course with {course.CourseCode} could not be found."
                };
            }

            //studentmodel service injection
            var Register = new AttendanceModel
            {
                AttendanceId = Guid.NewGuid(),
                StudentId = student.StudentId,
                CourseId = course.CourseId,
                Status = record.Status,
                Created = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            context.Attendance.Add(Register);
            context.SaveChanges();

var studentResponse = new StudentAttendanceResponse
            {
                AttendanceId = Register.AttendanceId,
        MatricNumber = student.MatricNumber,
        StudentName = $"{student.Firstname} {student.Lastname}",
        CourseCode = course.CourseCode,
        CourseTitle = course.CourseTitle,
       
        Created = Register.Created
    } ;

            return new ActionResponse
            {
                Result = studentResponse 

            };



        }

        //creating a lookup for lecturer.
        public ActionResponse Attendances(LecturerAttendance record)
        {
            var lecturer = context.Staff.FirstOrDefault(l => l.StaffId == record.StaffId);
            if (lecturer == null)
            {
                return new ActionResponse
                {
                    ErrorMessage = $"Lecturer with {lecturer.StaffId} can not be found"
                };

            }

            var course = context.Courses.FirstOrDefault(c => c.CourseCode == record.CourseCode);
                        if (course == null)
            {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Course not found."
                };
            }

                        var Register = new AttendanceModel
                        {
                            AttendanceId = Guid.NewGuid(),
                            LecturerId = lecturer.Id,
                            CourseId = course.CourseId,
                            Status = record.Status,
                            Created = DateTime.UtcNow,
                            LastUpdated = DateTime.UtcNow
                        };

            context.Attendance.Add(Register);
            context.SaveChanges();



            var lecturerResponse = new LecturerAttendanceResponse
            {
                AttendanceId = Register.AttendanceId,
                StaffId = lecturer.StaffId,
                LecturerName = $"{lecturer.FirstName} {lecturer.LastName}",
                CourseCode = course.CourseCode,
                CourseTitle = course.CourseTitle,
                
                Created = Register.Created
            };


            return new ActionResponse
            {
                Result = lecturerResponse

            };
           
        }
        public ActionResponse StudentById(Guid studentId)
        {
            var studentById = context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (studentById == null)
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Student can not be found"
                };
            return new ActionResponse
            {
                Result = studentById
            };
        }

        public ActionResponse GetStudentRecord()
        {
            var getAllRecord = context.Students.ToList();
            return new ActionResponse
            {
                Result = getAllRecord
            };
        }

        public ActionResponse LecturerById (Guid lecturerId)
        {
            var lecturerById = context.Staff.FirstOrDefault(l => l.Id == lecturerId);
            if (lecturerById == null)
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Lecturer not found."
                };
            return new ActionResponse
            {
                Result = lecturerById
            };
        }

        public ActionResponse LecturerRecords()
        {
            var lecturerRecords = context.Staff.ToList();
            return new ActionResponse
            {
                Result = lecturerRecords
            };
        }
    }
    
}