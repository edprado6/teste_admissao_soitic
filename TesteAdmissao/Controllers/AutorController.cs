using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contexto;
using Dominio;

namespace TesteAdmissao.Controllers
{
    public class AutorController : Controller
    {
        private DBLivro db = new DBLivro();
               
        /* GET: /Autor/
         * Exibe lista com todos autores cadastrados.
         */
        public ActionResult Index()
        {
            ViewBag.Title = "Autores";
            var autores = db.Autores.ToList();
            return View(autores);
        }

        //
        // GET: /Autor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Autor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Autor/Create

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            try
            {
                autor.DataInsercao = DateTime.Now;
                autor.DataAlteracao = DateTime.Now;
                db.Autores.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Autor/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
                
        /* POST: /Autor/Delete/5
         * Recebe autor_id e executa o método da aplicação responsável pela
         * exclusão de elementos.
         */
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var autor = db.Autores.Find(id);
                db.Autores.Remove(autor);
                db.SaveChanges();
                _Mensagem("OK"," Autor excluído com sucesso.");                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /*
         * Método que retorna um TempData com mensagem, classe para exbição e ícone.
         * Observação: criar um helper para que possa ser usado em outras Controllers.
         */
        public void _Mensagem(string status, string mensagem)
        {
            if (status == "OK")
            {
                TempData["mensagem"] = mensagem;
                TempData["classe"] = "alert alert-success";
                TempData["icone"] = "fa fa-check";
            }
            else
            {
                TempData["mensagem"] = mensagem;
                TempData["classe"] = "alert alert-danger";
                TempData["icone"] = "fa fa-ban";
            }

        }
    }
}
