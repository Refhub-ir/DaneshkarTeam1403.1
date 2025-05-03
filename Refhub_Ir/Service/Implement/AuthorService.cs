﻿using Refhub_Ir.Areas.Admin.DTOs;
using Refhub_Ir.Data.Models;
using Refhub_Ir.Models;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Service.Implement
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorVM>> GetAllAuthorsAsync( CancellationToken ct)
        {
            var authors = await _authorRepository.GetAllAsync(ct);
            return authors.Select(a => new AuthorVM
            {
                FullName = a.FullName,
                Slug = a.Slug
            }).ToList();
        }


        public async Task<AuthorVM> GetAuthorBySlugAsync(string slug, CancellationToken ct)
        {
            var author = await _authorRepository.GetBySlugAsync(slug, ct);
            if (author == null) return null;
            return new AuthorVM
            {
                FullName = author.FullName,
                Slug = author.Slug
            };
        }

        public async Task CreateAuthorAsync(AuthorVM authorVm, CancellationToken ct)
        {
            // چک کردن منحصربه‌فرد بودن Slug
            if (await _authorRepository.SlugExistsAsync(ct,authorVm.Slug))
            {
                throw new Exception("اسلاگ قبلاً استفاده شده است");
            }

            var author = new Author
            {
                FullName = authorVm.FullName,
                Slug = authorVm.Slug
            };
            await _authorRepository.AddAsync(author,ct);
        }

        public async Task UpdateAuthorAsync(AuthorVM authorVm, string originalSlug, CancellationToken ct)
        {
            var author = await _authorRepository.GetBySlugAsync(originalSlug, ct);
            if (author == null) throw new Exception("نویسنده پیدا نشد");

            if (authorVm.Slug != originalSlug && await _authorRepository.SlugExistsAsync(ct,authorVm.Slug))
            {
                throw new Exception("اسلاگ قبلاً استفاده شده است");
            }

            author.FullName = authorVm.FullName;
            author.Slug = authorVm.Slug;

            await _authorRepository.UpdateAsync(author,ct);
        }


        public async Task DeleteAuthorAsync(string slug, CancellationToken ct)
        {
            var author = await _authorRepository.GetBySlugAsync(slug,ct);
            if (author == null) throw new Exception("نویسنده پیدا نشد");
            await _authorRepository.DeleteAsync(slug, ct);
        }
    }
}