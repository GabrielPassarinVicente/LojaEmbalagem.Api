using LojaEmbalagem.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LojaEmbalagem.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Box> Boxes { get; set; }
    }
}