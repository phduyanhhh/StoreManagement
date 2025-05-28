using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Entities;

namespace StoreManagement.Services.WarehouresAppService.Dto
{
	public class CreateWarehouresInput
	{
		public int Id { get; set; }
		public int DistributorId { get; set; }
		public int ProductId { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
	}
}
