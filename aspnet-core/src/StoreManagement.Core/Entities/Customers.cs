using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace StoreManagement.Entities
{
	public class Customers : FullAuditedEntity<int>
	{
		public string Username { get; set; }
		public string PhoneNumber { get; set; }
		public int Scores { get; set; } = 0;
	}
}
