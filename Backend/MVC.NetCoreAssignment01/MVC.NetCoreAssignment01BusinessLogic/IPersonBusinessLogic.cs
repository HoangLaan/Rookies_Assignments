using MVC.NetCoreAssignment01.Model.Models;

namespace MVC.NetCoreAssignment01BusinessLogic
{
    public interface IPersonBusinessLogic
    {
        IEnumerable<PersonModel> GetMalePersons();
        PersonModel GetOldestPerson();
        List<string> GetFullName();
        IEnumerable<PersonModel> GetByDateOfBirth(string query);
        byte[] ExportExcelFile();
    }
}
