namespace Refhub_Ir.Models.Entities
{
    public class BookAuthor
    {

        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
