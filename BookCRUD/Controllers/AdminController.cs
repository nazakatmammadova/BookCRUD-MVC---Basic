using BookCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCRUD.Controllers
{
    public class AdminController : Controller
    {
        BookMvcContext db = new BookMvcContext();
        public IActionResult Index()
        {
            ViewBag.Book = db.Books.Include(x=> x.BookGenre).Include(x=> x.BookAuthor).ToList();
            ViewBag.Genre = db.Genres.ToList();
            ViewBag.Author=db.Authors.ToList();
            return View();
        }
        public IActionResult AddBook(Book b, IFormFile BookImg)
        {

            string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(BookImg.FileName);
            using (Stream stream = new FileStream("wwwroot/img/" + filename, FileMode.Create))
            {
                BookImg.CopyTo(stream);
            }
            b.BookImg = filename;
            db.Books.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult DeleteBook(int id)
        {
            Book b = db.Books.Find(id);
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult UpdateBook(Book updb, IFormFile BookImg)
        {
            var oldb = db.Books.Find(updb.Id);
            if (oldb != null)
            {
                if (BookImg != null)
                {
                    string photoname = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(BookImg.FileName);
                    using (Stream fileStream = new FileStream("wwwroot/img/" + photoname, FileMode.Create))
                    {
                        BookImg.CopyTo(fileStream);
                    }
                    oldb.BookImg = photoname;
                }
                oldb.BookName = updb.BookName;
                oldb.BookPrice = updb.BookPrice;
                oldb.BookGenreId = updb.BookGenreId;
                oldb.BookAuthorId=updb.BookAuthorId;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
