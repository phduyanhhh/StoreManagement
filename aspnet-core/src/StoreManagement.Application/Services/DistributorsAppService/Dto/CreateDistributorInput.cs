using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.DistributorsAppService.Dto
{
	public class CreateDistributorInput
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string Email {  get; set; }
	}
}
