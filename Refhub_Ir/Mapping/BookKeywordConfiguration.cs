using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refhub_Ir.Models.Entities;

namespace Refhub_Ir.Mapping
{
    public class BookKeywordConfiguration : IEntityTypeConfiguration<BookKeyword>
    {
        public void Configure(EntityTypeBuilder<BookKeyword> builder)
        {
            builder.HasOne(bk => bk.Book).WithMany(b => b.BookKeywords)
                .HasForeignKey(bk => bk.BookId);

            builder.HasOne(bk => bk.Keyword).WithMany(b => b.BookKeywords)
                .HasForeignKey(bk => bk.KeywordId);
        }
    }
}
