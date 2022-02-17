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
    public class StatewideOutdoorsController : Controller
    {
        private readonly stloumustdoContext _context;

        public StatewideOutdoorsController(stloumustdoContext context)
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
            var outdoor = await _context.StatewideOutdoors
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
                thisUsersBucketList.Outdoors.Add(outdoor);

                //TODO: Check if outdoor is already on the list and dont let it get added again

                await _context.SaveChangesAsync();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: StatewideOutdoors
        public async Task<IActionResult> Index()
        {

            var email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value.ToString();


            if (UserExists(email))
            {
                var response = new UserOutdoorList();
                response.HasOutdoorItem = new List<bool>();
                response.Outdoors = await _context.StatewideOutdoors.ToListAsync();

                var userFinder = new UserFinder();

                var response2 = await userFinder.ReturnUserProfileAsync(email, _context, User);
                var userOutdoorList = response2.BucketList.Outdoors;



                foreach (var outdooritem in response.Outdoors)
                {
                    var isMatched = false;
                    foreach (var userOutdoorItem in userOutdoorList)
                    {
                        if (outdooritem.OutdoorName == userOutdoorItem.OutdoorName)
                        {
                            isMatched = true;
                        }
                    }
                    response.HasOutdoorItem.Add(isMatched);
                    //TODO: this is the most inefficient way. How do I improve this?? 
                }

                return View(response);
            }
            else
            {
                var response = new UserOutdoorList();
                response.Outdoors = await _context.StatewideOutdoors.ToListAsync();
                response.HasOutdoorItem = new List<bool>();
                foreach (var outdoorItem in response.Outdoors)
                {
                    response.HasOutdoorItem.Add(false);
                }
                return View(response);
            }

        }

        // GET: StatewideOutdoors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statewideOutdoors = await _context.StatewideOutdoors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statewideOutdoors == null)
            {
                return NotFound();
            }

            return View(statewideOutdoors);
        }

        // GET: StatewideOutdoors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatewideOutdoors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OutdoorName,DistanceFromSTL,OutdoorUrl,Address")] StatewideOutdoors statewideOutdoors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statewideOutdoors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statewideOutdoors);
        }

        // GET: StatewideOutdoors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statewideOutdoors = await _context.StatewideOutdoors.FindAsync(id);
            if (statewideOutdoors == null)
            {
                return NotFound();
            }
            return View(statewideOutdoors);
        }

        // POST: StatewideOutdoors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OutdoorName,DistanceFromSTL,OutdoorUrl,Address")] StatewideOutdoors statewideOutdoors)
        {
            if (id != statewideOutdoors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statewideOutdoors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatewideOutdoorsExists(statewideOutdoors.Id))
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
            return View(statewideOutdoors);
        }

        // GET: StatewideOutdoors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statewideOutdoors = await _context.StatewideOutdoors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statewideOutdoors == null)
            {
                return NotFound();
            }

            return View(statewideOutdoors);
        }

        // POST: StatewideOutdoors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statewideOutdoors = await _context.StatewideOutdoors.FindAsync(id);
            _context.StatewideOutdoors.Remove(statewideOutdoors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatewideOutdoorsExists(int id)
        {
            return _context.StatewideOutdoors.Any(e => e.Id == id);
        }
    }
}
