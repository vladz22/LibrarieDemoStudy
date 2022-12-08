using LibrarieDemo.Data;
using LibrarieDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarieDemo.Controllers
{
    public class ProdusController : Controller
    {

        private readonly DbContextObiectConex _db;
        private readonly IWebHostEnvironment _hostEnvironment;//e deja adaugat ca dependency injection in asp.net trebuie doar sa il extrag
        public ProdusController(DbContextObiectConex db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
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
        public IActionResult Creare(Produs obiect,IFormFile? fisier)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if(fisier!=null)
                {
                    //upload
                    string fisierNume=Guid.NewGuid().ToString();//dam rename la fiecare fisier uploadat sa nu se incurce 2 fisiere similare
                    var uploadat=Path.Combine(wwwRootPath,@"imagini\produse");
                    var extensie = Path.GetExtension(fisier.FileName);
                    //copiem fisierul uploadat in folder
                    using(var fisierStreams = new FileStream(Path.Combine(uploadat, fisierNume + extensie),FileMode.Create))
                    {
                        fisier.CopyTo(fisierStreams);
                    }
                    obiect.ImagineUrl = @"\imagini\produse\" + fisierNume + extensie;

                }



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
                IEnumerable<SelectListItem> CategorieLista = _db.Categoriile.Select(
                u => new SelectListItem
                {
                    Text = u.Nume,
                    Value = u.Id.ToString()
                });
                ViewData["CategorieLista"] = CategorieLista;
               
                var produsDinDB = _db.Produsele.FirstOrDefault(u => u.Id == id);
                return View(produsDinDB);
            }

        }
        //Post Editare
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editare(Produs obiect,IFormFile? fisier)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (fisier != null)
                {
                    //upload
                    string fisierNume = Guid.NewGuid().ToString();//dam rename la fiecare fisier uploadat sa nu se incurce 2 fisiere similare
                    var uploadat = Path.Combine(wwwRootPath, @"imagini\produse");
                    var extensie = Path.GetExtension(fisier.FileName);
                    //stergem fisierul in caz de update
                    if(obiect.ImagineUrl!=null)
                    {
                        var vecheaPozaPath = Path.Combine(wwwRootPath, obiect.ImagineUrl.TrimStart('\\'));//caracterul "\" este un escape caracter si trebuie sa scriem de 2 ori
                        if(System.IO.File.Exists(vecheaPozaPath))
                        {
                            System.IO.File.Delete(vecheaPozaPath);
                        }

                    }
                    //copiem fisierul uploadat in folder
                    using (var fisierStreams = new FileStream(Path.Combine(uploadat, fisierNume + extensie), FileMode.Create))
                    {
                        fisier.CopyTo(fisierStreams);
                    }
                    obiect.ImagineUrl = @"\imagini\produse\" + fisierNume + extensie;

                }





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
