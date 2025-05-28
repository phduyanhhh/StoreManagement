using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Entities;
using StoreManagement.Services.CustomersAppService.Dto;

namespace StoreManagement.Services.CustomersAppService
{
	public class CustomersAppService : StoreManagementAppServiceBase, ICustomersAppService
	{
		private readonly IRepository<Customers> _repositoryCustomer;
		public CustomersAppService(
			IRepository<Customers> repositoryCustomer
			)
		{
			_repositoryCustomer = repositoryCustomer;
		}
		// Create
		public async Task Create(CreateCustomerInput input)
		{
			var customer = new Customers();
			customer.Username = input.Username;
			customer.PhoneNumber = input.PhoneNumber;
			customer.Scores = input.Scores;
			await _repositoryCustomer.InsertAsync(customer);
		}
		// Get All
		public async Task<PagedResultDto<CustomersListDto>> GetAll(GetAllCustomerInput input)
		{
			var query = _repositoryCustomer
				.GetAll()
				.WhereIf(!input.Search.IsNullOrWhiteSpace(), x => x.Username.ToLower().Contains(input.Search.ToLower()))
				.OrderByDescending(x => x.CreationTime); ;
			var Count = query.Count();
			if(input.Sorting.IsNullOrWhiteSpace())
			{
				input.Sorting = "CreationTime DESC";
			}
			var items = await query.PageBy(input).OrderBy(input.Sorting)
				.Select(x => new CustomersListDto
				{
					Id = x.Id,
					Username = x.Username,
					PhoneNumber = x.PhoneNumber,
					Scores = x.Scores,
				}).ToListAsync();
			return new PagedResultDto<CustomersListDto>(Count, items);
		}
		// Update
		public async Task Update(UpdateCustomerInput input)
		{
			var customer = await _repositoryCustomer.FirstOrDefaultAsync(x => x.Id == input.Id);
			customer.Username = input.Username;
			customer.PhoneNumber = input.PhoneNumber;
			customer.Scores = input.Scores;
			await _repositoryCustomer.UpdateAsync(customer);
		}
		// Delete
		public async Task Delete(int Id)
		{
			await _repositoryCustomer.DeleteAsync(Id);
		}
		// Get An
		public async Task<CustomersListDto> ExistingCustomer(int Id)
		{
			var existingCustomer = await _repositoryCustomer.FirstOrDefaultAsync(x => x.Id == Id);
			var items = new CustomersListDto();
			items.Username = existingCustomer.Username;
			items.PhoneNumber = existingCustomer.PhoneNumber;
			items.Scores = existingCustomer.Scores;
			return items;
		}
	}
}
