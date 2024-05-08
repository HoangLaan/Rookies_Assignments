using MVC.NetAssignment02.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.NetAssignment02.BusinessLogic
{
    public interface IPersonBusinessLogic
    {
        List<PersonModel> GetAllPersons();
        void CreatePerson(PersonDTO person);
        void DeletePerson(PersonModel person);
        PersonModel GetPersonById(int id);
        List<PersonModel> GetMalePersons();
        PersonModel GetOldestPerson();
        List<string> GetFullName();
        List<PersonModel> GetByDateOfBirth(string query);
        byte[] ExportExcelFile();
    }
}
