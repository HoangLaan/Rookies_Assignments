using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreAssignment02.WebApp.Models
{
    public class Salaries
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public double Salary { get; set; }
        [JsonIgnore]
        public Employees Employee { get; set; }
    }
}
