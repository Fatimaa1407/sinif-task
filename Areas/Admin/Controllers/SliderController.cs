using Microsoft.AspNetCore.Mvc;
using WebApplication4.DAL;
using WebApplication4.Models;
using WebApplication4.Utilities;

namespace WebApplication4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Slider slider)
        {
            if(slider.ImageFile==null)
            {
                ModelState.AddModelError("ImageFile", "image lazimdir");
                return View();
            }
            if (!slider.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File must be an image");
                return View();
            }
            if (!(slider.ImageFile.Length < 2 * 1024 * 1024))
            {
                ModelState.AddModelError("ImageFile", "File size must be maximum 2MB");
                return View();
            }

            slider.ImageUrl = slider.ImageFile.SaveImage(_env, "upload/sliders");
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Sliders.Add(slider);

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            return View(slider);
        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Slider oldSlider = _context.Sliders.Find(slider.Id);
            oldSlider.Title = slider.Title;
            oldSlider.Desc = slider.Desc;
            oldSlider.ImageUrl = slider.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            slider.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Restore(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            slider.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }

}
        

  



