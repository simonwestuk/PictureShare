using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PictureShare.Data;
using PictureShare.Models;


namespace PictureShare.Views
{
    public class PicturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PicturesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Pictures
        public async Task<IActionResult> Index(string SearchBy)
        {

            var data = _context.Picture.Where(x => x.UserEmail == User.Identity.Name);

            if (!String.IsNullOrEmpty(SearchBy))
            {
                data = data.Where(x => x.Caption.Contains(SearchBy));
            }
         
            return View(await data.ToListAsync());
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureModel = await _context.Picture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pictureModel == null)
            {
                return NotFound();
            }

            return View(pictureModel);
        }

        // GET: Pictures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserEmail,ImagePath,Caption")] PictureModel pictureModel)
        {
            if (ModelState.IsValid)
            {
                var upload = Request.Form.Files[0];

                string ext = Path.GetExtension(upload.FileName);

                string root = _webHostEnvironment.WebRootPath;

                var webPath = $"/images/{User.Identity.Name.Replace("@",string.Empty).Replace(".", string.Empty).ToLower()}/";

                var path = $"{root}{webPath}";

                var fileName = $"{DateTime.Now.ToString("yymmssfff")}{ext}".ToLower();

                pictureModel.ImagePath = $"{path}{fileName}";

                Directory.CreateDirectory(path);

                using (var fileStream = new FileStream(pictureModel.ImagePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }

                pictureModel.UserEmail = User.Identity.Name;
                pictureModel.ImagePath = $"{webPath}{fileName}";
                pictureModel.Public = false;

                _context.Add(pictureModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pictureModel);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureModel = await _context.Picture.FindAsync(id);
            if (pictureModel == null)
            {
                return NotFound();
            }
            return View(pictureModel);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserEmail,ImagePath,Caption,Public")] PictureModel pictureModel)
        {
            if (id != pictureModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pictureModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureModelExists(pictureModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pictureModel);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureModel = await _context.Picture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pictureModel == null)
            {
                return NotFound();
            }

            return View(pictureModel);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pictureModel = await _context.Picture.FindAsync(id);
            _context.Picture.Remove(pictureModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureModelExists(int id)
        {
            return _context.Picture.Any(e => e.Id == id);
        }
    }
}
