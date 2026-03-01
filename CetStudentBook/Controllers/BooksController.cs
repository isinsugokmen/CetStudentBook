using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CetStudentBook.Data;
using CetStudentBook.Models;

namespace CetStudentBook.Controllers;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    // LIST
    
    public async Task<IActionResult> Index()
    {
        var books = await _context.Books.ToListAsync();
        return View(books);
    }

    
    // CREATE - GET
    
    public IActionResult Create()
    {
        return View();
    }

   
    // CREATE - POST
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid)
            return View(book);

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    
    // EDIT - GET
    
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        return View(book);
    }

    
    // EDIT - POST
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(book);

        var exists = await _context.Books.AnyAsync(b => b.Id == id);
        if (!exists)
            return NotFound();

        _context.Update(book);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    
    // DELETE - GET
    
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        return View(book);
    }

    
    // DELETE - POST
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}