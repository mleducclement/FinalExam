using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DAO;
using FinalExam.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services {
    public class StudentService {

        private readonly ProjectContext context;
        private StudentDAO studentDAO;

        public StudentService(ProjectContext context) {
            this.context = context;
            studentDAO = new StudentDAO(context);
        }

        public List<StudentDTO> GetAllStudents() {
            return studentDAO.GetAll();
        }

        public StudentDTO GetStudent(int id) {
            return studentDAO.GetById(id);
        }

        public StudentDTO Create(int studentCode, string firstName, string lastName) {
            StudentDTO newStudent = new StudentDTO(studentCode, firstName, lastName);
            return studentDAO.Insert(newStudent);
        }

        public StudentDTO Delete(StudentDTO student) {
            return studentDAO.Delete(student);
        }

        internal StudentDTO Update(int studentCode, string firstName, string lastName) {

            StudentDTO student = context.Students.FirstOrDefault(x => x.Id == MainService.GetInstance().GetSelectedStudent().Id);
            student.StudentCode = studentCode;
            student.FirstName = firstName;
            student.LastName = lastName;

            return studentDAO.Update(student);
        }
    }
}
