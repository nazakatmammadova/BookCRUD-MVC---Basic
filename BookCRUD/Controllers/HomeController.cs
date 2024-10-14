using BookCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookCRUD.Controllers
{
    public class HomeController : Controller
    {
        BookMvcContext db=new BookMvcContext();
        public IActionResult Index()
        {
            ViewBag.Book=db.Books.ToList();
            ViewBag.Genre=db.Genres.ToList();
            ViewBag.Author=db.Authors.ToList();
            return View();
        }
        public IActionResult BookDetail(int Id)
        {
            //int Id = Convert.ToInt32(Request.Query["Id"]);
            var bookDetail = db.Books.Include(x => x.BookAuthor).Include(x => x.BookGenre).SingleOrDefault(x => x.Id == Id);

            RouteData.Values.Remove("id");
            if (bookDetail==null)
            {
                return NotFound();
            }
            return View(bookDetail);


        }

        public IActionResult FilterBooks(int authorId,int genreId)
        {
            var filteredBooks=db.Books.ToList();

            if (authorId != 0)
            {
                filteredBooks = filteredBooks.Where(b => b.BookAuthorId == authorId).ToList();
            }

            if (genreId != 0)
            {
                filteredBooks = filteredBooks.Where(b => b.BookGenreId == genreId).ToList();
            }

            return Json(filteredBooks.ToList());
        }

    }
}
