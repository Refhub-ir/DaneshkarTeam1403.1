using Refhub_Ir.Models.DTO;

namespace Refhub_Ir.Models.Books
{
    public class BookDetailsVM
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
        public List<BookKeywordVM> BookKeywords { get; set; } = new();
        public List<BookAuthorVM> BookAuthors { get; set; } = new();
        public List<BookRelationVM> RelatedTo { get; set; } = new();
        public List<BookRelationVM> RelatedFrom { get; set; } = new();
    }
}