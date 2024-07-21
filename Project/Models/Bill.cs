using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Bill
    {
        [Key]
        public Guid BillId { get; set; }
        public string CustomerName {  get; set; }

        public Guid MenuId { get; set; }

        [NotMapped]
        public List<SelectListItem> MenuItem {  get; set; }
        public float ItemPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Total {  get; set; }
        public decimal GrandTotal { get; set; }


    }
}
