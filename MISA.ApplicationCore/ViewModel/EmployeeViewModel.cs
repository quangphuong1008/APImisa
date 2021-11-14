using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    public class EmployeeViewModel : Employee
    {
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
    }
}
