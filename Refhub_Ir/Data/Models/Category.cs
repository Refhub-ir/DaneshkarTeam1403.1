﻿namespace Refhub_Ir.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? slug { get; set; }
        public string? Description { get; set; }

        public List<Book> Books{ get; set; }
    }
}
