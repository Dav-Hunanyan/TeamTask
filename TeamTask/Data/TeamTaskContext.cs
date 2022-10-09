using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamTask.Models;

namespace TeamTask.Data
{
    public class TeamTaskContext : DbContext
    {
        public TeamTaskContext (DbContextOptions<TeamTaskContext> options)
            : base(options)
        {
        }

        public DbSet<TeamTask.Models.PageItem> PageItem { get; set; } = default!;
    }
}
