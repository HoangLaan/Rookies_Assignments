using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.NetCoreAssignment01.Model.Models;
using MVC.NetCoreAssignment01.WebApp.Models;
using MVC.NetCoreAssignment01.WebApp.Services;

namespace MVC.NetCoreAssignment01.WebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonBusinessLogic _personBusinessLogic;

        public PersonController(ILogger<PersonController> logger, PersonBusinessLogic personBusinessLogic)
        {
            _logger = logger;
            _personBusinessLogic = personBusinessLogic;
        }

        public IActionResult GetMale()
        {
            return Json(_personBusinessLogic.GetMalePersons());
        }
        public IActionResult GetOldestPerson()
        {
            return Json(_personBusinessLogic.GetOldestPerson());
        }
        public IActionResult GetFullName()
        {
            return Json(_personBusinessLogic.GetFullName());
        }
        public IActionResult GetByDateOfBirth(string query)
        {
            return Json(_personBusinessLogic.GetByDateOfBirth(query));
        }
        public IActionResult ExportExcelFile()
        {
            //name file according to current day
            string fileName = "MvcAss01_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";
            return File(_personBusinessLogic.ExportExcelFile(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }


    }
}
