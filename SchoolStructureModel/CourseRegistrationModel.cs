using System.ComponentModel.DataAnnotations;

namespace SchoolAttendance.SchoolStructureModel
{
    public class CourseRegistrationModel
    {
        [Key]
        public Guid RegistrationId { get; set; }
        public Guid StudentId { get; set; }
        public StudentModel Student { get; set; }
        public Guid CourseId { get; set; }
        public CourseModel Course { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
    }
}
