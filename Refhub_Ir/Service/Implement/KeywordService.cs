using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Data.Context;
using Refhub_Ir.Models;
using Refhub_Ir.Models.DTO.Keyword;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Service.Implement
{
    public class KeywordService : IKeywordService
    {
        private AppDbContext _Context;
        public KeywordService(AppDbContext context)
        {
            _Context = context;
        }

        public async Task AddKeywordAsync(CreateKeywordVM model)
        {
            var keyword = new Keyword
            {
                Word = model.Word,

            };

            _Context.Keywords.Add(keyword);
            _Context.SaveChanges();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<KeywordListVM>> GetAllKeywordForListAsync()
        {
            return _Context.Keywords.Select(x => new KeywordListVM
            {
                Id = x.Id,
                Word = x.Word,

            }).ToListAsync();
        }

        public async Task<EditKeywordVM> GetForEdit(int id)
        {
            var keyword = _Context.Keywords.Find(id);
            if (keyword == null) return null;

            var model = new EditKeywordVM
            {
                Id = keyword.Id,
                Word = keyword.Word
            };

            return model;
        }

        public async Task UpdateAsync(EditKeywordVM vm)
        {
            var keyword = await _Context.Keywords.FindAsync(vm.Id);
            if (keyword == null) return;

            keyword.Word = vm.Word;
            _Context.Update(vm);
            await _Context.SaveChangesAsync();
        }
    }
}
