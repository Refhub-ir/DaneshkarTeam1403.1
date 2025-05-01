using Refhub_Ir.Data.Context;
using Refhub_Ir.Models;
using Refhub_Ir.Models.DTO.Keyword;


namespace Refhub_Ir.Service.Interface
{
   
    public interface IKeywordService
    {
        Task<List<KeywordListVM>> GetAllKeywordForListAsync();
        Task AddKeywordAsync(CreateKeywordVM model);
       Task<EditKeywordVM> GetForEdit(int id);
        Task UpdateAsync(EditKeywordVM vm);
        Task DeleteAsync(int id);
    }
}
