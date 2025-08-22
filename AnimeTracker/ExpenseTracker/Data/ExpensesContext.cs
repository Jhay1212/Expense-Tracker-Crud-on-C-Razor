using System;
using System.Collections.Generic;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data;

public partial class ExpensesContext : DbContext
{
    public ExpensesContext()
    {
    }

    public ExpensesContext(DbContextOptions<ExpensesContext> options)
        : base(options)
    {
    }
    public DbSet<Purchase>Purchases { get; set; }
    public DbSet<UserModel>Users { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
