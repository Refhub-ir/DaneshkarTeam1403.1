using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refhub_Ir.Models.Entities;

namespace Refhub_Ir.Mapping
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a=>a.Id);
            builder.Property(a=>a.FullName).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Slug).IsRequired();

            builder.HasMany(a => a.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
