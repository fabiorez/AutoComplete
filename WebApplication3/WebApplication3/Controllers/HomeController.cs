using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto _contexto = new Contexto();

        public ActionResult Index()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Pessoa> pessoas;

            if (string.IsNullOrEmpty(searchTerm))
            {
                pessoas = _contexto.Pessoas.ToList();
            }
            else
            {
                pessoas = _contexto.Pessoas.Where(x => x.Nome.Contains(searchTerm)).ToList();
            }

            return View(pessoas);
        }

        public ActionResult Index2()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Index2(string searchTerm)
        {
            List<Pessoa> pessoas;

            if (string.IsNullOrEmpty(searchTerm))
            {
                pessoas = _contexto.Pessoas.ToList();
            }
            else
            {
                pessoas = _contexto.Pessoas.Where(x => x.Nome.Contains(searchTerm)).ToList();
            }

            return View(pessoas);
        }

        public JsonResult PegarPessoas(string term)
        {
            List<string> pessoas;

            pessoas = _contexto.Pessoas.Where(x => x.Nome.Contains(term))
                .Select(x => x.Nome).ToList();

            return Json(pessoas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PegarPessoa(int id)
        {
            Pessoa pessoa;

            pessoa = _contexto.Pessoas.Where(x => x.Id == id).FirstOrDefault();

            return Json(pessoa, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersons(string term)
        {
            List<Pessoa> pessoas;

            pessoas = _contexto.Pessoas.Where(x => x.Nome.Contains(term)).ToList();

            return Json(pessoas, JsonRequestBehavior.AllowGet);
        }
    }
}