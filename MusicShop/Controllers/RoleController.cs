using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.ViewModels;

namespace MusicShop.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        // GET: Role
        public ActionResult Index()
        {
            IEnumerable<RoleViewModel> model = _roleManager.Roles.Select(r => new RoleViewModel()
            {
                Id = r.Id,
                Name = r.Name
            });
            return View(model);
        }

        // GET: Role/Details/5
        public ActionResult Details(string Name)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _roleManager.CreateAsync(new IdentityRole() { Name = model.Name });

                    if (result.Succeeded)
                    {

                        return RedirectToAction(nameof(Index));
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Edit(string Name)
        {
            var role = await _roleManager.FindByNameAsync(Name);


            return View(new RoleViewModel() { Id = role.Id, Name = role.Name });
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            try
            {
                if (await _roleManager.RoleExistsAsync(model.Name))
                {
                    ModelState.AddModelError("", "Role name already exists");
                    return View(model);

                }
                else
                {
                    var role = await _roleManager.FindByIdAsync(model.Id);
                    role.Name = model.Name;
                    role.NormalizedName = model.Name.ToUpper();

                    var result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Role update failed");
                        return View(model);
                    }
                }




            }
            catch
            {
                return View(model);
            }
        }

        // GET: Role/Delete/5
        public async Task<ActionResult> Delete(string Name)
        {

            if (!await _roleManager.RoleExistsAsync(Name))
            {

                ModelState.AddModelError("", "Role with that name doesn't exist");
                return RedirectToAction(nameof(Index));

            }
            else
            {

                var role = await _roleManager.FindByNameAsync(Name);
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

            }



            ModelState.AddModelError("", "Deletion failed");
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}