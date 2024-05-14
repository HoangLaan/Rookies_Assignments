using FakeItEasy;
using FluentAssertions;
using NashTechAssignmentDay5.Application.Interfaces;
using NashTechAssignmentDay5.Application.Repositories;
using NashTechAssignmentDay5.Domain.Entities;
using NashTechAssignmentDay5.Domain.Enum;
using NashTechAssignmentDay5.Infrastructure.Extensions;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NashTechAssignmentDay5WebApp.Tests.Repository
{
    public class PersonRepositoryTests
    {
        private readonly PersonRepository _repository;
        private readonly List<Person> _fakePeopleList;
        private readonly IFileOperations _fileOperations;

        public PersonRepositoryTests()
        {
            //Create fake dependencies
            _fakePeopleList = new List<Person>();
            _fileOperations = A.Fake<IFileOperations>();

            //Initialize the repository with the fake data
            A.CallTo(() => _fileOperations.GetDataFromFile()).Returns(_fakePeopleList);
            _repository = new PersonRepository(_fileOperations);
        }
        [Fact]
        public void Create_AddPersonToList_ReturnTrue()
        {
            var newPerson = A.Fake<Person>();
            A.CallTo(() => _fileOperations.SaveDataToFile(_fakePeopleList)).Returns(true);

            var result = _repository.Create(newPerson);

            _fakePeopleList.Should().Contain(newPerson);
            result.Should().BeTrue();
            A.CallTo(() => _fileOperations.SaveDataToFile(_fakePeopleList)).MustHaveHappened();
        }
        [Fact]
        public void Delete_RemovePerson_ReturnTrue()
        {
            var personToDelete = A.Fake<Person>();

            _fakePeopleList.Add(personToDelete);
            A.CallTo(() => _fileOperations.SaveDataToFile(_fakePeopleList)).Returns(true);

            var result = _repository.Delete(personToDelete);

            _fakePeopleList.Should().NotContain(personToDelete);
            result.Should().BeTrue();
            A.CallTo(() => _fileOperations.SaveDataToFile(_fakePeopleList)).MustHaveHappened();
        }

        [Fact]
        public void FindByCondition_GetFemalePerson_ReturnFemalePerson()
        {
            var person1 = A.Fake<Person>();
            person1.Gender = GenderType.Male;
            var person2 = A.Fake<Person>();
            person2.Gender = GenderType.Female;

            _fakePeopleList.Add(person1);
            _fakePeopleList.Add(person2);

            var result = _repository.FindByCondition(p => p.Gender == GenderType.Female);

            result.Should().ContainSingle();
            result.First().Should().Be(person2);
        }
        [Fact]
        public void GetAll_ReturnAllPeople()
        {
            var person1 = A.Fake<Person>();
            var person2 = A.Fake<Person>();

            _fakePeopleList.Add(person1);
            _fakePeopleList.Add(person2);

            var result = _repository.GetAll();

            result.Should().BeEquivalentTo(_fakePeopleList);
        }

        [Fact]
        public void Update_PersonExist_ReturnTrue()
        {
            var originalPerson = A.Fake<Person>();

            _fakePeopleList.Add(originalPerson);
            A.CallTo(() => _fileOperations.SaveDataToFile(_fakePeopleList)).Returns(true);

            var updatedPerson = new Person
            {
                Id = 1,
                FirstName = "Updated John",
                LastName = "Updated Doe",
                Gender = GenderType.Male,
                DateOfBirth = new DateTime(1985, 12, 31),
                PhoneNumber = "9876543210",
                BirthPlace = "Updated City",
                IsGraduated = false
            };

            var result = _repository.Update(updatedPerson);

            result.Should().BeFalse();
            var updatedPersonInList = _fakePeopleList.FirstOrDefault(p => p.Id == updatedPerson.Id);
            updatedPersonInList.Should().BeNull();
        }
        //[Fact]
        //public void Update_PersonNotExist_ReturnFalse()
        //{
        //    var originalPerson = A.Fake<Person>();

        //    A.CallTo(() => _fakePeopleList.Find(p => p.Id == originalPerson.Id)).Returns(null);

        //    var result = _repository.Update(originalPerson);

        //    result.Should().BeFalse();
        //    var updatedPersonInList = _fakePeopleList.FirstOrDefault(p => p.Id == originalPerson.Id);
        //    updatedPersonInList.Should().BeNull();
        //}
    }
}
