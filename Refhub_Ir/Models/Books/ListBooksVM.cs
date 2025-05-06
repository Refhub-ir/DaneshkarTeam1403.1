namespace Refhub_Ir.Models.Books
{
    public class ListBooksVM
    {
        public List<BookVM> Books { get; set; }
        public List<Category> Categories { get; set; } 
        public List<Author> Authors { get; set; } 


        public string AuthorFilter { get; set; }
        public string CategoryFilter { get; set; }

       
        

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? SearchText { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public int PreviousPage => CurrentPage - 1;
        public int NextPage => CurrentPage + 1;
    }
}
