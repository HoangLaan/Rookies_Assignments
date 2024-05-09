using Asp.NetAPIAssignment02.WebApp.Helper;
using Asp.NetAPIAssignment02.WebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetAPIAssignment02.WebApp.Dto
{
    public class PersonDto
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(20,MinimumLength =3, ErrorMessage = "First Name length must be from 3 to 20 letters")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name length must be from 3 to 20 letters")]
        public string? LastName { get; set; }
        [Required]
        [ValidDate(ErrorMessage = "Date of birth cannot be after the current date.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Required")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Required")]
        public string? BirthPlace { get; set; }
    }
}
