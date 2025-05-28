using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.OrderDetailAppService.Dto
{
	public class OrderDetailListDto
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
	}
}
