using Asp.NetAPIAssignment02.WebApp.Dto;
using Asp.NetAPIAssignment02.WebApp.Repositories;
using Asp.NetAPIAssignment02.WebApp.Models;
using AutoMapper;
using System.Reflection;

namespace Asp.NetAPIAssignment02.WebApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;

        public readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepo = personRepository;
            _mapper = mapper;
        }
        public List<PersonModel> GetAllPersons()
        {
            return _personRepo.GetAll();
        }
        public void AddPerson(PersonDto person)
        {
            _personRepo.AddPerson(person);
        }
        public bool IsExist(Guid id)
        {
            return _personRepo.IsExist(id);
        }
        public void UpdatePerson(Guid id ,PersonDto personDto)
        {
            PersonModel personModel = _personRepo.GetPersonById(id);
            GetAllPersons();
            if (personModel != null) 
            {
                personModel = _mapper.Map<PersonModel>(personDto);
                _personRepo.UpdatePerson(personModel);
            }
        }
        public void DeletePerson(Guid id)
        {
            _personRepo.DeletePerson(id);
        }
        public List<PersonModel> FilterPerson(string firstName, string lastName, GenderType? gender, string birthPlace)
        {
            var filteredPeople = GetAllPersons();

            if (!string.IsNullOrEmpty(firstName))
            {
                filteredPeople = filteredPeople
                    .Where(p => p.FirstName.ToLower() == firstName.ToLower())
                    .ToList();
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                filteredPeople = filteredPeople
                    .Where(p => p.LastName.ToLower() == lastName.ToLower())
                    .ToList();
            }
            if (gender.HasValue)
            {
                filteredPeople = filteredPeople
                    .Where(p => p.Gender == gender.Value)
                    .ToList();
            }
            if (!string.IsNullOrEmpty(birthPlace))
            {
                filteredPeople = filteredPeople
                    .Where(p => p.BirthPlace.ToLower() == birthPlace.ToLower())
                    .ToList();
            }
            return filteredPeople;
        }
    }
}
