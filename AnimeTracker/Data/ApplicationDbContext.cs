using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AnimeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        {
            
        }
    }
}