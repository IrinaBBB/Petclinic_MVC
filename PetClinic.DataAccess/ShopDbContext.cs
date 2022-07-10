﻿using Microsoft.EntityFrameworkCore;
using PetClinic.Models.Shop;

namespace PetClinic.DataAccess
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}