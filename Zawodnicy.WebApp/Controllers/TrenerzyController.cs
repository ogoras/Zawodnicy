﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;

namespace Zawodnicy.WebApp.Controllers
{
    public class TrenerzyController : Controller
    {
        public IConfiguration Configuration;

        public TrenerzyController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public ContentResult GetApiUrl()
        {
            var result = Configuration["RestApiUrl"];
            return Content(result);
        }
        private string CN()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }

        // GET: TrenerzyController
        public async Task<ActionResult> Index()
        {
            string _restpath = GetApiUrl().Content + CN();
            List<TrenerVM> trenerzyList = new List<TrenerVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trenerzyList = JsonConvert.DeserializeObject<List<TrenerVM>>(apiResponse);
                }
            }

            return View(trenerzyList);
        }

        // GET: TrenerzyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrenerzyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TrenerzyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrenerzyController/Edit/5
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

        // GET: TrenerzyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrenerzyController/Delete/5
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