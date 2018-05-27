using AutoMapper;
using PiwaBackend.Data.DTOs;
using PiwaBackend.Data.Models;
using PiwaBackend.Repository.Interfaces;
using PiwaBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PiwaBackend.Services.Services
{
	public class BreweryService : IBreweryService
	{
		private readonly IRepository<Brewery> _breweryRepostiory;
		private readonly IImageService _imageService;
		private readonly IMapper _mapper;

		public BreweryService(IRepository<Brewery> breweryRepostiory, IImageService imageService, IMapper mapper)
		{
			_breweryRepostiory = breweryRepostiory;
			_imageService = imageService;
			_mapper = mapper;
		}

		public ServiceResult<int> CreateBrewery(CreateBreweryDTO brewery)
		{
			var newBrewery = _mapper.Map<Brewery>(brewery);
			_breweryRepostiory.Insert(newBrewery);
			if (brewery.Image == null)
			{
				return new ServiceResult<int>(newBrewery.Id);
			}
			var imageSaveResult = _imageService.SaveImage(newBrewery.Id, brewery.Image, Path.Combine("images","breweries"));
			if (imageSaveResult.IsError)
			{
				return new ServiceResult<int>("Failed to save the image");
			}
			newBrewery.ImagePath = imageSaveResult.SuccessResult; //zapis sciezki do pliku obrazka w bazie
			_breweryRepostiory.Update(newBrewery);
			return new ServiceResult<int>(newBrewery.Id);
		}

		public ServiceResult<BreweryDTO[]> GetAllBreweries()
		{
			var breweries = _breweryRepostiory.GetAll();
			var mappedBreweries = _mapper.Map<BreweryDTO[]>(breweries);
			foreach (var brewery in mappedBreweries)
			{
				if (brewery.ImagePath != null)
				{
					var imageResult = _imageService.GetImage(brewery.ImagePath);
					if (!imageResult.IsError)
					{
						brewery.Image = imageResult.SuccessResult;
					}
				}
			}
			return new ServiceResult<BreweryDTO[]>(mappedBreweries);
		}

		public ServiceResult<BreweryDTO> GetBreweryById(int breweryId)
		{
			var brewery = _breweryRepostiory.GetBy(b => b.Id == breweryId);
			if (brewery == null)
			{
				return new ServiceResult<BreweryDTO>("Brewery doesn't exist");
			}
			var mappedBrewery = _mapper.Map<BreweryDTO>(brewery);
			if (mappedBrewery.ImagePath != null)
			{
				var imageResult = _imageService.GetImage(mappedBrewery.ImagePath);
				if (!imageResult.IsError)
					mappedBrewery.Image = imageResult.SuccessResult;
			}
			return new ServiceResult<BreweryDTO>(mappedBrewery);
		}

		public ServiceResult<BreweryDTO[]> SearchBreweries(SearchBreweryDTO searchData)
		{
			var matchingBreweries = _breweryRepostiory.GetAllBy(b => MatchesSearch(b, searchData));
			var mappedBreweries = _mapper.Map<BreweryDTO[]>(matchingBreweries);
			foreach (var brewery in mappedBreweries)
			{
				if (brewery.ImagePath != null)
				{
					var imageResult = _imageService.GetImage(brewery.ImagePath);
					if (!imageResult.IsError)
					{
						brewery.Image = imageResult.SuccessResult;
					}
				}
			}
			return new ServiceResult<BreweryDTO[]>(mappedBreweries);
		}
		private bool MatchesSearch(Brewery brewery, SearchBreweryDTO searchData)
		{
			if (!String.IsNullOrWhiteSpace(searchData.Name))
			{
				if (!brewery.Name.ToLower().Contains(searchData.Name.ToLower()))
				{
					return false;
				}

			}
			return ((searchData.Type != null && brewery.Type != searchData.Type) ||
				(searchData.Country != null && brewery.Country != searchData.Country) ||
				brewery.YearEst < searchData.YearEstMin ||
				brewery.YearEst > searchData.YearEstMax) ? false : true;
		}
	}
}
