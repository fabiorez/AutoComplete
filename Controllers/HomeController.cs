using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using autocomplete.Models;

namespace autocomplete.Controllers
{
    public class HomeController : Controller
    {
        private Contexto _db = new Contexto();

        public ActionResult Index()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Index(string txtPesquisa)
        {
            List<Pessoa> pessoas;

            if (string.IsNullOrEmpty(txtPesquisa))
            {
                pessoas = _db.Pessoas.ToList();
            }
            else
            {
                pessoas = _db.Pessoas.Where(x => x.Nome.StartsWith(txtPesquisa)).ToList();
            }

            return View(pessoas);
        }

        public JsonResult CarregarNomes(string term)
        {
            List<string> pessoas;

            pessoas = _db.Pessoas.Where(x => x.Nome.StartsWith(term))
                .Select(x => x.Nome).ToList();

            return Json(pessoas, JsonRequestBehavior.AllowGet);
        }
    }
}