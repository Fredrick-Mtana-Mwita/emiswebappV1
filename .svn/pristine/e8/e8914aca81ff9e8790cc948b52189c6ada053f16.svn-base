using EMISWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMISWebApp.DAL
{
    
    public class EMISDBContext:DbContext
    {
        public EMISDBContext(DbContextOptions<EMISDBContext>options): base(options)
        {
            
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<EmployeeAllowance> EmployeeAllowances { get; set; }
    }
}
