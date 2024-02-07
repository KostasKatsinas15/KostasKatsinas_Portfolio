using System.Text.RegularExpressions;
using Newtonsoft.Json;
using KostasKatsinas.Portfolio.Models;

namespace KostasKatsinas.Portfolio.Services
{
    public class CarouselImageService
    {
        private readonly IWebHostEnvironment _env;

        public CarouselImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void UpdateImageDatabase()
        {

            var imageDirectory = Path.Combine(_env.WebRootPath, "images");
            var imageFiles = Directory.GetFiles(imageDirectory).Select(Path.GetFileName);

            var imagesList = new List<ImageInfo>();

            foreach (var imageFile in imageFiles)
            {

                var imgName = imageFile;
                var imgPath = "images/" + imgName;

                int? imgNumber = null;
                var match = Regex.Match(imgName, @"\d+");
                if (match.Success)
                {
                    imgNumber = int.Parse(match.Value);
                }

                var imgAlt = "Image " + imgNumber;

                imagesList.Add(item: new ImageInfo { ImgName = imgName, ImgPath = imgPath, ImgNumber = imgNumber?.ToString(), ImgAlt = imgAlt });

            }

            var filePath = Path.Combine(_env.WebRootPath, "data/carouselImages.json");
            var jsonData = JsonConvert.SerializeObject(imagesList, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(filePath, jsonData);

        }
    }
}