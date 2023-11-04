﻿using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodDeliveryDemo.EntityFrameworkCore.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(v =>
            {
                v.HasKey(v => v.Id);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(v => v.Id);
                o.Property<Guid>("Id").ValueGeneratedOnAdd();
            });
        }
    }
}
