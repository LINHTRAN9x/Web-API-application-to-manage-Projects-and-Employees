using System.ComponentModel.DataAnnotations;

namespace Projects_Manage.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string EmployeeName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Employee), "ValidateDOB")]
        public DateTime EmployeeDOT {  get; set; }
        [Required]
        public string EmployeeDepartment { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public static ValidationResult ValidateDOB(DateTime dob, ValidationContext context)
        {
            if (dob.AddYears(16) > DateTime.Now)
            {
                return new ValidationResult("Employee must be at least 16 years old.");
            }
            return ValidationResult.Success;
        }
    }
}
