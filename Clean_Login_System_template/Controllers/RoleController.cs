using Clean_Login_System_template.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Clean_Login_System_template.Models.ApplicationUser;

namespace Clean_Login_System_template.Controllers
{
    public class RoleController : Controller
    {

        private ApplicationRoleManager _roleManager;

        public RoleController()
        {

        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> model = new List<RoleViewModel>();

            foreach (var role in RoleManager.Roles)
            {
                model.Add(new RoleViewModel(role));
            };
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel createModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole()
                {
                    Name = createModel.Name
                };
                await RoleManager.CreateAsync(role);
                return RedirectToAction("Index");

            }
            return View();

        }

        public async Task<ActionResult> Edit(string Id)
        {
            //validation
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var searchRole = await RoleManager.FindByIdAsync(Id);

            //validation
            if (searchRole == null)
            {
                return HttpNotFound();
            }

            var model = new RoleViewModel()
            {
                Id = searchRole.Id,
                Name = searchRole.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole()
                {
                    Id = editViewModel.Id,
                    Name = editViewModel.Name,
                };
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<ActionResult> Detail(string Id)
        {
            //validation
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var searchRole = await RoleManager.FindByIdAsync(Id);

            //validation
            if (searchRole == null)
            {
                return HttpNotFound();
            }

            var model = new RoleViewModel()
            {
                Id = searchRole.Id,
                Name = searchRole.Name
            };

            return View(model);
        }


        public async Task<ActionResult> Delete(string Id)
        {
            //validation
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var searchRole = await RoleManager.FindByIdAsync(Id);

            //validation
            if (searchRole == null)
            {
                return HttpNotFound();
            }

            var model = new RoleViewModel()
            {
                Id = searchRole.Id,
                Name = searchRole.Name
            };

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCofirmed(string Id)
        {
            var searchRole = await RoleManager.FindByIdAsync(Id);
            await RoleManager.DeleteAsync(searchRole);
            return RedirectToAction("Index");
        }

    }
}