using KostasKatsinas.Portfolio.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CarouselImageController;

namespace KostasKatsinas.Portfolio.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IWebHostEnvironment _env;
		public List<ImageInfo> Images { get; set; }

		public IndexModel(IWebHostEnvironment env)
		{
			_env = env;
		}

		public void OnGet() 
		{
            var filePath = Path.Combine(_env.WebRootPath, "images/data/carouselImages.json");
            var jsonData = System.IO.File.ReadAllText(filePath);
            Images = JsonConvert.DeserializeObject<List<ImageInfo>>(jsonData) ?? new List<ImageInfo>();
        }
	}

}
