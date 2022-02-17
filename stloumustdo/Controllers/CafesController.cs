#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stloumustdo.Data;
using stloumustdo.Models;
using stloumustdo.POCO;

namespace stloumustdo.Controllers
{
    public class CafesController : Controller
    {
        private readonly stloumustdoContext _context;

        public CafesController(stloumustdoContext context)
        {
            _context = context;
        }

        private bool UserExists(string email)
        {
            return _context.UserProfileViewModel.Any(e => e.EmailAddress == email);
        }

        [Authorize]
        public async Task<IActionResult> Add(int? id)
        {
            

                var cafe = await _context.Cafes
                    .FirstOrDefaultAsync(m => m.Id == id);

                var tempUserEmail = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

                var thisuser = await _context.UserProfileViewModel.FirstOrDefaultAsync(m => m.EmailAddress == tempUserEmail);
                if (thisuser == null)
                {
                    return RedirectToAction("Profile", "Account");
                }

            try
            {
                var thisUsersBucketList = await _context.BucketList.FirstOrDefaultAsync(c => c.BucketId == thisuser.BucketId);
                thisUsersBucketList.Cafes.Add(cafe);

                //TODO: Check if Cafe is already on the list and dont let it get added again

                await _context.SaveChangesAsync();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

                return RedirectToAction(nameof(Index));
            
        }

        // GET: Cafes
        public async Task<IActionResult> Index()
        {
            var email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value.ToString();


            if (UserExists(email))
            {   var response = new UserCafeLists();
                response.HasCafe = new List<bool>();
                response.Cafes = await _context.Cafes.ToListAsync();

                var userFinder = new UserFinder();

                var response2 = await userFinder.ReturnUserProfileAsync(email, _context, User);
                var userCafeList = response2.BucketList.Cafes;



                foreach (var cafe in response.Cafes)
                {
                    var isMatched = false;
                    foreach (var userCafe in userCafeList)
                    {
                        if (cafe.CafeName == userCafe.CafeName)
                        {
                            isMatched = true;
                            //response.HasCafe.Add(true);
                        }
                    }
                    response.HasCafe.Add(isMatched);
                    //TODO: this is the most inefficient way. How do I improve this?? 
                }

                return View(response);
            }
            else
            {
                var response = new UserCafeLists();
                response.Cafes = await _context.Cafes.ToListAsync();
                response.HasCafe = new List<bool>();
                foreach(var cafe in response.Cafes)
                {
                    response.HasCafe.Add(false);
                }
                return View(response);
            }
        }

        // GET: Cafes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafe == null)
            {
                return NotFound();
            }

            return View(cafe);
        }

        // GET: Cafes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cafes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CafeName,Neighborhood,WebsiteUrl,Address")] Cafe cafe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafe);
        }

        // GET: Cafes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafes.FindAsync(id);
            if (cafe == null)
            {
                return NotFound();
            }
            return View(cafe);
        }

        // POST: Cafes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CafeName,Neighborhood,WebsiteUrl,Address")] Cafe cafe)
        {
            if (id != cafe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeExists(cafe.Id))
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
            return View(cafe);
        }

        // GET: Cafes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafe = await _context.Cafes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cafe == null)
            {
                return NotFound();
            }

            return View(cafe);
        }

        // POST: Cafes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafe = await _context.Cafes.FindAsync(id);
            _context.Cafes.Remove(cafe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeExists(int id)
        {
            return _context.Cafes.Any(e => e.Id == id);
        }
    }
}
