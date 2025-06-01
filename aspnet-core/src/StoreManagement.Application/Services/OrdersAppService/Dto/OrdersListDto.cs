using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using StoreManagement.Entities;

namespace StoreManagement.Services.OrdersAppService.Dto
{
	public class OrdersListDto
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public int TotalPrice { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public string CustomerName { get; set; }
		public DateTime CreationTime { get; set; }
	}
}
