using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        {

        }
        
  
        public DbSet<Operations> Operations { get; set; }
  
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}
