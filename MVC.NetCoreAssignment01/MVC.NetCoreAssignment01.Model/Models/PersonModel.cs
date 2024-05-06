namespace MVC.NetCoreAssignment01.Model.Models
{
    
    public class PersonModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduate { get; set; }
    }
}
