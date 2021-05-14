using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba12.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int? DepartmentId { get; set; }

        public int? PositionId { get; set; }

        public DateTime? DateOfHiring { get; set; }

        public DateTime? DateOfFiring { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public string PassportNumber { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
