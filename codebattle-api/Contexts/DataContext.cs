using Microsoft.EntityFrameworkCore;
using codebattle_api.Entities;

namespace codebattle_api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Friend>? Friend { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<Game>? Game { get; set; }
        public DbSet<GameMode>? GameMode { get; set; }
        public DbSet<Participant>? Participant { get; set; }
        public DbSet<Step>? Step { get; set; }
        public DbSet<Tag>? Tag { get; set; }
        public DbSet<Badge>? Badge { get; set; }
    }
}
