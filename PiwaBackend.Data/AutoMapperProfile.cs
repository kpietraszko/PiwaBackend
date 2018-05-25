using AutoMapper;
using PiwaBackend.Data.DTOs;
using PiwaBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Data
{
	public class AutoMapperProfile :Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CreateBeerDTO, Beer>();

			CreateMap<BeerDTO, Beer>();

			CreateMap<Beer, BeerDTO>();
		}
	}
}
