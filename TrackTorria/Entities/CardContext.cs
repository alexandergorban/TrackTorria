using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrackTorria.Entities
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
