using Nap.Demo.WebMVC.Models;
using Nap.Demo.WebMVC.ViewModels;
using Nap.Demo.WebMVC.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Nap.Demo.WebMVC.Controllers
{
    public class UserAccountController : Controller
    {
        private NapDemoService nds = new NapDemoService();

        private UserAccountViewModel fromFormCollection(FormCollection c)
        {
            UserAccountViewModel vm = new UserAccountViewModel();
            int id;
            vm.Id = (int.TryParse(c["Id"], out id)) ? id : -1; // should be a public const from UserAccount class - not a literal here.
            vm.Name = c["Name"];
            vm.Address = c["Address"];
            vm.Postal = c["Postal"];
            vm.Email = c["Email"];
            return vm;
        }

        // GET: UserAccount
        public ActionResult Index()
        {
            List<UserAccountViewModel> viewModels = new List<UserAccountViewModel>();

            List<UserAccount> models = nds.GetAll();
            foreach (UserAccount m in models)
            {
                viewModels.Add(new UserAccountViewModel(m));
            }

            return View(viewModels);
        }

        // GET: UserAccount/Details/5
        public ActionResult Details(int id)
        {
            UserAccountViewModel vm = null;

            UserAccount model = nds.GetUserAccount(id);
            vm = new UserAccountViewModel(model);

            return View(vm);
        }

        // GET: UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // FYI in a non-demo scenario, DataAnnotations could/would be used in conjunction with ModeState.IsValid here.

                UserAccountViewModel vm = fromFormCollection(collection);
                UserAccount model = new UserAccount(vm.Name, vm.Address, vm.Postal, vm.Email);
                nds.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAccount/Edit/5
        public ActionResult Edit(int id)
        {
            UserAccount model = nds.GetUserAccount(id);
            UserAccountViewModel vm = new UserAccountViewModel(model);
            return View(vm);
        }

        // POST: UserAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                UserAccountViewModel vm = fromFormCollection(collection);
                UserAccount model = new UserAccount(vm.Id, vm.Name, vm.Address, vm.Postal, vm.Email);
                bool success = nds.Update(model);
                // Note sure what I would do here with the success value - it's been setup so that NapDemoService throws exceptions.
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAccount/Delete/5
        public ActionResult Delete(int id)
        {
            UserAccount model = nds.GetUserAccount(id);
            UserAccountViewModel vm = new UserAccountViewModel(model);
            return View(vm);
        }

        // POST: UserAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                nds.Remove(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
