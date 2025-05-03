﻿using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Data.Models;
using Refhub_Ir.Models;

namespace Refhub_Ir.Service.Interface
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync( CancellationToken ct);
        Task<Author> GetBySlugAsync(string slug, CancellationToken ct);
        Task AddAsync(Author author, CancellationToken ct);
        Task UpdateAsync(Author author, CancellationToken ct);
        Task DeleteAsync(string  slug, CancellationToken ct);
        Task<bool> SlugExistsAsync( CancellationToken ct,string slug,  string?  excludeSlug = null);
    }
}
