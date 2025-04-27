namespace Refhub_Ir.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string slug { get; set; }
        public string Description { get; set; }

        public List<Book> Books{ get; set; }
    }
}
