using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace StoreManagement.Entities
{
	public class Orders : FullAuditedEntity<int>
	{
		public Customers Customer { get; set; }
		public int? CustomerId { get; set; }
		public int TotalPrice { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
	}
	public enum PaymentMethod
	{
		Cash = 0,
		Transfer = 1
	}
}
