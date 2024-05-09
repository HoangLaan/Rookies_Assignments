using Asp.NetAPIAssignment02.WebApp.Dto;
using Asp.NetAPIAssignment02.WebApp.Models;

namespace Asp.NetAPIAssignment02.WebApp.Repositories
{
    public interface IPersonRepository
    {
        List<PersonModel> GetAll();
        void AddPerson(PersonDto person);
        PersonModel GetPersonById(Guid Id);
        bool IsExist(Guid Id);
        void UpdatePerson(PersonModel person);
        void DeletePerson(Guid id);
    }
}
