using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {

        private readonly TaskContext _context;
        public List<Models.Task> Tasks { get; set; }

        public IndexModel(TaskContext db)
        {
            _context = db; 
        }
        
        public void OnGet()
        {
            Tasks = _context.Tasks.ToList();
        }
        public async Task<IActionResult> OnPostEditAsync (int id)
        {
            var person = await _context.Tasks.FindAsync(id);
            _context.Entry(Tasks).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var person = await _context.Tasks.FindAsync(id);

            if (person != null)
            {
                _context.Tasks.Remove(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}
