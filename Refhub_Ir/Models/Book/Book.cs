namespace Refhub_Ir.Models.Book
{
    public class Book
    {
        // Primary Key
        public int Id { get; set; }

        // Basic Properties
        public string Title { get; set; }
        public string Slug { get; set; }
        public int PageCount { get; set; }
        public string FilePath { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Properties
        // Preventing NullReferenceException by initializing collections.
        public Category Category { get; set; }
        public List<BookKeyword> BookKeywords { get; set; } = new();
        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookRelation> RelatedTo { get; set; } = new();
        public List<BookRelation> RelatedFrom { get; set; } = new();
    }
}
