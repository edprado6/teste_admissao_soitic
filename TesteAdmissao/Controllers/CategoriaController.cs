using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contexto;
using Dominio;

namespace TesteAdmissao.Controllers
{
    public class CategoriaController : Controller
    {
        private DBLivro db = new DBLivro();

        //
        // GET: /Categoria/
        public ActionResult Index()
        {
            var categorias = db.Categorias.ToList();
            ViewBag.Title = "Categorias";
            return View(categorias);
        }

        //
        // GET: /Categoria/Details/5
        public ActionResult Details(int CategoriaId)
        {
            var categoria = db.Categorias.ToList().FirstOrDefault(c => c.CategoriaId == CategoriaId);
            if (categoria == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Detalhes";
            return View(categoria);
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Cadastrar Categoria";
            return View();
        }

        //
        // POST: /Categoria/Create

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                // TODO: Add insert logic here
                categoria.DataInsercao = DateTime.Now;
                categoria.DataAlteracao = DateTime.Now;
                db.Categorias.Add(categoria);
                db.SaveChanges();
                _Mensagem("OK", " Categoria editada com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                _Mensagem("FAILED", " Problema ao cadastrar."); 
                return View();
            }
        }

        //
        // GET: /Categoria/Edit/5

        public ActionResult Edit(int CategoriaId)
        {
            var categoria = db.Categorias.ToList().FirstOrDefault(c => c.CategoriaId == CategoriaId);
            if (categoria == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Editar Categoria";
            return View(categoria);
        }

        //
        // POST: /Categoria/Edit/5

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                var c = db.Categorias.Find(categoria.CategoriaId);
                c.NomeCategoria = categoria.NomeCategoria;
                c.DataAlteracao = DateTime.Now;
                db.SaveChanges();
                _Mensagem("OK", " Categoria editada com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                _Mensagem("FAILED", " Problema ao editar."); 
                return View();
            }
        }

        //
        // POST: /Categoria/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var categoria = db.Categorias.Find(id);
                db.Categorias.Remove(categoria);
                db.SaveChanges();
                _Mensagem("OK", " Categoria excluída com sucesso.");    
                return RedirectToAction("Index");
            }
            catch
            {
                _Mensagem("FAILED", " Problema ao excluir."); 
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
