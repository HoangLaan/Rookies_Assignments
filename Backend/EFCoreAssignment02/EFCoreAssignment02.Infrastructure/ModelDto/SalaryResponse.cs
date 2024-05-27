using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class SalaryResponse
    {
        public double Salary { get; set; }
        public string EmployeeName {  get; set; } = string.Empty;
    }
}
