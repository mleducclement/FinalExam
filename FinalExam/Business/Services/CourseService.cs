using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DAO;
using FinalExam.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services {
    public class CourseService {
        private readonly ProjectContext context;
        private CourseDAO courseDAO;

        public CourseService(ProjectContext context) {
            this.context = context;
            this.courseDAO = new CourseDAO(context);
        }

        internal List<CourseDTO> GetCourses() {
            return courseDAO.GetAllCourses();
        }
    }
}
