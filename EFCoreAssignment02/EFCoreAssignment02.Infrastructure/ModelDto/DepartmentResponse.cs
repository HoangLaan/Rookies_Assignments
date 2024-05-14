using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class DepartmentResponse
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
