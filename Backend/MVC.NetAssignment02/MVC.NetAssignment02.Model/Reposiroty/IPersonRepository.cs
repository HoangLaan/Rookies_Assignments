using MVC.NetAssignment02.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.NetAssignment02.Model.Reposiroty
{
    public interface IPersonRepository
    {
        List<PersonModel> GetAllPersons();
        void CreatePerson(PersonDTO person);
        void DeletePerson(PersonModel person);
        void UpdatePerson(int id);
        PersonModel GetPersonById(int id);

    }
}
