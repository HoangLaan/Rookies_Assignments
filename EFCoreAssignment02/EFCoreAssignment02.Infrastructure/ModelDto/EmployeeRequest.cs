using EFCoreAssignment02.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public DateTime JoinedDated { get; set; }
    }
}
