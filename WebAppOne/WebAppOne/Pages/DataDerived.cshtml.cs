using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppOne.Models;

namespace WebAppOne.Pages
{
    public class DataDerivedModel : PageModel
    {
        private readonly WebAppOne.Models.InvoicesContext _context;

        public DataDerivedModel(WebAppOne.Models.InvoicesContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Invoice = await _context.Invoices
                .Include(i => i.Client).ToListAsync();
        }
    }
}
