using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileInMVCProject.Models;
using ProfileInMVCProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileInMVCProject.Controllers
{
    public class ProfileController : Controller
    {
        private IRepo<Profile> _repo;
        private ILogger<ProfileController> _Logger;

        public ProfileController(IRepo<Profile> repo, ILogger<ProfileController> logger)
        {
            _repo = repo;
            _Logger = logger;
        }


        // GET: ProfileController
        public ActionResult Index()
        {
            List<Profile> P = _repo.GetAll().ToList();
            return View(P);
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profile P)
        {
            try
            {
                _repo.Add(P);
            }
            catch(Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return RedirectToAction("Index");
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
