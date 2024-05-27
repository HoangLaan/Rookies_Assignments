using Asp.NetAPIAssignment02.WebApp.Dto;
using Asp.NetAPIAssignment02.WebApp.Models;
using System.Net;

namespace Asp.NetAPIAssignment02.WebApp.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAllPersons();
        void AddPerson(PersonDto person);
        bool IsExist(Guid id);
        void UpdatePerson(Guid id, PersonDto persion);
        void DeletePerson(Guid id);
        List<PersonModel> FilterPerson(string firstName, string lastName, GenderType? gender, string birthPlace);

    }
}
