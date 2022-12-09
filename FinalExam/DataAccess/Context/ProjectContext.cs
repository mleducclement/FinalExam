using FinalExam.DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.Context {
    public class ProjectContext : DbContext {
        public DbSet<StudentDTO> Students { get; set; }
        public DbSet<CourseDTO> Courses { get; set; }

        public DbSet<StudentCoursesDTO> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=(local)\SQL2019EXPRESS;Integrated Security=true;Initial Catalog=db_final_07449;");
        }
    }
}
