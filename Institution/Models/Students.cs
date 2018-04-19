using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Institution.Models.CommonProperties;

namespace Institution.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DisplayName("Student Id")]
        public int StudentId { get; set; }
        [Required]
        [DisplayName("First Name")]
        [Column("firstName", TypeName = "ntext")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Father Name")]
        public string FatherName { get; set; }

        [Required]
        [DisplayName("Mother Name")]
        [Column("motherName")]
        public string MotherName { get; set; }

        [Required]
        [Column("dateOfBirth")]

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        public DateTime DOB { get; set; }

        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Phone]
        [Column("phone")]
        public string Phone { get; set; }

        [Column("imageUrl")]
        public string ImageUrl { get; set; }

        public string Gender { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }




    }
}