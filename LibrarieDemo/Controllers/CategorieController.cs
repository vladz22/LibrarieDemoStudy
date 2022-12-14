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
            IEnumerable<Categorie> CategorieLista = _db.Categoriile;
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
            if (ModelState.IsValid)
            {
                _db.Categoriile.Add(obiect);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }
        //Get
        public IActionResult Editare(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            else
            {
                var categorieDinDB = _db.Categoriile.FirstOrDefault(u => u.Id == id);
                return View(categorieDinDB);
            }
           
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editare(Categorie obiect)
        {
            if (ModelState.IsValid)
            {
                _db.Categoriile.Update(obiect);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }




        //Get
        public IActionResult Stergere(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var categorieDinDB = _db.Categoriile.FirstOrDefault(u => u.Id == id);
                return View(categorieDinDB);
            }
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Stergere(Categorie obiect)
        {
            if(ModelState.IsValid)
            {
                _db.Categoriile.Remove(obiect);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
