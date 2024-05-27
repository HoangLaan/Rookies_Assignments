using Microsoft.AspNetCore.Mvc;
using MVC.NetCoreAssignment01.WebApp.Services;
using Microsoft.AspNetCore.Http;
using MVC.NetCoreAssignment01.Model.Models;
using MVC.NetCoreAssignment01.WebApp.Models;
namespace MVC.NetCoreAssignment01.WebApp.Areas.NashTech.Controllers
{
    [Area("NashTech")]
    public class PersonController : Controller
    {
        private readonly PersonBusinessLogic _personBusinessLogic;
        public IActionResult Index()
        {
            return View("~/Areas/NashTech/Views/Person/Index.cshtml");
        }
        public PersonController(PersonBusinessLogic personBusinessLogic)
        {
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
