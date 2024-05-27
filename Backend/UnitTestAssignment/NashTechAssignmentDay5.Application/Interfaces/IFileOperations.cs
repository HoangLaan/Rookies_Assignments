using NashTechAssignmentDay5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashTechAssignmentDay5.Application.Interfaces
{
    public interface IFileOperations
    {
        List<Person> GetDataFromFile();
        bool SaveDataToFile(List<Person> people);
    }
}

