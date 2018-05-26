using AutoMapper;
using PiwaBackend.Data.DTOs;
using PiwaBackend.Data.Models;
using PiwaBackend.Repository.Interfaces;
using PiwaBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace PiwaBackend.Services.Services
{
	public class BeerService : IBeerService
	{
		private readonly IRepository<Beer> _beerRepostiory;
		private readonly IImageService _imageService;
		private readonly IMapper _mapper;

		public BeerService(IRepository<Beer> beerRepostiory, IImageService imageService, IMapper mapper)
		{
			_beerRepostiory = beerRepostiory;
			_imageService = imageService;
			_mapper = mapper;
		}
		public ServiceResult<int> CreateBeer(CreateBeerDTO beer)
		{
			var newBeer = _mapper.Map<Beer>(beer);
			_beerRepostiory.Insert(newBeer);
			if (beer.Image == null)
			{
				return new ServiceResult<int>(newBeer.Id);
			}
			var imageSaveResult = _imageService.SaveImage(newBeer.Id, beer.Image, Path.Combine("images","beers"));
			if (imageSaveResult.IsError)
			{
				return new ServiceResult<int>("Failed to save the image");
			}
			newBeer.ImagePath = imageSaveResult.SuccessResult; //zapis sciezki do pliku obrazka w bazie
			_beerRepostiory.Update(newBeer);
			return new ServiceResult<int>(newBeer.Id);
		}

		public ServiceResult<BeerDTO[]> GetAllBeers()
		{
			var allBeers = _beerRepostiory.GetAll();
			var allBeersMapped = _mapper.Map<BeerDTO[]>(allBeers);
			//foreach wczytac zdjecie
			foreach (var beer in allBeersMapped)
			{
				if (beer.ImagePath != null)
				{
					var imageResult = _imageService.GetImage(beer.ImagePath);
					if (!imageResult.IsError)
						beer.Image = imageResult.SuccessResult;
				}
			}
			return new ServiceResult<BeerDTO[]>(allBeersMapped);
		}

		public ServiceResult<BeerDTO> GetBeerById(int beerId)
		{
			var beer = _beerRepostiory.GetBy(b => b.Id == beerId);
			if (beer == null)
			{
				return new ServiceResult<BeerDTO>("Beer doesn't exist");
			}
			var mappedBeer = _mapper.Map<BeerDTO>(beer);
			if (mappedBeer.ImagePath != null)
			{
				var imageResult = _imageService.GetImage(mappedBeer.ImagePath);
				if (!imageResult.IsError)
					mappedBeer.Image = imageResult.SuccessResult;
			}
			return new ServiceResult<BeerDTO>(mappedBeer);
		}

		public ServiceResult<BeerDTO[]> SearchBeers(SearchBeerDTO searchData)
		{
			var allBeersResult = GetAllBeers();
			if (allBeersResult.IsError)
			{
				return new ServiceResult<BeerDTO[]>("Error while getting beers");
			}
			var matchingBeers = allBeersResult.SuccessResult.Where(b => MatchesSearch(b, searchData));
			return new ServiceResult<BeerDTO[]>(matchingBeers.ToArray());
		}
		private bool MatchesSearch(BeerDTO beer, SearchBeerDTO searchData)
		{
			if (!String.IsNullOrWhiteSpace(searchData.Name))
			{
				if (!beer.Name.ToLower().Contains(searchData.Name.ToLower()))
				{
					return false;
				}
			}
			return (beer.Alcohol < searchData.AlcoholMin ||
					beer.Alcohol > searchData.AlcoholMax ||
					beer.Ibu < searchData.IbuMin ||
					beer.Ibu > searchData.IbuMax ||
					beer.Blg < searchData.BlgMin ||
					beer.Blg > searchData.BlgMax) ? false : true;
		}
	}
}
