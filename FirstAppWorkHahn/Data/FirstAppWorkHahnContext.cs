using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstAppWorkHahn.Models;

namespace FirstAppWorkHahn.Data
{
    public class FirstAppWorkHahnContext : DbContext
    {
        public FirstAppWorkHahnContext (DbContextOptions<FirstAppWorkHahnContext> options)
            : base(options)
        {
        }

        public DbSet<FirstAppWorkHahn.Models.Employes> Employes { get; set; } = default!;
    }
}
