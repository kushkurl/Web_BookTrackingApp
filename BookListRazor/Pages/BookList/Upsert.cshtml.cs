using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // If this is used for Create there is no id, so id is nullable here
        public async Task<IActionResult> OnGet(int? id)
        {
            // If we don't create an instance, Model.Book would be null on view
            // Therefore, we cannot check if Model.Book.Id is null or not
            Book = new Book();

            // Create
            if(id == null)
            {
                return Page();
            }

            // Edit
            Book = await _db.Book.FirstOrDefaultAsync(b => b.Id == id);

            if(Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Book.Id == 0)
                {
                    await _db.Book.AddAsync(Book);
                }
                else
                {
                    var bookFromDb = await _db.Book.FirstOrDefaultAsync(b => b.Id == Book.Id);
                    bookFromDb.Name = Book.Name;
                    bookFromDb.Author = Book.Author;
                    bookFromDb.ISBN = Book.ISBN;
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
