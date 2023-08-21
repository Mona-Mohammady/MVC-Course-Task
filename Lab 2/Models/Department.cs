using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2.Models
{
    public class Department
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        [ForeignKey("Instructor")]
        public int? ins_id { get; set; }
        public List<Instructor>? Instructors { get; set; }

        [ForeignKey("Trainee")]
        public int? trainee_id { get; set; }
        public List<Trainee>? Trainees { get; set; }

        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public virtual Course? Course { get; set; }
    }
}
