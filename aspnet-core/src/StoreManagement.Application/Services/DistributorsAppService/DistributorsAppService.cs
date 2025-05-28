using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Entities;
using StoreManagement.Services.DistributorsAppService.Dto;

namespace StoreManagement.Services.DistributorsAppService
{
	public class DistributorsAppService : StoreManagementAppServiceBase, IDistributorsAppService
	{
		private readonly IRepository<Distributors, int> _repositoryDistributors;
		
		public DistributorsAppService(
			IRepository<Distributors, int> repositoryDistributors
			)
		{
			_repositoryDistributors = repositoryDistributors;
		}

		// Create
		public async Task Create(CreateDistributorInput input)
		{
			var distributor = new Distributors();
			distributor.Name = input.Name;
			distributor.PhoneNumber = input.PhoneNumber;
			distributor.Email = input.Email;
			await _repositoryDistributors.InsertAsync( distributor );
			//return distributor;
		}

		// Get All Paging
		public async Task<PagedResultDto<DistributorsListDto>> GetAll(GetAllDistributorsInput input)
		{
			var query = _repositoryDistributors
				.GetAll()
				.WhereIf(!input.Search.IsNullOrWhiteSpace(), d => d.Name.ToLower().Contains(input.Search.ToLower()))
				.OrderByDescending(d => d.CreationTime);

			var Count = query.Count();
			
			if(input.Sorting.IsNullOrWhiteSpace())
			{
				input.Sorting = "CreationTime DESC";
			}

			var items = await query.PageBy(input).OrderBy(input.Sorting)
				.Select(x => new DistributorsListDto
				{
					Id = x.Id,
					Name = x.Name,
					PhoneNumber = x.PhoneNumber,
					Email = x.Email,
					CreationTime = x.CreationTime,
				})
				.ToListAsync();
			return new PagedResultDto<DistributorsListDto>(Count, items);
		}
		// Get An Distributor
		public async Task<DistributorsListDto> GetAnDistributor(int distributorId)
		{
			var existingDistributor = await _repositoryDistributors.FirstOrDefaultAsync(x => x.Id == distributorId);
			var item = new DistributorsListDto
			{
				Id = distributorId,
				Name = existingDistributor.Name,
				PhoneNumber = existingDistributor.PhoneNumber,
				Email = existingDistributor.Email,
				CreationTime= existingDistributor.CreationTime,
			};
			return item;
		}

		// Update
		public async Task<Distributors> Update(UpdateDistributorInput input)
		{
			var existingDistributor = await _repositoryDistributors.FirstOrDefaultAsync(x => x.Id ==  input.Id);
			existingDistributor.Name = input.Name;
			existingDistributor.PhoneNumber = input.PhoneNumber;
			existingDistributor.Email = input.Email;
			await _repositoryDistributors.UpdateAsync(existingDistributor);
			return existingDistributor;
		}

		// Delete
		public async Task Delete(int distributorId)
		{
			await _repositoryDistributors.DeleteAsync(distributorId);
		} 
	}
}
