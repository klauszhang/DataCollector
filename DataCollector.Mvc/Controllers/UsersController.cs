using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataCollector.Entities;
using DataCollector.DomainModel;

namespace DataCollector.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationUserManager _userManager;

        public UsersController()
        {
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult Index()
        {
            var userList = UserManager.Users.Where(u => u.Deleted == false);

            return View(userList);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            if (UserManager.FindByName(model.UserName) == null)
            {
                if (ModelState.IsValid)
                {
                    var newUser = new DCUser
                    {
                        UserName = model.UserName,
                        Email = model.Email
                    };
                    var result = await UserManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Users");
                    }
                    AddErrors(result);
                    return View();
                }
            }
            else if (UserManager.FindByName(model.UserName).Deleted)
            {
                ModelState.AddModelError("", "The user already exists, but is deleted, choose another user name or reactive the user. ");
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "The user already exists, choose another user name please. ");
                return View(model);
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var domainUser = UserManager.FindByIdAsync(id).Result;
            Mapper.CreateMap<DCUser, EditUserViewModel>();
            EditUserViewModel user = Mapper.Map<EditUserViewModel>(domainUser);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var domainUser = UserManager.FindById(model.Id);
                domainUser.UserName = model.UserName;
                domainUser.Email = model.Email;

                if (model.Password != null)
                {
                    UserManager.RemovePassword(model.Id);
                    UserManager.AddPassword(model.Id, model.Password);
                }

                var result = await UserManager.UpdateAsync(domainUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");
                }
                AddErrors(result);
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Unexpected error. ");
            }
            return View("Edit", model);
        }

        // GET: Users/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var domainUser = UserManager.FindById(id);
            if (domainUser == null)
            {
                return View("Error");
            }
            Mapper.CreateMap<DCUser, DeleteUserViewModel>();
            DeleteUserViewModel user = Mapper.Map<DeleteUserViewModel>(domainUser);
            ViewBag.Title = String.Format("Delete {0} ?", user.UserName);
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, DeleteUserViewModel model)
        {
            return await DeleteOrReactiveUser(id, model, DeleteOrReactive.Delete);
        }

        public ActionResult DeletedList()
        {
            var userList = UserManager.Users.Where(u => u.Deleted == true);
            return View(userList);
        }


        public ActionResult Reactive(string id)
        {
            var domainUser = UserManager.FindById(id);
            Mapper.CreateMap<DCUser, DeleteUserViewModel>();
            var user = Mapper.Map<DeleteUserViewModel>(domainUser);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reactive(string id, DeleteUserViewModel model)
        {
            return await DeleteOrReactiveUser(id, model, DeleteOrReactive.Reactive);
        }

        private async Task<ActionResult> DeleteOrReactiveUser(string id, DeleteUserViewModel model, DeleteOrReactive state)
        {
            IdentityResult result;
            var domainUser = await UserManager.FindByIdAsync(id);

            switch (state)
            {
                case DeleteOrReactive.Delete:
                    domainUser.Deleted = true;
                    break;
                case DeleteOrReactive.Reactive:
                    domainUser.Deleted = false;
                    break;
                default:
                    break;
            }
            result = await UserManager.UpdateAsync(domainUser);

            if (result.Succeeded)
                return RedirectToAction("Index");

            AddErrors(result);

            switch (state)
            {
                case DeleteOrReactive.Delete:
                    ModelState.AddModelError("", "you cannot reactive an active user");
                    break;
                case DeleteOrReactive.Reactive:
                    ModelState.AddModelError("", "The user have already deleted! ");
                    break;
                default:
                    break;
            }
            return View(model);
        }

        public ActionResult SearchForUser()
        {
            return PartialView("_SearchForUser");
        }

        public async Task<ActionResult> Search(SearchUserViewMode model)
        {
            if (model.UserName == null)
            {
                //ModelState.AddModelError("", "Please enter correct parameter.");
                return View("Error");
            }
            var user = await UserManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return View("Error");
            }
            return RedirectToAction("Edit", "Users", new { id = user.Id });
        }

        public ActionResult Lock(string id)
        {
            if (id == null)
            {
                return View("Error");
            }
            UserManager.ResetAccessFailedCount(id);
            UserManager.SetLockoutEndDate(id, DateTime.UtcNow.AddDays(2));
            return RedirectToAction("Index");
        }

        public ActionResult Unlock(string id)
        {
            if (id == null)
            {
                return View("Error");
            }
            UserManager.ResetAccessFailedCount(id);
            UserManager.SetLockoutEndDate(id, DateTime.UtcNow.AddDays(-2));
            return RedirectToAction("Index");
        }

        public ActionResult Detail(string id)
        {
            var domainUser = UserManager.FindById(id);
            //Mapper.CreateMap(DCUser, )

            return View(domainUser);
        }

        public async Task<ActionResult> SendConfirmEmail(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(id);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = id, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(id, "Confirm your account", "Please confirm your account" + user.UserName + " by clicking <a href=\"" + callbackUrl + "\">here</a>");
            return RedirectToAction("Index");
        }

        public JsonResult GetUserNamesForAutoComplete(string term)
        {
            DCUser[] users = String.IsNullOrWhiteSpace(term)
                ? null
                : UserManager.Users.Where(
                    au => au.UserName.StartsWith(term)).ToArray();

            return Json(users.Select(u => new
            {
                id = u.Id,
                value = u.UserName,
                label = String.Format("{0}", u.UserName)
            }), JsonRequestBehavior.AllowGet);

        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        enum DeleteOrReactive
        {
            Delete, Reactive
        }
    }

}
