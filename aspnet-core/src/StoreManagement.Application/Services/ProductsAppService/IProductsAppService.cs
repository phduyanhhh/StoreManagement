using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Services.ProductsAppService.Dto;

namespace StoreManagement.Services.ProductsAppService
{
	public interface IProductsAppService : IApplicationService
	{
		Task Create([FromForm] CreateProductInput input);
		Task<FileContentResult> GetImage(int id);
		Task<PagedResultDto<ProductsListDto>> GetAll(GetAllProductsInput input);
		Task Update(UpdateProductInput input);
		Task Delete(int id);
	}
}
