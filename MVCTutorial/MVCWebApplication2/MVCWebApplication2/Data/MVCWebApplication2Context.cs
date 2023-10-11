using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebApplication2.Models;

namespace MVCWebApplication2.Data
{
    public class MVCWebApplication2Context : DbContext
    {
        public MVCWebApplication2Context (DbContextOptions<MVCWebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<MVCWebApplication2.Models.TodoItem> TodoItem { get; set; } = default!;
    }
}
