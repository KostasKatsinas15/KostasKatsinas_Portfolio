using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using KostasKatsinas.Portfolio.Models;

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
            var filePath = Path.Combine(_env.WebRootPath, "data/carouselImages.json");
            var jsonData = System.IO.File.ReadAllText(filePath);
            Images = JsonConvert.DeserializeObject<List<ImageInfo>>(jsonData) ?? new List<ImageInfo>();
        }
	}

}
