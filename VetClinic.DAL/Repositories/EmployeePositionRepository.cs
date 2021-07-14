﻿using VetClinic.Core.Entities;
using VetClinic.Core.Interfaces.Repositories;
using VetClinic.DAL.Context;
using VetClinic.DAL.Repositories.Base;

namespace VetClinic.DAL.Repositories
{
    public class EmployeePositionRepository : Repository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(VetClinicDbContext context) : base(context)
        {
            
        }
    }
}
