using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab1.DAL.Data;
using Lab1.DAL.Entities;

namespace Lab1.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Lab1.DAL.Data.ApplicationDbContext _context;

        public IndexModel(Lab1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.Group).ToListAsync();
        }
    }
}
