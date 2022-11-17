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
    }
}
