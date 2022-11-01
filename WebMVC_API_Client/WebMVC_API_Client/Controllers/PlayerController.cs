using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC_API_Client.Data;
using WebMVC_API_Client.Models;
using WebMVC_API_Client.Services;
using WebMVC_API_Client.Services.Interfaces;
using Player = WebMVC_API_Client.Services.Player;

namespace WebMVC_API_Client.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerService _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7117/api/Players";

        public PlayerController(IPlayerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Ashley's Team API");
        }

        // GET: VideoGame/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var player = await _service.FindOne(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StudioId,MainCharacterId")] Player player, HttpClient id)
        {
            id = null;
            var resultPost = await client.PostAsync<Player>(requestUri, player, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _service.FindOne(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: VideoGame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Number, Position, Line, Name")] Player player)
        {
            if (id != Player.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Player>(requestUri + player.Id.ToString(), player, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var player = await _service.FindOne(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: VideoGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}
