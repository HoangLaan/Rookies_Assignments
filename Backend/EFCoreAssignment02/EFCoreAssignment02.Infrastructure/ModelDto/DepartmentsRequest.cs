using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class DepartmentsRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
