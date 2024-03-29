﻿using Mangau.Demos.StockChat.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Mangau.Demos.StockChat.Infrastructure
{
    public class SCContext : SCContextBase
    {
        public SCContext()
            : this(new AppSettings())
        {

        }

        public SCContext(AppSettings appSettings)
            : base(appSettings)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(AppSettings?.ConnectionStrings?.PostgreSQL ?? "PostgreSQL");
        }
    }
}
