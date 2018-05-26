using PiwaBackend.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Services.Interfaces
{
	public interface IBreweryService
	{
		ServiceResult<int> CreateBrewery(CreateBreweryDTO brewery);
		//ServiceResult<BreweryDTO[]> GetAllBreweries();
		ServiceResult<BreweryDTO> GetBreweryById(int breweryId);
		ServiceResult<BreweryDTO[]> SearchBreweries(string searchQuery);
	}
}
