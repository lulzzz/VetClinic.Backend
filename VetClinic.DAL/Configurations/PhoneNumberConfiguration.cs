﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VetClinic.Core.Entities;

namespace VetClinic.DAL.Configurations
{
    class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("phone_numbers", "vetclinic");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Phone)
                    .HasMaxLength(13)
                    .IsRequired();

            builder.Property(p => p.ClientId)
                    .IsRequired();

            builder.HasOne(c => c.Client)
                .WithMany(c => c.PhoneNumbers)
                .HasForeignKey(p => p.ClientId);
        }

    }
}
