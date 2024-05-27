using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class SalaryRequest
    {
        public double Salary { get; set; }
        public Guid EmployeeId { get; set; }

    }
}
