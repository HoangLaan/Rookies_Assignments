namespace MVC.NetAssignment02.Model.Model
{
    public class PersonModel
    {
        public PersonModel(int _id, string? _FirstName, string? _LastName, GenderType _Gender, DateTime _DateOfBirth, string? _PhoneNumber, string? _BirthPlace, bool _IsGraduated)
        {
            this.Id = _id;
            this.LastName = _LastName;
            this.FirstName = _FirstName;
            this.Gender = _Gender;
            this.DateOfBirth = _DateOfBirth;
            this.PhoneNumber = _PhoneNumber;
            this.BirthPlace = _BirthPlace;
            this.IsGraduated = _IsGraduated;
        }
        public PersonModel() { }    
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public override string ToString()
        {
            // Customize the string representation of a PersonModel
            return $"{FirstName} {LastName} ({Gender}), Born on {DateOfBirth.ToShortDateString()}";
        }
    }
}
