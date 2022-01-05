using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;

namespace Zawodnicy.WebApp.Controllers
{
    [Authorize(Roles = "admin")]
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
            var tokenString = GenerateJSONWebToken();

            string _restpath = GetApiUrl().Content + CN();
            List<TrenerVM> trenerzyList = new List<TrenerVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trenerzyList = JsonConvert.DeserializeObject<List<TrenerVM>>(apiResponse);
                }
            }

            return View(trenerzyList);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pass123456789123456789"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Name", "Szymon"),
                new Claim(JwtRegisteredClaimNames.Email, "      "),
            };

            var token = new JwtSecurityToken(
                issuer: "kuss",
                audience: "kuss",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials,
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: TrenerzyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrenerzyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TrenerVM t)
        {
            string _restpath = GetApiUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string zawodnikJson = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(zawodnikJson, Encoding.UTF8, "application/json");

                    await httpClient.PostAsync($"{_restpath}", content);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TrenerzyController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            string _restpath = GetApiUrl().Content + CN();
            TrenerVM t = new TrenerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<TrenerVM>(apiResponse);
                }
            }

            return View(t);
        }

        // POST: TrenerzyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TrenerVM t)
        {
            string _restpath = GetApiUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string zawodnikJson = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(zawodnikJson, Encoding.UTF8, "application/json");

                    await httpClient.PutAsync($"{_restpath}/{t.Id}", content);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TrenerzyController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            string _restpath = GetApiUrl().Content + CN();
            TrenerVM t = new TrenerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<TrenerVM>(apiResponse);
                }
            }

            return View(t);
        }

        // POST: TrenerzyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            string _restpath = GetApiUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    await httpClient.DeleteAsync($"{_restpath}/{id}");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
