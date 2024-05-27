namespace EFCoreAssignment01.WebApp.Models
{
    public class Project_Employee
    {
        public Guid EmployeeId {get; set;}
        public Guid ProjectId { get; set;}
        public Employees Employees { get; set;}
        public Projects Projects{ get; set;}
        public bool Enable { get; set; }
    }
}
