using System;
using System.Collections.Generic;

namespace BookCRUD.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? BookName { get; set; }

    public double? BookPrice { get; set; }

    public string? BookImg { get; set; }

    public int? BookGenreId { get; set; }

    public int? BookAuthorId { get; set; }

    public virtual Author? BookAuthor { get; set; }

    public virtual Genre? BookGenre { get; set; }
}
