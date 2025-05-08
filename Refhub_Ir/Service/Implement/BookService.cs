﻿using Azure;
using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Areas.Admin.DTOs;
using Refhub_Ir.Data.Context;
using Refhub_Ir.Models.Books;
using Refhub_Ir.Models.DTO;
using Refhub_Ir.Models.Categories;
using Refhub_Ir.Service.Interface;
using Refhub_Ir.Tools.Static;
using System.Drawing.Printing;

namespace Refhub_Ir.Service.Implement
{
    public class BookService(
                             AppDbContext context,
                             IFileUploaderService uploaderService) : IBookService
    {
        public async Task<IEnumerable<CategoryDropDownVM>> GetCategoriesAsync(int Id, CancellationToken ct)
        {
            var category = context.Categories.AsQueryable();



            return await category.Select(a => new CategoryDropDownVM()
            {
                Id = a.Id,
                Name = a.Name,
                IsSelected = a.Id.Equals(Id)

            }).ToListAsync(ct);
        }

        public async Task<IEnumerable<CategoryDropDownVM>> GetAnothersAsync(List<int> Ids, CancellationToken ct)
        {
            // بررسی ورودی
            if (Ids == null || !Ids.Any())
            {
                Ids = new List<int>();
            }

            //todo
            var anothers = context.Authors.AsQueryable();

            return await anothers.Select(a => new CategoryDropDownVM()
            {
                Id = a.Id,
                Name = a.FullName,
                IsSelected = Ids.Contains(a.Id),

            }).ToListAsync(ct);
        }

        public async Task<bool> CreateAnotherAsync(string fullname, string slug, CancellationToken ct)
        {
            await context.Authors.AddAsync(new Author() { Slug = slug, FullName = fullname }, ct);
            await context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<BookVM>> GetBooksAsync(string? searchText, CancellationToken ct)
        {
            var books = context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                books = books.Where(a => a.Title.Contains(searchText));
            }

            return await books
               .Select(a => new BookVM()
               {
                   Id = a.Id,
                   Title = a.Title,
                   UserId = a.UserId,
                   ImagePath = a.ImagePath,
                   Slug = a.Slug,

               }).ToListAsync(ct);
        }

        public async Task<UpdateBookVM> GetBookDetialsForUpdateAsync(int Id, CancellationToken ct)
        {
            UpdateBookVM model = new UpdateBookVM();
            var book = await context.Books.Include(a => a.BookAuthors).FirstOrDefaultAsync(a => a.Id.Equals(Id), ct);
            if (book != null)
            {
                model.Slug = book.Slug;
                model.Title = book.Title;
                model.CategoryId = book.CategoryId;
                model.FilePath = book.FilePath;
                model.ImagePath = book.ImagePath;
                model.PageCount = book.PageCount;
                model.UserId = book.UserId;
                model.AnotherId = book.BookAuthors.Select(a => a.AuthorId).ToList();
            }

            return model;
        }

        public Task<IEnumerable<BookVM>> GetBookAsync(int Id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateBookAsync(CreateBookVM book, CancellationToken ct)
        {
            try
            {
                var BookAuthors = book.AnotherId.Select(a => new BookAuthor()
                {
                    AuthorId = a
                });
                var _book = new Book()
                {
                    CategoryId = book.CategoryId,
                    Slug = book.Slug,

                    PageCount = book.PageCount,
                    FilePath = await uploaderService.UpdloadFile(book.File, FolderNameStatic.GetDirectoryBooks, FolderNameStatic.GetDirectoryImages, book.Slug),
                    ImagePath = await uploaderService.UpdloadFile(book.Image, FolderNameStatic.GetDirectoryBooks, FolderNameStatic.GetDirectoryImages, book.Slug),

                    Title = book.Title,
                    UserId = book.UserId,
                    BookAuthors = BookAuthors.ToList()
                };
                await context.Books.AddAsync(_book, ct);
                await context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> UpdateBookAsync(UpdateBookVM book, CancellationToken ct)
        {
            try
            {

                var _book = await context.Books.FirstOrDefaultAsync(a => a.Id.Equals(book.Id), ct);

                _book.CategoryId = book.CategoryId;
                _book.Slug = book.Slug;

                _book.PageCount = book.PageCount;
                if (book.File != null)
                {

                    await uploaderService.DeleteFile(FolderNameStatic.GetDirectoryBooks,
                        FolderNameStatic.GetDirectoryImages, _book.FilePath);
                    _book.FilePath = await uploaderService.UpdloadFile(book.File, FolderNameStatic.GetDirectoryBooks,
                        FolderNameStatic.GetDirectoryImages, book.Slug);

                }
                if (book.Image != null)
                {
                    await uploaderService.DeleteFile(FolderNameStatic.GetDirectoryBooks,
                        FolderNameStatic.GetDirectoryImages, _book.ImagePath);
                    _book.ImagePath = await uploaderService.UpdloadFile(book.Image, FolderNameStatic.GetDirectoryBooks,
                        FolderNameStatic.GetDirectoryImages, book.Slug);

                }
                _book.Title = book.Title;
                _book.UserId = book.UserId;
                context.BookAuthors.RemoveRange(context.BookAuthors.Where(a => a.BookId.Equals(book.Id)));
                await context.SaveChangesAsync(ct);
                var BookAuthors = book.AnotherId.Select(a => new BookAuthor()
                {
                    AuthorId = a
                });

                _book.BookAuthors = BookAuthors.ToList();

                context.Books.Update(_book);
                await context.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public async Task<bool> DeleteBookAsync(int Id, CancellationToken ct)
        {
            var book = context.Books.FirstOrDefault(a => a.Id.Equals(Id));
            if (book != null)
            {
                await uploaderService.DeleteFile(FolderNameStatic.GetDirectoryBooks,
                    FolderNameStatic.GetDirectoryImages, book.ImagePath);
                await uploaderService.DeleteFile(FolderNameStatic.GetDirectoryBooks,
                    FolderNameStatic.GetDirectoryImages, book.FilePath);
                context.Books.Remove(book);
                await context.SaveChangesAsync(ct);
                return true;
            }

            return false;
        }

        public async Task<BookDetailsVM> GetBookDetailsBySlugAsync(string slug, CancellationToken ct)
        {
            var book = await context.Books
                .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords).ThenInclude(bk => bk.Keyword)
                .Include(b => b.RelatedTo).ThenInclude(r => r.RelatedBook)
                .FirstOrDefaultAsync(b => b.Slug == slug, ct);

            if (book == null) return null;

            return new BookDetailsVM
            {
                Title = book.Title,
                Slug = book.Slug,
                FilePath = book.FilePath,
                ImagePath = book.ImagePath,
                BookAuthors = book.BookAuthors.Select(ba => new BookAuthorVM
                {
                    BookId = ba.BookId,
                    AuthorId = ba.AuthorId,
                    Author = new AuthorDTO
                    {
                        Id = ba.Author.Id,
                        FullName = ba.Author.FullName
                    }
                }).ToList(),
                BookKeywords = book.BookKeywords.Select(bk => new BookKeywordVM
                {
                    BookId = bk.BookId,
                    KeywordId = bk.KeywordId,
                    Keyword = new KeywordDTO
                    {
                        Id = bk.Keyword.Id,
                        Word = bk.Keyword.Word
                    }
                }).ToList(),
                RelatedTo = book.RelatedTo.Select(r => new BookRelationVM
                {
                    BookId = r.BookId,
                    RelatedBookId = r.RelatedBookId,
                    RelatedBook = new BookVM
                    {
                        Id = r.RelatedBook.Id,
                        Title = r.RelatedBook.Title,
                        Slug = r.RelatedBook.Slug
                    }
                }).ToList(),
                RelatedFrom = book.RelatedFrom.Select(r => new BookRelationVM
                {
                    BookId = r.BookId,
                    RelatedBookId = r.RelatedBookId,
                    RelatedBook = new BookVM
                    {
                        Id = r.RelatedBook.Id,
                        Title = r.RelatedBook.Title,
                        Slug = r.RelatedBook.Slug
                    }
                }).ToList()
            };
        }

        public async Task<ListBooksVM> GetListAsync(string searchText, string authorFilter, string categoryFilter, int pageSize, int page, CancellationToken ct)
        {
            var booksquery = context.Books
                                    .Include(b => b.Category)
                                    .Include(x => x.BookAuthors)
                                    .ThenInclude(x => x.Author)
                                    .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.Trim().ToLower();
                booksquery = booksquery.Where(b => b.Title.ToLower().Contains(searchText));
            }

            if (!string.IsNullOrEmpty(authorFilter))
            {
                var normalizedAuthor = authorFilter.Trim().ToLower();
                booksquery = booksquery.Where(x => x.BookAuthors.Any(c => c.Author.FullName.ToLower().Contains(normalizedAuthor)));
            }

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                var normalizedCategory = categoryFilter.Trim().ToLower();
                booksquery = booksquery.Where(x => x.Category.Name.ToLower().Contains(normalizedCategory));
            }


            var totalItems = await booksquery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);


            page = Math.Max(1, Math.Min(page, Math.Max(1, totalPages)));



            var books = await booksquery
                              .OrderBy(x => x.Title)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .Select(a => new BookVM
                              {
                                  Id = a.Id,
                                  Title = a.Title,
                                  Slug = a.Slug,
                                  ImagePath = a.ImagePath,
                                  UserId = a.UserId
                              })
                              .ToListAsync(cancellationToken: ct);

            var authors = await context.Authors
                                        .OrderBy(a => a.FullName).Select(x => new AuthorVM
                                        {
                                            FullName = x.FullName,
                                        })
                                        .ToListAsync(cancellationToken: ct);


            var categories = await context.Categories
                                           .OrderBy(c => c.Name).Select(x => new CategoryVM
                                           {
                                               Name = x.Name
                                           })
                                           .ToListAsync(cancellationToken: ct);

            return new ListBooksVM
            {
                Books = books,
                Categories = categories,
                Authors = authors,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchText = searchText,
                AuthorFilter = authorFilter,
                CategoryFilter = categoryFilter
            };
        }
    }
}
