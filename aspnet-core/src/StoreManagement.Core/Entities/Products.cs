using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace StoreManagement.Entities
{
	public class Products : FullAuditedEntity<int>
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; } = 0;
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
	}
}
