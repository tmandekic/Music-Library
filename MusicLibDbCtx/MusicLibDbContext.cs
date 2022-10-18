using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicLibDbCtx.Model;

namespace MusicLibDbCtx
{
    public class MusicLibDbContext:DbContext
    {
        public MusicLibDbContext(DbContextOptions<MusicLibDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
