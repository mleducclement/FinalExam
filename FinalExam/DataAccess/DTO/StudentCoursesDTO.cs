using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.DTO {
    public class StudentCoursesDTO {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("courseId")]
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public CourseDTO Course { get; set; } = null!;

        [Column("studentId")]
        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public CourseDTO Student { get; set; } = null!;

        public StudentCoursesDTO(int courseId, int studentId) {
            CourseId = courseId;
            StudentId = studentId;
        }
    }
}
