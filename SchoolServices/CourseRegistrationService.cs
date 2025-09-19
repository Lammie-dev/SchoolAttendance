using SchoolAttendance.Registration_Login.Register;
using SchoolAttendance.SchoolStructureModel;

namespace SchoolAttendance.SchoolServices
{
    public class CourseRegistrationService
    {
        private readonly DatabaseOperation context;
        public CourseRegistrationService (DatabaseOperation context)
        {
            this.context = context;
        }

        public ActionResponse RegisterCourse(Guid studentId, string courseCode)
        {
            //find student from the db
            
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Student not found."
                };
            }
            //find course in the db
            var course = context.Courses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course == null)
            {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Course not found."
                };
            }

            //if course existed
            var existed = context.CourseRegistrations.FirstOrDefault(ex => ex.StudentId == student.StudentId && ex.CourseId == course.CourseId);
            if (existed != null) {
                return new ActionResponse
                {
                    StatusCode = StatusCodes.Status201Created,
                    ErrorMessage = "Already registered for the course."
                };
            }


            var CourseRegister = new CourseRegistrationModel
            {
                RegistrationId = Guid.NewGuid(),
                StudentId = student.StudentId,
                CourseId = course.CourseId,
                DateRegistered = DateTime.UtcNow

            };
            context.CourseRegistrations.Add(CourseRegister);
            context.SaveChanges();

            return new ActionResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Result = CourseRegister
            
            };
        }
    }
}
