using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.ProductsAppService.Dto
{
	public class ProductsListDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
		public string? ImageUrl { get; set; } 
	}
}
