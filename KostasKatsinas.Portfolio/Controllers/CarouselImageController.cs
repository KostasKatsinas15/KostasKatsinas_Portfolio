using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class CarouselImageController : Controller
{
    private readonly IWebHostEnvironment _env;

    public CarouselImageController(IWebHostEnvironment env) => _env = env;

    public void UpdateImageDatabase()
    {

        var imageDirectory = Path.Combine(_env.WebRootPath, "images");
        var imageFiles = Directory.GetFiles(imageDirectory).Select(Path.GetFileName);

        var imagesList = new List<ImageInfo>();

        foreach (var imageFile in imageFiles)
        {

            var imgName = imageFile;
            var imgPath = "~/images/" + imgName;

            int? imgNumber = null;
            var match = Regex.Match(imgName, @"\d+");
            if (match.Success)
            {
                imgNumber = int.Parse(match.Value);
            }

            var imgAlt = "Image " + imgNumber;

            imagesList.Add(item: new ImageInfo { ImgName = imgName, ImgPath = imgPath, ImgNumber = imgNumber?.ToString(), ImgAlt = imgAlt });

        }

        var filePath = Path.Combine(_env.WebRootPath, "images/data/carouselImages.json");
        var jsonData = JsonConvert.SerializeObject(imagesList, Newtonsoft.Json.Formatting.Indented);
        System.IO.File.WriteAllText(filePath, jsonData);

    }

    public class ImageInfo
    {
        public string ImgName { get; set; }
        public string ImgPath { get; set; }
        public string ImgNumber { get; set; }
        public string ImgAlt { get; set; }
    }
}