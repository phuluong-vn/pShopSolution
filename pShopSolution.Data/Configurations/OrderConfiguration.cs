﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ShipEmail).IsRequired().HasMaxLength(200).IsUnicode(false);
            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
