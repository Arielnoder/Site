using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BooksDB.Models;

namespace BooksDB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult RemoveBook() {

        
        using (var db = new BookContext()) {
        
        }

        return View("AddBooks");
    }

    public IActionResult AddBooks()
    {

        List<BooksModel> books = new List<BooksModel>();

        using (var db = new BookContext())
        {
            books = db.Books.ToList();
        }

        TempData["books"] = books;

        return View();
    }

    [HttpPost]
    public IActionResult AddBooks(BooksModel book)
    {
        using (var db = new BookContext())
        {
            db.Add(book);
            db.SaveChanges();
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
