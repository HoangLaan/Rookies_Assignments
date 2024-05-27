using MVC.NetAssignment02.Model.Model;
using MVC.NetAssignment02.Model.Reposiroty;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.NetAssignment02.BusinessLogic
{
    public class PersonBusinessLogic : IPersonBusinessLogic
    {
        private readonly IPersonRepository _personRepository;

        public PersonBusinessLogic(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<PersonModel> GetMalePersons()
        {
            var persons = from p in _personRepository.GetAllPersons()
                          where p.Gender == GenderType.Male
                          select p;
            return persons.ToList();
        }

        public PersonModel GetOldestPerson()
        {
            var oldestPerson = _personRepository.GetAllPersons()
                                .OrderBy(person => person.DateOfBirth.Year)
                                .FirstOrDefault();
            return oldestPerson;
        }

        public List<string> GetFullName()
        {
            List<string> fullNameList = new List<string>();
            var persons = from p in _personRepository.GetAllPersons()
                          select ($"{p.LastName} {p.FirstName}");
            fullNameList.AddRange(persons);
            return fullNameList;
        }

        public List<PersonModel> GetByDateOfBirth(string query)
        {
            int year = 2000;
            IEnumerable<PersonModel> filteredList;
            switch (query)
            {
                case "EqualTo2000":
                    filteredList = from p in _personRepository.GetAllPersons()
                                   where p.DateOfBirth.Year == year
                                   select p;
                    return filteredList.ToList();
                case "LessThan2000":
                    filteredList = from p in _personRepository.GetAllPersons()
                                   where p.DateOfBirth.Year < year
                                   select p;
                    return filteredList.ToList();
                case "GreaterThan2000":
                    filteredList = from p in _personRepository.GetAllPersons()
                                   where p.DateOfBirth.Year > year
                                   select p;
                    return filteredList.ToList();

                //Throw exception when user get to wrong query
                default:
                    throw new Exception("Invalid query ! Try again with correct query");
            }
        }

        public byte[] ExportExcelFile()
        {
            using (var package = new ExcelPackage())
            {
                //Set name of the worksheet - List Persons
                var worksheet = package.Workbook.Worksheets.Add("List Persons");
                var personsList = _personRepository.GetAllPersons();

                //Add Header
                worksheet.Cells[1, 1].Value = "First Name";
                worksheet.Cells[1, 2].Value = "Last Name";
                worksheet.Cells[1, 3].Value = "Gender";
                worksheet.Cells[1, 4].Value = "Date Of Birth";
                worksheet.Cells[1, 5].Value = "Phone Number";
                worksheet.Cells[1, 6].Value = "Birth Place";
                worksheet.Cells[1, 7].Value = "Graduated";

                //Add Value
                for (int i = 0; i < personsList.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = personsList[i].FirstName;
                    worksheet.Cells[i + 2, 2].Value = personsList[i].LastName;
                    worksheet.Cells[i + 2, 3].Value = personsList[i].Gender.ToString();
                    worksheet.Cells[i + 2, 4].Value = personsList[i].DateOfBirth.ToString("dd-MM-yyyy");
                    worksheet.Cells[i + 2, 5].Value = personsList[i].PhoneNumber;
                    worksheet.Cells[i + 2, 6].Value = personsList[i].BirthPlace;
                    worksheet.Cells[i + 2, 7].Value = personsList[i].IsGraduated ? "Yes" : "No";
                }

                //Convert excel to byte array
                return package.GetAsByteArray();
            }
        }
            public void CreatePerson(PersonDTO person)
        {
            _personRepository.CreatePerson(person);
        }

        public void DeletePerson(PersonModel person)
        {
            _personRepository.DeletePerson(person);
        }

        public List<PersonModel> GetAllPersons()
        {
            var list = _personRepository.GetAllPersons();
            return list;
        }

        public PersonModel GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id); ;
        }
    }
}
