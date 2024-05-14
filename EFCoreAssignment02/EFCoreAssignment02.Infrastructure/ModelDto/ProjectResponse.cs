using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.ModelDto
{
    public class ProjectResponse
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
    }
}
