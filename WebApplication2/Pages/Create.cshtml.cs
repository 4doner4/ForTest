using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using Task = WebApplication2.Models.Task;

namespace WebApplication2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TaskContext _context;
        public List<Task> Tasks { get; set; }
        public CreateModel(TaskContext db)
        {
            _context = db;
        }

        public async Task<IActionResult> OnPostAsync(Task task)
        {

            if (task != null)
            {
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Index");    
        }
    }
}
