using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.DataAccess.DTO {
    public class StudentDTO {

        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("studentCode")]
        [Required]
        public int StudentCode { get; set; }

        [Column("firstName")]
        [Required]
        public string FirstName { get; set; }

        [Column("lastName")]
        [Required]
        public string LastName { get; set; }

        public StudentDTO(int studentCode, string firstName, string lastName) {
            StudentCode = studentCode;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
