using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.DAO {
    public class CourseDAO {
        private readonly ProjectContext context;

        public CourseDAO(ProjectContext context) {
            this.context = context;
        }

        public List<CourseDTO> GetAllCourses() {
            return context.Courses.ToList();
        }

        
    }
}
