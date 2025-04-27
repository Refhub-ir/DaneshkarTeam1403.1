using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Mapping;
using Refhub_Ir.Models.Entities;

namespace Refhub_Ir.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<Keyword> Keywords{ get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookKeyword> BookKeywords { get; set; }
        public DbSet<BookRelation> BookRelations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new KeywordConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookKeywordConfiguration());
            modelBuilder.ApplyConfiguration(new BookRelationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
