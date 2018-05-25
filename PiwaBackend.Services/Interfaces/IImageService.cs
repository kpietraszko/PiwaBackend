using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Services.Interfaces
{
	public interface IImageService
	{
		ServiceResult<byte[]> GetImage(string path);
		ServiceResult<string> SaveImage(int id, IFormFile sentFile, string directory); //byte[] moze nie zadzialac
	}
}
