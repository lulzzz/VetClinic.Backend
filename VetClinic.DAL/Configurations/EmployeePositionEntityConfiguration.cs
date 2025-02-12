﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Core.Entities;

namespace VetClinic.DAL.Configurations
{
    public class EmployeePositionEntityConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.CurrentBaseSalary)
                .IsRequired();

            builder
                .Property(x => x.Rate)
                .IsRequired();

            builder
                .HasOne(x => x.Employee)
                .WithOne(x => x.EmployeePosition)
                .HasForeignKey<EmployeePosition>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(x => x.Salaries)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
