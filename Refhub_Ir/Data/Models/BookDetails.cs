namespace Refhub_Ir.Models.Books
{
    public class BookDetails
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
        public List<BookKeyword> BookKeywords { get; set; } = new();
        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookRelation> RelatedTo { get; set; } = new();
        public List<BookRelation> RelatedFrom { get; set; } = new();
    }
}