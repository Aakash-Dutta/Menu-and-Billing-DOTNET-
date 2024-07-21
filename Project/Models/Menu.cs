using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
	public class Menu
	{
		[Key]
		public Guid ItemId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public string ImageUrl { get; set; }

	}
}
