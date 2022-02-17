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
    public class LocalAttractionsController : Controller
    {
        private readonly stloumustdoContext _context;

        public LocalAttractionsController(stloumustdoContext context)
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
            var attraction = await _context.LocalAttractions
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
                thisUsersBucketList.Attractions.Add(attraction);

                //TODO: Check if Cafe is already on the list and dont let it get added again

                await _context.SaveChangesAsync();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: LocalAttractions
        public async Task<IActionResult> Index()
        {
            var email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value.ToString();


            if (UserExists(email))
            {
                var response = new UserAttractionList();
                response.HasAttraction = new List<bool>();
                response.Attractions = await _context.LocalAttractions.ToListAsync();

                var userFinder = new UserFinder();

                var response2 = await userFinder.ReturnUserProfileAsync(email, _context, User);
                var userAttractionList = response2.BucketList.Attractions;



                foreach (var attraction in response.Attractions)
                {
                    var isMatched = false;
                    foreach (var userAttraction in userAttractionList)
                    {
                        if (attraction.AttractionName == userAttraction.AttractionName)
                        {
                            isMatched = true;
                        }
                    }
                    response.HasAttraction.Add(isMatched);
                    //TODO: this is the most inefficient way. How do I improve this?? 
                }

                return View(response);
            }
            else
            {
                var response = new UserAttractionList();
                response.Attractions = await _context.LocalAttractions.ToListAsync();
                response.HasAttraction = new List<bool>();
                foreach (var attraction in response.Attractions)
                {
                    response.HasAttraction.Add(false);
                }
                return View(response);
            }


        }

        // GET: LocalAttractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localAttraction = await _context.LocalAttractions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localAttraction == null)
            {
                return NotFound();
            }

            return View(localAttraction);
        }

        // GET: LocalAttractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalAttractions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttractionName,Neighborhood,AttractionUrl,Address")] LocalAttraction localAttraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localAttraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localAttraction);
        }

        // GET: LocalAttractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localAttraction = await _context.LocalAttractions.FindAsync(id);
            if (localAttraction == null)
            {
                return NotFound();
            }
            return View(localAttraction);
        }

        // POST: LocalAttractions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AttractionName,Neighborhood,AttractionUrl,Address")] LocalAttraction localAttraction)
        {
            if (id != localAttraction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localAttraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalAttractionExists(localAttraction.Id))
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
            return View(localAttraction);
        }

        // GET: LocalAttractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localAttraction = await _context.LocalAttractions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localAttraction == null)
            {
                return NotFound();
            }

            return View(localAttraction);
        }

        // POST: LocalAttractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localAttraction = await _context.LocalAttractions.FindAsync(id);
            _context.LocalAttractions.Remove(localAttraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalAttractionExists(int id)
        {
            return _context.LocalAttractions.Any(e => e.Id == id);
        }
    }
}
