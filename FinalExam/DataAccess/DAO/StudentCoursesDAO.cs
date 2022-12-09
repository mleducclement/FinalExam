using FinalExam.DataAccess.Context;
using FinalExam.DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.DAO; 

public class StudentCoursesDAO {
    private readonly ProjectContext context;

    public StudentCoursesDAO(ProjectContext context) {
        this.context = context;
    }

    public StudentCoursesDTO GetByStudentAndCourse(int studentId, int courseId) {
        var instance = context.StudentCourses.
            FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);

        return instance;
    }

    public StudentCoursesDTO Create(StudentCoursesDTO studentCourse) {
        context.StudentCourses.Add(studentCourse);
        context.SaveChanges();
        return studentCourse;
    }

    public StudentCoursesDTO Delete(StudentCoursesDTO studentCourse) {
        context.StudentCourses.Remove(studentCourse);
        context.SaveChanges();
        return studentCourse;
    }
    public List<CourseDTO> GetAllCoursesByStudent(int studentId) {
        List<StudentCoursesDTO> studentCourses = context.StudentCourses
            .Where(x => x.StudentId == studentId)
            .Include(x => x.Course)
            .ToList();

        List<CourseDTO> courseList = new List<CourseDTO>();
        foreach (var studentCourse in studentCourses) {
            CourseDTO course = studentCourse.Course;
            if (!courseList.Contains(course)) {
                courseList.Add(course);
            }
        }

        return courseList;
    }
}
