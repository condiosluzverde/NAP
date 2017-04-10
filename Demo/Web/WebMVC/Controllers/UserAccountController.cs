using Nap.Demo.WebMVC.Models;
using Nap.Demo.WebMVC.ViewModels;
using Nap.Demo.WebMVC.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nap.Demo.WebMVC.Controllers
{
    public class UserAccountController : Controller
    {
        private NapDemoService nds = new NapDemoService();

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

            return View();
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
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: UserAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: UserAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
