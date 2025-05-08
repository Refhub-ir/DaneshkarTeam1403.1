using Refhub_Ir.Models.DTO;

namespace Refhub_Ir.Models.Books
{
    public class BookDetailsVM
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
        public List<BookKeywordDTO> BookKeywords { get; set; } = new();
        public List<BookAuthorDTO> BookAuthors { get; set; } = new();
        public List<BookRelationDTO> RelatedTo { get; set; } = new();
        public List<BookRelationDTO> RelatedFrom { get; set; } = new();
    }
}