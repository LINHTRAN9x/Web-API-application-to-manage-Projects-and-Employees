namespace Projects_Manage.Models
{
    public class ProjectEmployee
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Tasks { get; set; }
        public virtual Project Projects { get; set; }
        public virtual Employee Employees { get; set; }
    }
}
