
namespace BarApplication
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BarDatabaseEntities : DbContext
    {
        public BarDatabaseEntities()
            : base("name=BarDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Artikl> Artikl { get; set; }
        public DbSet<Cjenik> Cjenik { get; set; }
        public DbSet<CjenikArtikl> CjenikArtikl { get; set; }
        public DbSet<Konobar> Konobar { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<RacunArtiklCjenik> RacunArtiklCjenik { get; set; }
        public DbSet<Stol> Stol { get; set; }
    }
}
