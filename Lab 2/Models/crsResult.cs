using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2.Models
{
    public class crsResult
    {
        [Key]
        public int? Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public virtual Course? Course { get; set;}


        [ForeignKey("Trainee")]
        public int? trainee_id { get; set; }
        public virtual Trainee? Trainee { get; set; }
    }
}
