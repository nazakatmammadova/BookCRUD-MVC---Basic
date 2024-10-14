using System;
using System.Collections.Generic;

namespace BookCRUD.Models;

public partial class Author
{
    public int Id { get; set; }

    public string? AuthorName { get; set; }

    public string? AuthorSurname { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
