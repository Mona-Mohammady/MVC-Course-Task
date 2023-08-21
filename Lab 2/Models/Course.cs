using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2.Models
{
    public class Course
    {
        [Key]
        public int? Id { get; set; }

        [MaxLength(25)]
        [MinLength(2)]
        [UniqueName]

        public string Name { get; set; }

        [Required]
        [Range(50, 100)]
        public int Degree { get; set; }


        [Required]
        [Remote(action: "ValidateMinDegree", controller: "Course", AdditionalFields = nameof(Degree))]
        public int minDegree { get; set; }
       
        [ForeignKey("Department")]

        public int? dept_id { get; set; }
        public virtual Department? Department { get; set; }

        [ForeignKey("crsResult")]
        public int? crs_id { get; set; }
        public virtual List<crsResult>? CourseResults { get; set; }

        [ForeignKey("Instructor")]
        public int? ins_id { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }

    }
}
