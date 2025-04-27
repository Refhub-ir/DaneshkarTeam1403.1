namespace Refhub_Ir.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public List<BookKeyword> BookKeywords { get; set; }

    }
}
