using LibrarieDemo.Data;
using LibrarieDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarieDemo.Controllers
{
    public class ProdusController : Controller
    {

        private readonly DbContextObiectConex _db;
        public ProdusController(DbContextObiectConex db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Produs> ProduseLista = _db.Produsele;
            return View(ProduseLista);
        }
        //Get Creare
        public IActionResult Creare()
        {
            IEnumerable<SelectListItem> CategorieLista = _db.Categoriile.Select(
                u=>new SelectListItem
                {
                    Text= u.Nume,
                    Value=u.Id.ToString()
                });
            ViewData["CategorieLista"] = CategorieLista;
            return View();
        }
        //Post Creare
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creare(Produs obiect)
        {
            if (ModelState.IsValid)
            {
                _db.Produsele.Add(obiect);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }
        //Get Editare
        public IActionResult Editare(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var produsDinDB = _db.Produsele.FirstOrDefault(u => u.Id == id);
                return View(produsDinDB);
            }

        }
        //Post Editare
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editare(Produs obiect)
        {
            if (ModelState.IsValid)
            {
                _db.Produsele.Update(obiect);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }




        //Get Stergere
        public IActionResult Stergere(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var produsDinDB = _db.Produsele.FirstOrDefault(u => u.Id == id);
                return View(produsDinDB);
            }
        }
        //Post Stergere
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Stergere(Produs obiect)
        {
            if (ModelState.IsValid)
            {
                _db.Produsele.Remove(obiect);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
