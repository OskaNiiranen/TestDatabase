using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

    public class FreeAzureSqlContext : DbContext
    {
        public FreeAzureSqlContext (DbContextOptions<FreeAzureSqlContext> options)
            : base(options)
        {
        }

        public DbSet<webAPI.Models.Testitaulu> Testitaulu { get; set; } = default!;
    }
