namespace EFCoreAssignment01.WebApp.Models
{
    public class Salaries
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid Salary {  get; set; }
        public Employees? Employees { get; set; }
    }
}
