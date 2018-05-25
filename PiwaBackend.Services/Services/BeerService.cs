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
			var newBeer = new Beer {Name = beer.Name, Style = beer.Style, Alcohol = beer.Alcohol, IBU = beer.IBU, Blg = beer.Blg, Description = beer.Description};
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
			newBeer.ImagePath = imageSaveResult.SuccessResult;
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
			return new ServiceResult<BeerDTO>(mappedBeer);
		}
	}
}
