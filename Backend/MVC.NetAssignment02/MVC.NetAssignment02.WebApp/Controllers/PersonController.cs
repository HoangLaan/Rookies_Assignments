using Microsoft.AspNetCore.Mvc;
using MVC.NetAssignment02.BusinessLogic;
using MVC.NetAssignment02.Model.Model;

namespace MVC.NetAssignment02.WebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusinessLogic _personBusinessLogic;

        public PersonController(ILogger<PersonController> logger, IPersonBusinessLogic personBusinessLogic)
        {
            _logger = logger;
            _personBusinessLogic = personBusinessLogic;

        }
        public ViewResult GetMale()
        {
            List<PersonModel> maleList = _personBusinessLogic.GetMalePersons();
            return View(maleList);
        }
        public ViewResult GetOldestPerson()
        {
            return View(_personBusinessLogic.GetOldestPerson());
        }
        public ViewResult GetFullName()
        {
            return View(_personBusinessLogic.GetFullName());
        }
        public ViewResult GetByDateOfBirth(string query)
        {
            return View(_personBusinessLogic.GetByDateOfBirth(query));
        }
        public IActionResult ExportExcelFile()
        {
            //name file according to current day
            string fileName = "MvcAss01_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            return File(_personBusinessLogic.ExportExcelFile(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            List<PersonModel> personsList = _personBusinessLogic.GetAllPersons();
            return View(personsList);
        }
        [HttpGet]
        public ViewResult CreatePerson()
        {
            //_personBusinessLogic.CreatePerson(person);
            return View();
        }
        [HttpPost]
        public LocalRedirectResult CreatePerson(PersonDTO person)
        {
            _personBusinessLogic.CreatePerson(person);
            //return View("/Views/Person/GetAllPersons",list);
            return LocalRedirect("~/Person/GetAllPersons");
        }
        [HttpGet]
        public ViewResult DeletePerson(int id)
        {
            PersonModel person = _personBusinessLogic.GetPersonById(id);
            return View(person);
        }
        [HttpPost]
        public LocalRedirectResult DeletePerson(PersonModel person) {
            _personBusinessLogic.DeletePerson(person);
            return LocalRedirect("~/Person/GetAllPersons");
        }

        [HttpGet]
        public ViewResult UpdatePerson(int id)
        {
            PersonModel person = _personBusinessLogic.GetPersonById(id);
            return View(person);
        }
        [HttpPost]
        public RedirectToActionResult UpdatePerson(PersonModel viewModel)
        {
            PersonModel person = _personBusinessLogic.GetPersonById(viewModel.Id);
            if (person != null) {
                PersonDTO personDTO = new PersonDTO();
                personDTO.Id = person.Id;
                personDTO.FirstName = person.FirstName;
                person.LastName = viewModel.LastName;
                person.PhoneNumber = viewModel.PhoneNumber;
                person.DateOfBirth = viewModel.DateOfBirth;
                person.Gender = viewModel.Gender;
                person.BirthPlace = viewModel.BirthPlace;
                person.IsGraduated = viewModel.IsGraduated;
                _personBusinessLogic.CreatePerson(personDTO);
            }
            return RedirectToAction("GetAllPersons","Person");
        }

    }
}
