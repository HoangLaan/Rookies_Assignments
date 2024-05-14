using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment02.WebApp.Models
{
    public class Departments
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Employees> Employess { get; set; }
    }
}
