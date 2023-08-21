using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_2.Models
{
    public class Trainee
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }

        public string Address { get; set; }
        public string Grade { get; set; }

        [ForeignKey("Department")]
        public int? dept_id { get; set; }
        public virtual Department? Department { get; set; }

        [ForeignKey("crsResult")]
        public int? crs_id { get; set; }
        public virtual List<crsResult>? CourseResults { get; set; }


    }
}
