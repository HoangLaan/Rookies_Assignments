using NashTechAssignmentDay5.Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using NashTechAssignmentDay5.Application.Interfaces;
using NashTechAssignmentDay5.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NashTechAssignmentDay5.Domain.Enum;

namespace NashTechAssignmentDay5WebApp.Tests.Service
{
    public class RookiesServiceTests
    {
        private readonly IPersonRepository _personRepository;
        private readonly RookiesService _rookiesService;
        private readonly IFileOperations _fileOperations;
        public RookiesServiceTests()
        {
            _personRepository = A.Fake<IPersonRepository>();

            _rookiesService = new RookiesService(_personRepository);
        }
        [Fact]
        public void GetPeople_GetPeople_ReturnList()
        {
            var people = A.Fake<List<Person>>().ToList();
            A.CallTo(() => _personRepository.GetAll());

            var result = _rookiesService.GetPeople();

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(people);
        }
        [Fact]
        public void GetPersonById_ReturnPerson()
        {
            var expectedPerson = A.Fake<Person>();
            A.CallTo(() => _personRepository.FindByCondition(A<Func<Person, bool>>._)).Returns(new List<Person> { expectedPerson });

            var result = _rookiesService.GetPersonById(expectedPerson.Id);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedPerson);
        }
        [Fact]
        public void EditPerson_PersonUpdated_ReturnTrue()
        {
            var personToUpdate = new Person { Id = 1, FirstName = "John", LastName = "Doe" };

            var result = _rookiesService.EditPerson(personToUpdate);

            result.Should().BeFalse();
            A.CallTo(() => _personRepository.Update(personToUpdate)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public void EditPerson_PersonNotUpdated_ReturnsFalse()
        {
            var personToUpdate = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            A.CallTo(() => _personRepository.Update(personToUpdate)).Returns(false);

            var result = _rookiesService.EditPerson(personToUpdate);

            result.Should().BeFalse();
        }
        [Fact]
        public void DeletePerson_Delete_ReturnsTrue()
        {
            var personToDelete = A.Fake<Person>();
            A.CallTo(() => _personRepository.Delete(personToDelete)).Returns(true);
            A.CallTo(() => _personRepository.FindByCondition(A<Func<Person, bool>>._)).Returns(new List<Person> { personToDelete });

            var result = _rookiesService.DeletePerson(personToDelete.Id);

            result.Should().BeTrue();
            A.CallTo(() => _personRepository.Delete(personToDelete)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void AddPerson_ReturnsTrue_WhenPersonIsSuccessfullyAdded()
        {
            var personToAdd = A.Fake<Person>();

            var result = _rookiesService.AddPerson(personToAdd);

            result.Should().BeFalse();
            A.CallTo(() => _personRepository.Create(personToAdd)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void GetMales_ReturnsListOfMalePersons()
        {
            var expectedMales = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", Gender = GenderType.Male },
            new Person { Id = 2, FirstName = "Mike", LastName = "Smith", Gender = GenderType.Male }
        };

            A.CallTo(() => _personRepository.FindByCondition(A<Func<Person, bool>>._))
                .Returns(expectedMales);

            var result = _rookiesService.GetMales();

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedMales);
        }

        [Fact]
        public void GetOldest_ReturnsOldestPerson()
        {
            var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1) },
            new Person { Id = 2, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1980, 1, 1) }
        };

            A.CallTo(() => _personRepository.GetAll()).Returns(people);

            var result = _rookiesService.GetOldest();

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(people[1]); 
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetByBirthYear_ReturnsCorrectList(int input)
        {
            var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1) }, // Younger than 2000
            new Person { Id = 2, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(2010, 1, 1) }, // Older than 2000
            new Person { Id = 3, FirstName = "Bob", LastName = "Johnson", DateOfBirth = new DateTime(2000, 1, 1) } // Born in 2000
        };

            A.CallTo(() => _personRepository.FindByCondition(A<Func<Person, bool>>._)).ReturnsLazily((Func<Func<Person, bool>, List<Person>>)(condition =>
            {
                switch (input)
                {
                    case 1:
                        return people.Where(p => p.DateOfBirth.Year > 2000).ToList();
                    case 2:
                        return people.Where(p => p.DateOfBirth.Year < 2000).ToList();
                    default:
                        return people.Where(p => p.DateOfBirth.Year == 2000).ToList();
                }
            }));

            var result = _rookiesService.GetByBirthYear(input);

            result.Should().NotBeNull();
            switch (input)
            {
                case 1:
                    result.Should().OnlyContain(p => p.DateOfBirth.Year > 2000);
                    break;
                case 2:
                    result.Should().OnlyContain(p => p.DateOfBirth.Year < 2000);
                    break;
                default:
                    result.Should().OnlyContain(p => p.DateOfBirth.Year == 2000);
                    break;
            }
        }
    }
}
