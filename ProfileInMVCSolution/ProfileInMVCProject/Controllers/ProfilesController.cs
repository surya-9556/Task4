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
    public class ProfilesController : Controller
    {
        private IRepo<Profile> _repo;
        private ILogger<ProfileController> _Logger;

        public ProfilesController(IRepo<Profile> repo, ILogger<ProfileController> logger)
        {
            _repo = repo;
            _Logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Profile> P = _repo.GetAll().ToList();
            return View(P);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Profile P)
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Profile P = _repo.Get(id);
            return View(P);
        }
        [HttpPost]
        public IActionResult edit(int id, Profile P)
        {
            try
            {
                _repo.Update(id, P);
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Profile p = _repo.Get(id);
            return View(p);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Profile p = _repo.Get(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Delete(Profile p)
        {
            try
            {
                _repo.Delete(p);
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
