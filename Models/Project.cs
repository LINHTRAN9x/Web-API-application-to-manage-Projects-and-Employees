using System.ComponentModel.DataAnnotations;

namespace Projects_Manage.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ProjectName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProjectStartDate { get; set; }
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Project), "ValidateProjectEndDate")]
        public DateTime? ProjectEndDate { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public static ValidationResult ValidateProjectEndDate(DateTime? projectEndDate, ValidationContext context)
        {
            var project = (Project)context.ObjectInstance;
            if (projectEndDate.HasValue && projectEndDate <= project.ProjectStartDate)
            {
                return new ValidationResult("ProjectEndDate must be greater than ProjectStartDate.");
            }
            return ValidationResult.Success;
        }
    }
}
