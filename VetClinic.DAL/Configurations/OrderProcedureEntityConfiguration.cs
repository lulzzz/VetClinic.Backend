﻿using Microsoft.EntityFrameworkCore;
using VetClinic.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VetClinic.DAL.Configurations
{
    public class OrderProcedureEntityConfiguration : IEntityTypeConfiguration<OrderProcedure>
    {
        public void Configure(EntityTypeBuilder<OrderProcedure> builder)
        {
            builder
                .Property(b => b.Conclusion)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(b => b.Details)
                .HasMaxLength(50);

            builder
                .HasOne(b => b.Appointment)
                .WithOne(b => b.OrderProcedure)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(b => b.Order)
                .WithOne(b => b.OrderProcedure)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
