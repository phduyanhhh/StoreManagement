using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace StoreManagement.Services.WarehouresAppService.Dto
{
	public class GetAllWarehouresInput : PagedAndSortedResultRequestDto
	{
		public string Search {  get; set; }
	}
}
