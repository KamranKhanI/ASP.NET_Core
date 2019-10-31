using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Iamge_WebP.Models;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Iamge_WebP.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        private DbContexte db;

        public ItemController(IHostingEnvironment _environment  ,DbContexte _db)
        {
            this.hostingEnvironment = _environment;
            this.db = _db;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Item items, IFormFile image)
        {
            // Check if valid image type (can be extended with more rigorous checks)
            if (image == null || image.Length < 1)
            {
                return View();
            }



            string[] allowedImageTypes = new string[] { "image/jpeg", "image/png" };
            if (!allowedImageTypes.Contains(image.ContentType.ToLower()))
            {
                return View();
            }

            // Prepare paths for saving images
            string imagesPath = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/images");
            string webPFileName = Path.GetFileNameWithoutExtension(image.FileName) + ".webp";            
            string webPImagePath = Path.Combine(imagesPath, webPFileName);



            items.ImagePath ="~/Images/"+ webPFileName;

            if (ModelState.IsValid)
            {
                FileStream webPFileStream = new FileStream(webPImagePath, FileMode.Create);

                ImageFactory imageFactory = new ImageFactory(preserveExifData: false);

                imageFactory.Load(image.OpenReadStream())
                    .Format(new WebPFormat())
                    .Quality(50)
                    .Save(webPFileStream);



                db.Items.Add(items);
                db.SaveChanges();
            }


            return RedirectToActionPermanent("Index");

        }


        public IActionResult Index()
        {



            return View(db.Items.ToList());
        }

      
      
    }
}