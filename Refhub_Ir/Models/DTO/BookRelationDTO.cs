namespace Refhub_Ir.Models.DTO
{
    public class BookRelationDTO
    {
        public int BookId { get; set; }
        public BookDTO Book { get; set; } = new();
        public int RelatedBookId { get; set; }
        public BookDTO RelatedBook { get; set; } = new();
    }
}
public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string FilePath { get; set; }
}