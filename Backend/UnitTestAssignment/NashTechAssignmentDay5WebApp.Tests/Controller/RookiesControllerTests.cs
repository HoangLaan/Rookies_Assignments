using DocumentFormat.OpenXml.InkML;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NashTechAssignmentDay5.Application.Helper;
using NashTechAssignmentDay5.Application.Interfaces;
using NashTechAssignmentDay5.Areas.NashTech.Controllers;
using NashTechAssignmentDay5.Domain.Entities;
using NashTechAssignmentDay5.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashTechAssignmentDay5WebApp.Tests.Controller
{
    public class RookiesControllerTests
    {
        private readonly IRookiesService _service;
        private readonly RookiesController _rookiesController;

        public RookiesControllerTests()
        {
            //Using fakeiteasy Pakage instead of Moq
            _service = A.Fake<IRookiesService>();

            //System under test / SUT
            _rookiesController = new RookiesController(_service);
        }

        [Fact]
        public void Index_GetPeople_ReturnSuccess()
        {
            //Arrange 
            var people = A.Fake<List<Person>>();
            
            A.CallTo(() => _service.GetPeople()).Returns(people);

            //Execute
            var result = _rookiesController.Index();

            //Assert
            //Object check actions
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Detail_PersonExist_ReturnSuccess()
        {
            var person = A.Fake<Person>();
            A.CallTo(() => _service.GetPersonById(person.Id)).Returns(person);

            var result = _rookiesController.Details(person.Id);

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            var model = viewResult.Model.Should().BeAssignableTo<Person>().Which;
            model.Id.Should().Be(person.Id);
        }

        [Fact]
        public void Detail_PersonNotFound_ReturnNotFound()
        {
            var person = A.Fake<Person>();
            A.CallTo(() => _service.GetPersonById(person.Id)).Returns(null);

            var result = _rookiesController.Details(person.Id);

            var notFoundResult = result.Should().BeOfType<NotFoundObjectResult>().Which;
            notFoundResult.Value.Should().Be($"No person with id: {person.Id} found");
        }
        [Fact]
        public void Create_ValidPerson_ReturnSuccess()
        {
            var validPerson = A.Fake<Person>();
            A.CallTo(() => _service.AddPerson(validPerson)).Returns(true);

            var result = _rookiesController.Create(validPerson);

            result.Should().BeOfType<RedirectToActionResult>()
                .Which.ActionName.Should().Be("Index");
        }

        [Fact]
        public void Create_InvalidPerson_ReturnsViewWithPerson()
        {
            var invalidPerson = A.Fake<Person>();
            //Empty FirstName => Invalid
            invalidPerson.FirstName = "";

            _rookiesController.ModelState.AddModelError("FirstName", "Required");

            var result = _rookiesController.Create(invalidPerson);

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            viewResult.Model.Should().Be(invalidPerson);
        }

        [Fact]
        public void Delete_ExistingPerson_ReturnsRedirectToConfirmDelete()
        {
            var person = A.Fake<Person>();
            A.CallTo(() => _service.GetPersonById(person.Id)).Returns(person);
            A.CallTo(() => _service.DeletePerson(person.Id)).Returns(true);

            var result = _rookiesController.Delete(person.Id);

            var redirectResult = result.Should().BeOfType<RedirectToActionResult>().Which;
            redirectResult.ActionName.Should().Be("ConfirmDelete");
        }

        [Fact]
        public void Delete_DeleteFails_ReturnsProblem()
        {
            var person = A.Fake<Person>();
            A.CallTo(() => _service.GetPersonById(person.Id)).Returns(person);
            A.CallTo(() => _service.DeletePerson(person.Id)).Returns(false);

            var result = _rookiesController.Delete(person.Id);

            result.Should().BeOfType<ObjectResult>();
        }

        [Fact]
        public void Edit_IdPersonExist_ReturnsSuccess()
        {
            var person = A.Fake<Person>();
            A.CallTo(() => _service.GetPersonById(person.Id)).Returns(person);

            var result = _rookiesController.Edit(person.Id);

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            viewResult.Model.Should().Be(person);
        }

        [Fact]
        public void Edit_IdPersonDoesNotExist_ReturnsNotFound()
        {
            var id = 1;
            A.CallTo(() => _service.GetPersonById(id)).Returns(null);

            var result = _rookiesController.Edit(id);

            result.Should().BeOfType<NotFoundObjectResult>()
                .Which.Value.Should().Be($"No person with id: {id} found");
        }
        [Fact]
        public void Edit_InvalidModel_ReturnsViewWithPerson()
        {
            var invalidPerson = A.Fake<Person>();
            _rookiesController.ModelState.AddModelError("FirstName", "Required");

            var result = _rookiesController.Edit(invalidPerson);

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            viewResult.Model.Should().Be(invalidPerson);
        }

        [Fact]
        public void Edit_PersonExist_ReturnsRedirectToAction()
        {
            var validPerson = A.Fake<Person>();
            A.CallTo(() => _service.EditPerson(validPerson)).Returns(true);

            var result = _rookiesController.Edit(validPerson);

            var redirectResult = result.Should().BeOfType<RedirectToActionResult>().Which;
            redirectResult.ActionName.Should().Be("Index");
        }

        [Fact]
        public void Edit_PersonNotExist_ReturnsViewWithPerson()
        {
            var validPerson = A.Fake<Person>();
            A.CallTo(() => _service.EditPerson(validPerson)).Returns(false);

            var result = _rookiesController.Edit(validPerson);

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            viewResult.Model.Should().Be(validPerson);
        }

        [Fact]
        public void GetMales_MalePersonsList_ReturnsViewWithPaginatedList()
        {
            var malePersons = new List<Person>
            {
                new Person
                {
                    Id = 1, FirstName = "Hoang", LastName = "Lan", Gender = GenderType.Male, DateOfBirth = new DateTime(2001, 01, 17),PhoneNumber = "1234567890", BirthPlace = "Hanoi", IsGraduated = true
                },
                new Person
                {
                    Id = 2, FirstName = "Lan", LastName = "Hoang", Gender = GenderType.Male, DateOfBirth = new DateTime(1995, 05, 07), PhoneNumber = "9876543210", BirthPlace = "Vietnam", IsGraduated = false
                }
            };
            A.CallTo(() => _service.GetMales()).Returns(malePersons);

            var result = _rookiesController.GetMales();

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            var model = viewResult.Model.Should().BeAssignableTo<PaginatedList<Person>>().Which;
            // Assert paginated list properties
            model.Should().NotBeNull();
            model.Count.Should().Be(2);
            model.PageIndex.Should().Be(1);
            model.TotalPages.Should().Be(1);
            // Assert paginated list content
            model.FirstOrDefault(p => p.Id == 1).Should().NotBeNull();
            model.FirstOrDefault(p => p.Id == 2).Should().NotBeNull();
        }

        [Fact]
        public void GetOldest_OldestPerson_ReturnsViewWithOldestPerson()
        {
            var oldestPerson = A.Fake<Person>();
            A.CallTo(() => _service.GetOldest()).Returns(oldestPerson);

            var result = _rookiesController.GetOldest();

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            viewResult.ViewName.Should().Be("Details");
            viewResult.Model.Should().Be(oldestPerson);
        }

        [Fact]
        public void GetFullNames_ReturnsViewWithPeopleList()
        {
            var people = new List<Person>
            {
                new Person
                {
                    Id = 1, FirstName = "Hoang", LastName = "Lan", Gender = GenderType.Male, DateOfBirth = new DateTime(2001, 01, 17),PhoneNumber = "1234567890", BirthPlace = "Hanoi", IsGraduated = true
                },
                new Person
                {
                    Id = 2, FirstName = "Lan", LastName = "Hoang", Gender = GenderType.Female, DateOfBirth = new DateTime(1995, 05, 07), PhoneNumber = "9876543210", BirthPlace = "Vietnam", IsGraduated = false
                }
            };

            A.CallTo(() => _service.GetPeople()).Returns(people);

            var result = _rookiesController.GetFullNames();

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            viewResult.Model.Should().Be(people);
        }

        [Fact]
        public void GetByBirthYear_InputIsNull_ReturnsBadRequest()
        {
            var result = _rookiesController.GetByBirthYear(null);

            result.Should().BeOfType<BadRequestObjectResult>().Which.Value.Should().Be("Please input your choice");
        }

        [Fact]
        public void GetByBirthYear_ValidInput_ReturnsViewWithPaginatedList()
        {
            var birthYear = 1990;
            var people = new List<Person>
            {
                new Person
                {
                    Id = 1, FirstName = "Hoang", LastName = "Lan", Gender = GenderType.Male, DateOfBirth = new DateTime(2001, 01, 17),PhoneNumber = "1234567890", BirthPlace = "Hanoi", IsGraduated = true
                },
                new Person
                {
                    Id = 2, FirstName = "Lan", LastName = "Hoang", Gender = GenderType.Female, DateOfBirth = new DateTime(1995, 05, 07), PhoneNumber = "9876543210", BirthPlace = "Vietnam", IsGraduated = false
                }
            }.AsQueryable();
            A.CallTo(() => _service.GetByBirthYear(birthYear));

            var result = _rookiesController.GetByBirthYear(birthYear);

            var viewResult = result.Should().BeOfType<ViewResult>().Which;
            var model = viewResult.Model.Should().BeAssignableTo<PaginatedList<Person>>().Which;

            model.Should().NotBeNull();
            model.PageIndex.Should().Be(1);
        }

        [Fact]
        public void ExportToExcel_Success_ReturnsView()
        {
            var path = "path/to/export.xlsx";
            A.CallTo(() => _service.ExportToExcel(path)).Returns(true);

            var result = _rookiesController.ExportToExcel(path);

            result.Should().BeOfType<ViewResult>();
        }
    }

}
