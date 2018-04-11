using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Institution.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Column("firstName", TypeName = "ntext")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("lastName")]
        public string LastName { get; set; }

        [Required]
        [Column("fatherName")]
        public string FatherName { get; set; }

        [Required]
        [Column("motherName")]
        public string MotherName { get; set; }

        [Required]
        [Column("dateOfBirth")]
        public DateTime DOB { get; set; }

        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Phone]
        [Column("phone")]
        public string Phone { get; set; }

        [Column("imageUrl")]
        public string ImageUrl { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}