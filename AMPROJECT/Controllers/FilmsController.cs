using AMPROJECT.Data;
using AMPROJECT.Models;
//using AMPROJECT.Services;
using AMPROJECT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMPROJECT.Controllers
{

    public class FilmsController : Controller
    {
        private readonly MyDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment;

        public FilmsController(MyDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Films

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Films.ToListAsync());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }



        //[Authorize(Roles = "user,admin")]
        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmCreateViewModel model)
        {
        //    if (ModelState.IsValid)
        //    {
            string? uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Film film = new Film
            {
                Duration = model.Duration,
                Titre = model.Titre,
                Description = model.Description,
                Prix = model.Prix,
                Quantite = model.Quantite,
                PhotoPath = uniqueFileName
            };

            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = film.Id });

            //}
            //return View(model);
        }











        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Duration,Titre,Description,DateSortie,Prix,Quantite")] Film film)
        //{

        //if(film.Image !=null)
        //{
        //    string folder = "produits/cover";
        //    folder += Guid.NewGuid().ToString() + "_" + film.Image.FileName;
        //    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);

        //    film.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));   

        //}





        //if (ModelState.IsValid)
        //{


        //_context.Add(film);
        //await _context.SaveChangesAsync();
        //IFormFile file = Request.Form.Files["file"];
        //BufferedFileUploadLocalService service = new BufferedFileUploadLocalService();
        //await service.UploadFile(file);
        //return RedirectToAction(nameof(Index));


        //}
        //    return View(film);
        //}

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        //POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FilmCreateViewModel model)

        {
            Film Film = _context.Films.Find(id);


            if (id != Film.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{

            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }


            Film.Duration = model.Duration;
            Film.Titre = model.Titre;
            Film.Description = model.Description;
            Film.Prix = model.Prix;
            Film.Quantite = model.Quantite;
            Film.PhotoPath = uniqueFileName;





            try
            {
                _context.Update(Film);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(Film.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            return View(Film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Films == null)
            {
                return Problem("Entity set 'MyDbContext.Films'  is null.");
            }
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }






    }
}
