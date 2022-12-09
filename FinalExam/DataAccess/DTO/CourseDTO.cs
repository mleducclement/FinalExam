using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.DTO {
    public class CourseDTO {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("courseCode")]
        [MaxLength(32)]
        [Required]
        public string CourseCode { get; set; }

        [Column("title")]
        [MaxLength(128)]
        [Required]
        public string Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        public CourseDTO(string courseCode, string title, string? description = null) {
            CourseCode = courseCode;
            Title = title;
            Description = description;
        }
    }
}
