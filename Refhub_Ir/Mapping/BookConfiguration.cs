﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refhub_Ir.Models.Entities;

namespace Refhub_Ir.Mapping
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b=>b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(155);
            builder.Property(b => b.Slug).IsRequired();
            builder.Property(b => b.PageCount).IsRequired();
            builder.Property(b => b.FilePath).IsRequired();

            builder.HasOne(b => b.Category).WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId);

            builder.HasMany(b=>b.BookKeywords).WithOne(bk=>bk.Book)
                .HasForeignKey(bk=>bk.BookId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BookAuthors).WithOne(ba => ba.Book)
            .HasForeignKey(ba => ba.BookId);

            builder.HasMany(b=>b.RelatedTo).WithOne(rt=>rt.Book)
                .HasForeignKey(bt=>bt.BookId);

            builder.HasMany(b => b.RelatedFrom).WithOne(rf => rf.RelatedBook)
                .HasForeignKey(rf => rf.RelatedBookId);

        }
    }
}
