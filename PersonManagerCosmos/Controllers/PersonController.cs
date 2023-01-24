using PersonManagerCosmos.dao;
using PersonManagerCosmos.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersonManagerCosmos.Controllers
{
    public class PersonController : Controller
    {
        private static readonly ICosmosDbService service = CosmosDbServiceProvider.CosmosDbService;
        // GET: Person
        public async Task<ActionResult> Index()
        {
            return View(await service.GetItemAsync("SELECT * FROM Person"));
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(string id)
        => await ShowPeople(id);

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.AddItemAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<ActionResult> Edit(string id)
        => await ShowPeople(id);

        private async Task<ActionResult> ShowPeople(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var item = await service.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateItemAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<ActionResult> Delete(string id)
        => await ShowPeople(id);

        // POST: Person/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Person person)
        {
            await service.DeleteItemAsync(person);
            return RedirectToAction("Index");
        }
    }
}