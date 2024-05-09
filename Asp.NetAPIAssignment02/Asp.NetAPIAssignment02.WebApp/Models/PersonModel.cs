namespace Asp.NetAPIAssignment02.WebApp.Models
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender {  get; set; }
        public string BirthPlace { get; set; }
    }
}
