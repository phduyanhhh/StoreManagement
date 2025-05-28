using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace StoreManagement.Entities
{
	public class Warehoures : FullAuditedEntity<int>
	{
		public Distributors Distributor { get; set; }
		public int DistributorId { get; set; }

		public Products Product { get; set; }
		public int ProductId { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
	}
}
