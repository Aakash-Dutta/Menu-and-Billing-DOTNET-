using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class BillController : Controller
    {

		private readonly ApplicationDbContext _context;
		public BillController(ApplicationDbContext context)
		{
			_context = context;
		}
        public IActionResult Create()
        {
            var b = new Bill();
            b.MenuItem = _context.Items.ToList().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = $"{x.ItemId}|{x.Price}",
                
            }).ToList();
            return View(b);
        }

        [HttpPost]
        public IActionResult Save(Bill bill)
        {
            var b = new Bill();
            if(bill is not null)
            {
                b.CustomerName = bill.CustomerName;
                b.GrandTotal = bill.GrandTotal;

                _context.Add(b);
                _context.SaveChanges();
                return RedirectToAction("Create");
                
            }
            return Ok();
        }

        public async Task<IActionResult> Result()
        {
            var b = await _context.Bills.ToListAsync();
            return View(b);
        }
           
    }
}
