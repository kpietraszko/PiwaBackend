using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PiwaBackend.Services.Interfaces;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PiwaBackend.Services.Services
{
	public class ImageService :IImageService
	{
		private readonly IConfiguration _config;
		private readonly IHostingEnvironment _hostingEnvironment;

		public ImageService(IConfiguration config, IHostingEnvironment hostingEnvironment)
		{
			_config = config;
			_hostingEnvironment = hostingEnvironment;
		}

		public ServiceResult<byte[]> GetImage(string path)
		{
			var absolutePath = Path.Combine(_hostingEnvironment.ContentRootPath, path);
			try
			{
				using (var stream = new FileStream(absolutePath, FileMode.Open, FileAccess.Read))
				{
					using (var ms = new MemoryStream())
					{
						stream.CopyTo(ms);
						return new ServiceResult<byte[]>(ms.ToArray());
					}
				}
			}
			catch (Exception e)
			{
				return new ServiceResult<byte[]>(e.Message);
			}
		}
		public ServiceResult<string> SaveImage(int id, IFormFile sentFile, string directory)
		{
			var contentRoot = _hostingEnvironment.ContentRootPath;
			var imageName = id.ToString() + ".png";
			var imageRelPath = Path.Combine(directory, imageName);
			var imagePath = Path.Combine(contentRoot, imageRelPath);

			try
			{
				using (var image = Image.Load(sentFile.OpenReadStream()))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
					using (var fileStream = new FileStream(imagePath, FileMode.Create))
					{
						image.SaveAsPng(fileStream);
					}
				}
				return new ServiceResult<string>(imageRelPath);
			}
			catch (Exception e)
			{
				return new ServiceResult<string>(e.Message);
			}

		}

	}
}
