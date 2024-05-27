using Asp.NetAPIAssignment02.WebApp.Dto;
using Asp.NetAPIAssignment02.WebApp.Models;
using AutoMapper;

namespace Asp.NetAPIAssignment02.WebApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public readonly IMapper _mapper;
        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        List<PersonModel> people = new List<PersonModel>()
        {
            new PersonModel()
            {
               Id=Guid.NewGuid() , FirstName = "Lan", LastName = "Hoang", Gender = GenderType.Male, DateOfBirth = new DateTime(2001, 01, 17), BirthPlace = "Hanoi"
            },
            new PersonModel()
            {
               Id=Guid.NewGuid() , FirstName = "Lan", LastName = "Hoang", Gender = GenderType.Female, DateOfBirth = new DateTime(2001, 01, 17), BirthPlace = "HCM"
            },
            new PersonModel()
            {
               Id=Guid.NewGuid() , FirstName = "Lan", LastName = "Nguyen", Gender = GenderType.Male, DateOfBirth = new DateTime(2001, 01, 17), BirthPlace = "Danang"
            },
            new PersonModel()
            {
               Id=Guid.NewGuid() , FirstName = "Lan", LastName = "Nguyen", Gender = GenderType.Female, DateOfBirth = new DateTime(2001, 01, 17), BirthPlace = "Haiphong"
            }
        };
        public List<PersonModel> GetAll()
        {
            return people;
        }
        public void AddPerson(PersonDto person)
        {
            PersonModel model = new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                BirthPlace = person.BirthPlace,
            };
            people.Add(model);
        }
        public bool IsExist(Guid id)
        {
            if (GetPersonById(id) == null)
            {
                return false;
            }
            return true;
        }

        public PersonModel GetPersonById(Guid id)
        {
            var pa = (from p in people where p.Id == id select p).FirstOrDefault();
            return pa;
        }
        public void UpdatePerson(PersonModel personModel)
        {
            var list = people;
            PersonModel updatePerson = GetPersonById(personModel.Id);
            updatePerson = personModel;
            list.Add(updatePerson);
        }
        public void DeletePerson(Guid id)
        {
            people.Remove(GetPersonById(id));
        }
    }
}
