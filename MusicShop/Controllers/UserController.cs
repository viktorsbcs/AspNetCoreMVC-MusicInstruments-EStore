using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models.Interfaces;
using MusicShop.Models.ViewModels;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace MusicShop.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller

    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProductRepository _productRepository;

        public UserController(IProductRepository productRepository, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {

            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }
        // GET: User
        public async Task<ActionResult> Index()
        {

            var model = _userManager.Users.Select(u => new UserViewModel() { Id = u.Id, Name = u.UserName, Email = u.Email });
            foreach (var user in model)
            {
                var identityUser = await _userManager.FindByIdAsync(user.Id);
            }

            return View(model);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(string name)
        {
            if (name == null) name = TempData["userName"].ToString();

            var userFound = await _userManager.FindByNameAsync(name);
            if(userFound != null)
            {
                var model = new UserViewModel()
                {
                    Id = userFound.Id,
                    Email = userFound.Email,
                    PhoneNumber = userFound.PhoneNumber
                };

                return View(model);
            }

            ModelState.AddModelError("", "User not found");
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

        [HttpGet]
        public ActionResult Profile()
        {

            var user = _userManager.Users.First(u=>u.UserName == User.Identity.Name);
            if (user != null)
            {
                var model = new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    PhoneNumber = user.PhoneNumber

                };

                return View(model);

            }
            else
            {
                ModelState.AddModelError("", "Profile not found");
                return View();
            }



        }

        [HttpPost]
        public async Task<ActionResult> Profile(UserViewModel model)
        {
            if (ModelState.IsValid)
            {

                var userFound = await _userManager.FindByIdAsync(model.Id);
                var userTemp = userFound;
                if (userFound != null)
                {
                    //userFound.UserName = model.Name;
                    userFound.Email = model.Email;
                    userFound.NormalizedEmail = model.Email.ToUpper();
                    userFound.NormalizedUserName = model.Email.ToUpper();
                    userFound.UserName = model.Email;
                    userFound.PhoneNumber = model.PhoneNumber;

                    

                    var updateResult = await _userManager.UpdateAsync(userFound);

                    if (updateResult.Succeeded)
                    {
                        //Logging out user and logging back in to refresh identity user with new username/email
                        await _signInManager.RefreshSignInAsync(userTemp);
                        TempData["userName"] = userFound.UserName;
                        return RedirectToAction("Details", "User");
                    }
                }

                ModelState.AddModelError("", "User not found");

            }
            else
            {
                ModelState.AddModelError("", "Model state invalid");
                return View(model);
            }

            return View();

        }

        public async Task<ActionResult> ChangePassword()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                var model = new ChangePasswordViewModel()
                {
                    UserId = user.Id,
                };

                return View(model);

            } else
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword );

                    if (result.Succeeded)
                    {
                        TempData["PasswordChangeSuccess"] = "true";
                        return View();

                    } else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                            return View(model);
                        }

                    }
                } else
                {
                    ModelState.AddModelError("", "User not found");
                    return View(model);
                }



            } else
            {

                ModelState.AddModelError("", "Error updating passsword, try again");
                return View(model);
            }

            return View(model);
        }

    }
}