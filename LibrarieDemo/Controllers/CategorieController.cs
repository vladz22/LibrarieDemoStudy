using LibrarieDemo.Data;
using LibrarieDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarieDemo.Controllers
{
    public class CategorieController : Controller
    {
        private readonly DbContextObiectConex _db;
        public CategorieController(DbContextObiectConex db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Categorie> CategorieLista=_db.Categoriile;
            return View(CategorieLista);
        }
        //Get
        public IActionResult Creare()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creare(Categorie obiect)
        {
            _db.Categoriile.Add(obiect);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
