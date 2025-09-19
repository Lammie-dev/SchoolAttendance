using Microsoft.EntityFrameworkCore;
using SchoolAttendance.SchoolStructureModel;

namespace SchoolAttendance
{
    public class DatabaseOperation : DbContext
    {
public DatabaseOperation(DbContextOptions<DatabaseOperation> Options) : base(Options) { }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<StaffModel> Staff { get; set; }
        public DbSet<CourseModel> Courses { get; set; } 
        public DbSet<AttendanceModel> Attendance { get; set; }
        public DbSet<CourseRegistrationModel> CourseRegistrations { get; set; }
   



        /// <summary>
        /// Making emun role and attendance status string instead of integer
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Attendance enum stored as string
            modelBuilder.Entity<AttendanceModel>()
                .Property(a => a.Status)
                .HasConversion<string>();

            // Student Role enum stored as string
            modelBuilder.Entity<StudentModel>()
                .Property(s => s.Role)
                .HasConversion<string>();

            // Staff Role enum stored as string (if applicable)
            modelBuilder.Entity<StaffModel>()
                .Property(st => st.Role)
                .HasConversion<string>();
        }

    }
}
