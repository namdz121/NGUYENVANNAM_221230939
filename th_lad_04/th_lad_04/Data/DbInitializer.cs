using Microsoft.EntityFrameworkCore;
using th_lad_04.Models;

namespace th_lad_04.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                // Lệnh này kiểm tra: Nếu DB chưa có, tự động tạo mới toàn bộ DB và các bảng
                context.Database.EnsureCreated();

                // Nếu đã có dữ liệu chuyên ngành thì không nạp lại
                if (context.Majors.Any())
                {
                    return;
                }

                // 1. Dữ liệu ngành học (Major)
                var majors = new Major[]
                {
                    new Major { MajorName = "IT" },
                    new Major { MajorName = "Economics" },
                    new Major { MajorName = "Mathematics" }
                };
                foreach (var m in majors) context.Majors.Add(m);
                context.SaveChanges();

                // 2. Dữ liệu sinh viên (Learner)
                var learners = new Learner[]
                {
                    new Learner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                    new Learner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                };
                foreach (var l in learners) context.Learners.Add(l);
                context.SaveChanges();

                // 3. Dữ liệu môn học (Course)
                var courses = new Course[]
                {
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };
                foreach (var c in courses) context.Courses.Add(c);
                context.SaveChanges();

                // 4. Dữ liệu đăng ký học (Enrollment)
                var enrollments = new Enrollment[]
                {
                    new Enrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new Enrollment { LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                    new Enrollment { LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                    new Enrollment { LearnerID = 2, CourseID = 4041, Grade = 7.0f }
                };
                foreach (var e in enrollments) context.Enrollments.Add(e);
                context.SaveChanges();
            }
        }
    }
}
