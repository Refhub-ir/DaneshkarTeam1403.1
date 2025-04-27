namespace Refhub_Ir.Models.Entities
{
    public class BookKeyword
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
