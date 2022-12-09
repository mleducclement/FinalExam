using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.DAO {
    public class StudentDAO {
        private readonly ProjectContext context;

        public StudentDAO(ProjectContext context) {
            this.context = context;
        }

        public List<StudentDTO> GetAll() {
            return this.context.Students.ToList();
        }

        public StudentDTO GetById(int id) {
            var instance = this.context.Students.
                FirstOrDefault(x => x.Id == id);

            return instance;
        }

        public StudentDTO Insert(StudentDTO student) {
            this.context.Students.Add(student);
            this.context.SaveChanges();
            return student;
        }

        public StudentDTO Update(StudentDTO student) {
            this.context.Students.Update(student);
            this.context.SaveChanges();
            return student;
        }

        // Not required, but nice to have to declutter the combobox
        public StudentDTO Delete(StudentDTO student) {
            this.context.Students.Remove(student);
            this.context.SaveChanges();
            return student;
        }
    }
}
