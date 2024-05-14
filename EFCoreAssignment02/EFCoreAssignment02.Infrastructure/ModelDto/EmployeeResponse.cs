using EFCoreAssignment02.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class EmployeeResponse
    {
        public string Name { get; set; } = string.Empty;

        public DateTime JoinedDated { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}
