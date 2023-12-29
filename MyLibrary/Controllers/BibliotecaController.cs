using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class BibliotecaController : Controller
    {

        readonly private ApplicationDbContext _db;

        public BibliotecaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<BibliotecaModel> biblioteca = _db.Biblioteca;
            return View(biblioteca);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            BibliotecaModel livro = _db.Biblioteca.FirstOrDefault(x => x.Id == id);

            if(livro == null)
            {
                return NotFound();
            }


            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(BibliotecaModel livro)
        {

            if(ModelState.IsValid)
            {
                _db.Biblioteca.Update(livro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0) 
            { 
                return NotFound(); 
            }

            BibliotecaModel livro = _db.Biblioteca.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        public IActionResult Excluir(BibliotecaModel livro)
        {
            if (livro == null)
            {
                return NotFound();
            }
            _db.Biblioteca.Remove(livro);
            _db.SaveChanges();
            return RedirectToAction("Index");
                            
        }


        [HttpPost]
        public IActionResult Cadastrar(BibliotecaModel livro)
        {
            if(ModelState.IsValid)
            {
                _db.Biblioteca.Add(livro);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
