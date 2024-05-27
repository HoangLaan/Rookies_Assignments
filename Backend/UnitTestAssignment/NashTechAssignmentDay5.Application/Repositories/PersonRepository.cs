using NashTechAssignmentDay5.Application.Interfaces;
using NashTechAssignmentDay5.Domain.Entities;
using NashTechAssignmentDay5.Infrastructure.Extensions;

namespace NashTechAssignmentDay5.Application.Repositories
{
	public class PersonRepository : IPersonRepository
	{
        private readonly IFileOperations _fileOperations;
        public List<Person> People { get; private set; }
		public PersonRepository(IFileOperations fileOperations)
		{
            _fileOperations = fileOperations;
            People = _fileOperations.GetDataFromFile();
		}

		public bool Create(Person person)
		{
			People.Add(person);
			return _fileOperations.SaveDataToFile(People);
		}

		public bool Delete(Person person)
		{
			People.Remove(person);
			return _fileOperations.SaveDataToFile(People);
		}

		public List<Person> FindByCondition(Func<Person, bool> condition)
		{
			return People.Where(condition).ToList();
		}

		public List<Person> GetAll()
		{
			return People;
		}

		public bool Update(Person updatedPerson)
		{
			var personToUpdate = People.Find(p => p.Id == updatedPerson.Id);
			if (personToUpdate != null)
			{
				personToUpdate.FirstName = updatedPerson.FirstName;
				personToUpdate.LastName = updatedPerson.LastName;
				personToUpdate.PhoneNumber = updatedPerson.PhoneNumber;
				personToUpdate.BirthPlace = updatedPerson.BirthPlace;
				personToUpdate.DateOfBirth = updatedPerson.DateOfBirth;
				personToUpdate.IsGraduated = updatedPerson.IsGraduated;
				personToUpdate.Gender = updatedPerson.Gender;
				return _fileOperations.SaveDataToFile(People);
			}
			return false;
		}
	}
}
