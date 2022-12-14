using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMPROJECT.Data;
using AMPROJECT.Models;
using AMPROJECT.ViewModels;
using Microsoft.Extensions.Hosting.Internal;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Net;

namespace AMPROJECT.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsersController(MyDbContext context, IHostingEnvironment hostingEnvironment, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }




        //[HttpPost]
        //public IActionResult Create(UserCreateViewModel us)
        //{
        //    string stringFileName = UploadFile(us);
        //    var user = new User
        //    {
        //        Nom = us.Nom,
        //        Prenom = us.Prenom,
        //        Email = us.Email,
        //        Password = us.Password,
        //        PhotoPath = stringFileName
        //    };
        //    _context.Users.Add(user);
        //    //_context.SaveChanges();

        //        return RedirectToAction("Index");
        //}

        //private string UploadFile(UserCreateViewModel us)
        //{
        //    string? FileName = null;
        //    if(us.Photo !=null)
        //    {
        //        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
        //        FileName = Guid.NewGuid().ToString() + "-" + us.Photo.FileName;
        //        string filePath = Path.Combine(uploadDir, FileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            us.Photo.CopyTo(fileStream);
        //        }
        //    }
        //    return FileName;
        //}







        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,Password,Tel")] User user)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    _context.Add(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //    //}
        //    return View(user);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {

            //if (ModelState.IsValid)
            //{
                string? uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "-" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                User user = new User
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Email = model.Email,
                    Password = model.Password,
                    Tel = model.Tel,
                    PhotoPath = uniqueFileName
                };

                _context.Add(user);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = user.Id });
            //}
            //return View();
        }



        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,Password,Tel")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'MyDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.Id == id);
        }
    }
}
