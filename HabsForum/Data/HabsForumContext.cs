using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HabsForum.Models;

namespace HabsForum.Data
{
    public class HabsForumContext : DbContext
    {
        public HabsForumContext (DbContextOptions<HabsForumContext> options)
            : base(options)
        {
        }

        public DbSet<HabsForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<HabsForum.Models.Comment> Comment { get; set; } = default!;
    }
}
