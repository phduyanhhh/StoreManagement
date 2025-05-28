using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Entities;

namespace StoreManagement.Services.OrdersAppService.Dto
{
	public class CreateOrderInput
	{
		public int? CustomerId { get; set; }
		public int TotalPrice { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
	}
}
