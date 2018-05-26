using PiwaBackend.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Services.Interfaces
{
	public interface IBeerService
	{
		ServiceResult<int> CreateBeer(CreateBeerDTO beer);
		ServiceResult<BeerDTO[]> GetAllBeers();
		ServiceResult<BeerDTO> GetBeerById(int beerId);
		ServiceResult<BeerDTO[]> SearchBeers(SearchBeerDTO searchData);
	}
}
