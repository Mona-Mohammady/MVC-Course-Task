using System.ComponentModel.DataAnnotations;

namespace Lab_2.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //get value
            string name = value.ToString();

            Course crsFromRequest = validationContext.ObjectInstance as Course;

            ITIContext Context = new ITIContext();
            //name uniqe per department
            Course crsFromDb = Context.Courses
                .FirstOrDefault(e => e.Name == name && e.dept_id == crsFromRequest.dept_id && e.Id != crsFromRequest.Id);

            if (crsFromDb == null)
            { //new name ,edit insert new name 
                return ValidationResult.Success;
            }
            return new ValidationResult("Name already Found");
            //   return base.IsValid(value, validationContext);
        }
    }
}
