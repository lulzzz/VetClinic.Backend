﻿using System.Collections.Generic;

namespace VetClinic.Core.Entities
{
    public class Employee : User
    {
        public string Address { get; set; }
        public int? EmployeePositionId { get; set; }
        public EmployeePosition EmployeePosition { get; set; }
        public ICollection<OrderProcedure> OrderProcedures { get; set; }
        public ICollection<Schedule> Schedule { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
