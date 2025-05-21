using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Abp.Domain.Entities.Auditing;

namespace StoreManagement.Entities
{
	public class Distributors : FullAuditedEntity<int>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
