using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        //public string EmployeeGroupId { get; set; }
        public Guid EmployeeGroupId { get; set; }
    }
}
