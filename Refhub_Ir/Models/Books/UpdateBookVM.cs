namespace Refhub_Ir.Models.Books
{
    public class UpdateBookVM
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int PageCount { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }

        public string UserId { get; set; }
        // Foreign Key
        public int CategoryId { get; set; }
    }
}
