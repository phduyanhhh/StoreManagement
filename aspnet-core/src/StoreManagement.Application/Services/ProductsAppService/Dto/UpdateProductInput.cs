using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StoreManagement.Services.ProductsAppService.Dto
{
	public class UpdateProductInput
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; } = 0;
	}
}
