using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTerritoriosJW.Core.Models;
using GerenciamentoTerritoriosJW.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTerritoriosJW.Controllers
{
    public class DirectionsController : Controller
    {
        private IDirectionRepository directionRepository;

        public DirectionsController(IDirectionRepository directionRepository)
        {
            this.directionRepository = directionRepository;

        }
        // GET: Directions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Directions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Directions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directions/Create
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

        // GET: Directions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Directions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Directions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Direction/Delete/5
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