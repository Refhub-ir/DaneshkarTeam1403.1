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
    }
}
