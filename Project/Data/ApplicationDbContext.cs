using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

		public DbSet<Menu> Items { get; set; }
		public DbSet<Bill> Bills { get; set; }
	}
}
