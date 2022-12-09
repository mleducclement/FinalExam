using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DAO;
using FinalExam.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services {
    public class StudentCoursesService {

        private readonly ProjectContext context;
        private StudentCoursesDAO studentCoursesDAO;

        public StudentCoursesService(ProjectContext context) {
            this.context = context;
            this.studentCoursesDAO = new StudentCoursesDAO(context);
        }

        public List<CourseDTO> GetAllCourseByStudent(int studentId) {
            return studentCoursesDAO.GetAllCoursesByStudent(studentId);
        }

        public StudentCoursesDTO CreateNewStudentCourse(int studentId, int courseId) {
            StudentCoursesDTO studentCourse = new StudentCoursesDTO(studentId, courseId);
            return studentCoursesDAO.Create(studentCourse);
        }

        public StudentCoursesDTO DeleteStudentCourse(int studentId, int courseId) {
            return studentCoursesDAO.Delete(studentCoursesDAO.GetByStudentAndCourse(studentId, courseId));
        }
    }
}
