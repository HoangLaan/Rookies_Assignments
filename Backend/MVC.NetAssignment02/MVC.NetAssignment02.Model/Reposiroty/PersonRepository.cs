using MVC.NetAssignment02.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.NetAssignment02.Model.Reposiroty
{
    public class PersonRepository : IPersonRepository
    {
        public List<PersonModel> personsList = new List<PersonModel>()
        {
            new PersonModel()
            {
                Id = 1, FirstName = "Lan", LastName = "Hoang", Gender = GenderType.Male, DateOfBirth = new DateTime(2001, 01, 17),
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = true
            },
            new PersonModel()
            {
                Id = 2, FirstName = "Truong", LastName = "Nguyen", Gender = GenderType.Male, DateOfBirth = new DateTime(2002, 07, 31),
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = false
            },
            new PersonModel()
            {
                Id = 3, FirstName = "Hang", LastName = "Minh", Gender = GenderType.Female, DateOfBirth = new DateTime(1998, 02, 14),
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = true
            },
            new PersonModel()
            {
                Id = 4, FirstName = "Phuong", LastName = "Minh", Gender = GenderType.Female, DateOfBirth = new DateTime(2005, 09, 26),
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = false
            },
            new PersonModel()
            {
                Id = 5, FirstName = "Vu", LastName = "Le", Gender = GenderType.Male, DateOfBirth = new DateTime(2000, 04, 12),
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = true
            },
            new PersonModel()
            {
                Id = 6, FirstName = "Son", LastName = "Cao", Gender = GenderType.Male, DateOfBirth = new DateTime(2003, 07, 28), 
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = true
            },
            new PersonModel()
            {
                Id = 7, FirstName = "Hong", LastName = "Hoa", Gender = GenderType.Female, DateOfBirth = new DateTime(1994, 03, 11),
                PhoneNumber = "0398903001", BirthPlace = "Hanoi", IsGraduated = true
            }
        };

        public void CreatePerson(PersonDTO personDTO)
        {
            PersonModel p = new(personDTO.Id, personDTO.FirstName, personDTO.LastName, personDTO.Gender, personDTO.DateOfBirth,
                                            personDTO.PhoneNumber, personDTO.BirthPlace, personDTO.IsGraduated);
            personsList.Add(p);
        }

        public void DeletePerson(PersonModel person)
        {
            personsList.Remove(person);
        }

        public List<PersonModel> GetAllPersons()
        {
            return personsList;
        }

        public PersonModel GetPersonById(int id)
        {
            var person = (from p in personsList where p.Id == id select p).FirstOrDefault();
            return person;
        }

        public void UpdatePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
