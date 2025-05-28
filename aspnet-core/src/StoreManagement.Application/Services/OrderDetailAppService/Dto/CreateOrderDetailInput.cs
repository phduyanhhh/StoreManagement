using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Entities;
using StoreManagement.Services.OrdersAppService.Dto;

namespace StoreManagement.Services.OrderDetailAppService.Dto
{
	public class CreateOrderDetailInput
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
	}
}
