using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesData.Models;

namespace EmployeesData.Models
{
    public class EmpDbContext : IdentityDbContext
    {
        public EmpDbContext()
        { }
        public EmpDbContext(DbContextOptions<EmpDbContext> options):base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.Entity<Register>(typeBuilder => typeBuilder.HasNoKey());
        }
        public DbSet<Employee> Employee { get; set; }
      //  public DbSet<EmployeesData.Models.Register> Register { get; set; }
    }
}
