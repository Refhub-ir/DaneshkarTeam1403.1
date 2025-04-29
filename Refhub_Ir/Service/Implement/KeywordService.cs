using Refhub_Ir.Data.Context;

namespace Refhub_Ir.Service.Implement
{
    public class KeywordService
    {
        private AppDbContext _Context;
        public KeywordService(AppDbContext context)
        {
                _Context = context;
        }

    }
}
