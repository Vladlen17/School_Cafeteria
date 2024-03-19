using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int ManagerID { get; set; }
    }
}
