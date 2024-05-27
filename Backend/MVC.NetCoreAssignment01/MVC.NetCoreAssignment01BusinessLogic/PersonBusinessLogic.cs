using MVC.NetCoreAssignment01.Model.Models;
using MVC.NetCoreAssignment01BusinessLogic;
using OfficeOpenXml;
using System.ComponentModel;
using System.Security.AccessControl;
namespace MVC.NetCoreAssignment01.WebApp.Services
{
    public class PersonBusinessLogic : IPersonBusinessLogic
    {
        private List<PersonModel> personsList = new List<PersonModel>()
        {
            new PersonModel()
                {
                    FirstName = "Lan",
                    LastName = "Hoang",
                    Gender = GenderType.Male,
                    DateOfBirth = new DateTime(2001, 01, 17),
                    PhoneNumber = "0398903001",
                    BirthPlace = "Hanoi",
                    IsGraduate = true
                },
                new PersonModel()
                {
                    FirstName = "Truong",
                    LastName = "Nguyen",
                    Gender = GenderType.Male,
                    DateOfBirth = new DateTime(2002, 07, 31),
                    PhoneNumber = "0945394242",
                    BirthPlace = "Haiphong",
                    IsGraduate = false
                },
                new PersonModel()
                {
                    FirstName = "Hang",
                    LastName = "Minh",
                    Gender = GenderType.Female,
                    DateOfBirth = new DateTime(1998, 02, 14),
                    PhoneNumber = "0256987455",
                    BirthPlace = "Saigon",
                    IsGraduate = true
                },
                new PersonModel()
                {
                    FirstName = "Phuong",
                    LastName = "Minh",
                    Gender = GenderType.Female,
                    DateOfBirth = new DateTime(2005, 09, 26),
                    PhoneNumber = "0987481263",
                    BirthPlace = "Nhatrang",
                    IsGraduate = true
                },
                new PersonModel()
                {
                    FirstName = "Son",
                    LastName = "Cao",
                    Gender = GenderType.Male,
                    DateOfBirth = new DateTime(2000, 03, 10),
                    PhoneNumber = "0487569210",
                    BirthPlace = "Hanoi",
                    IsGraduate = false
                },
                new PersonModel()
                {
                    FirstName = "Vu",
                    LastName = "Le",
                    Gender = GenderType.Male,
                    DateOfBirth = new DateTime(2000, 04, 12),
                    PhoneNumber = "0487569210",
                    BirthPlace = "Hanoi",
                    IsGraduate = false
                },
                new PersonModel()
                {
                    FirstName = "Phong",
                    LastName = "Hoang",
                    Gender = GenderType.Male,
                    DateOfBirth = new DateTime(2003, 07, 28),
                    PhoneNumber = "0487569210",
                    BirthPlace = "Hanoi",
                    IsGraduate = false
                },
                new PersonModel()
                {
                    FirstName = "Tuan",
                    LastName = "Hong",
                    Gender = GenderType.Male,
                    DateOfBirth = new DateTime(1994, 03, 11),
                    PhoneNumber = "0487569210",
                    BirthPlace = "Hanoi",
                    IsGraduate = false
                }
        };
        public IEnumerable<PersonModel> GetMalePersons()
        {
            var persons = from p in personsList
                          where p.Gender == GenderType.Male
                          select p;
            return persons;
        }

        public PersonModel GetOldestPerson()
        {
            PersonModel oldestPerson = new PersonModel()
            {
                DateOfBirth = DateTime.Now
            };
            foreach ( var person in personsList) {
                if (person.DateOfBirth.Year < oldestPerson.DateOfBirth.Year) oldestPerson = person;
            }
            return oldestPerson;
        }

        public List<string> GetFullName()
        {
            List<string> fullNameList = new List<string>();
            foreach ( var person in personsList)
            {
                string fullName = $"{person.LastName} {person.FirstName}";
                fullNameList.Add(fullName);
            }
            return fullNameList;
        }
       
        public IEnumerable<PersonModel> GetByDateOfBirth(string query)
        {
            int year = 2000;
            IEnumerable<PersonModel> filteredList;
            switch (query)
            {
                case "EqualTo2000":
                    filteredList = from p in personsList
                                  where p.DateOfBirth.Year == year
                                  select p;
                    return filteredList;
                case "LessThan2000":
                    filteredList = from p in personsList
                                  where p.DateOfBirth.Year < year
                                  select p;
                    return filteredList;
                case "GreaterThan2000":
                    filteredList = from p in personsList
                                   where p.DateOfBirth.Year > year
                                   select p;
                    return filteredList;

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
                    worksheet.Cells[i + 2, 7].Value = personsList[i].IsGraduate ?"Yes":"No";
                }

                //Convert excel to byte array
                return package.GetAsByteArray();
            }
        }
    } 
}
        
    

