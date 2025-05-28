using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Services.CustomersAppService.Dto
{
	public class CreateCustomerInput
	{
		public string Username { get; set; }
		public string PhoneNumber { get; set; }
		public int Scores { get; set; } = 0;
	}
}
