using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DTO;
using FinalExam.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services {
    public class MainService {
        private static MainService? INSTANCE;
        private ProjectContext appContext;
        private MainWindow mainWindow;

        private CourseService courseService;
        private StudentService studentService;
        private StudentCoursesService studentCoursesService;

        private StudentDTO selectedStudent;

        private MainService() {
            this.appContext = new ProjectContext();
            this.courseService = new CourseService(appContext);
            this.studentService = new StudentService(appContext);
            this.studentCoursesService = new StudentCoursesService(appContext);
        }

        public static MainService GetInstance() {
            INSTANCE = INSTANCE ?? new MainService();
            return INSTANCE;
        }

        public CourseService GetCourseService() {
            return this.courseService;
        }

        public StudentService GetStudentService() {
            return this.studentService;
        }

        public StudentCoursesService GetStudentCoursesService() {
            return this.studentCoursesService;
        }

        public StudentDTO GetSelectedStudent() {
            return selectedStudent;
        }

        public void SetSelectedStudent(StudentDTO student) {
            selectedStudent = student;
        }

        public void LaunchApp() {
            Application.Run(new MainWindow());
        }

        public void ExitApp() {
            Application.Exit();
        }
    }
}
