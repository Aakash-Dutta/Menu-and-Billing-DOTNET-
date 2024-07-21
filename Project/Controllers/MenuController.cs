using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
	public class MenuController : Controller
	{
		private readonly ApplicationDbContext _context;
		public MenuController(ApplicationDbContext context)
		{
			_context = context;
		}
		// GET: MenuController
		public async Task<IActionResult> Index()
		{
			var items = await _context.Items.ToListAsync();
			return View(items);
		}

	
		// GET: MenuController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: MenuController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] Menu formdata)
		{
			var item = new Menu();
			if (ModelState.IsValid)
			{
				try
				{
					item.Name = formdata.Name;
					item.Description = formdata.Description;
					item.Price = formdata.Price;
					item.ImageUrl = formdata.ImageUrl;

					_context.Add(item);
					await _context.SaveChangesAsync();
				}
				catch(DbUpdateConcurrencyException)
				{
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View();
		}

		// GET: MenuController/Edit/5
		public  async Task<IActionResult> Edit(Guid id)
		{
			var item = await _context.Items.FindAsync(id);
			return View(item);
		
		}

		// POST: MenuController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Menu viewModel)
		{
			var item = await _context.Items.FindAsync(viewModel.ItemId);

			if (item is not null)
			{
				item.Name = viewModel.Name;
				item.Description = viewModel.Description;
				item.Price = viewModel.Price;
				item.ImageUrl = viewModel.ImageUrl;

				await _context.SaveChangesAsync();

			}

			return RedirectToAction("Index","Menu");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var item = await (_context.Items.FindAsync(id));
			return View(item);
		}


		// POST: MenuController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Menu viewModel)
		{
			var item = await _context.Items.AsNoTracking().FirstOrDefaultAsync(x => x.ItemId == viewModel.ItemId);

			if(item is not null)
			{
				_context.Items.Remove(viewModel);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction("Index", "Menu");
		}
	}
}
