using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contexto;
using Dominio;

namespace TesteAdmissao.Controllers
{
    public class LivroController : Controller
    {
        private DBLivro db = new DBLivro();
        
        //
        // GET: /Livro/

        public ActionResult Index()
        {
            var livros = db.Livros.ToList();
            return View(livros);
        }

        //
        // GET: /Livro/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Livro/Create

        public ActionResult Create()
        {
            ViewBag.Autores = new SelectList(db.Autores.ToList(), "AutorId", "NomeAutor");
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "CategoriaId", "NomeCategoria");
            return View();
        }

        //
        // POST: /Livro/Create

        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            try
            {
                livro.DataInsercao = DateTime.Now;
                livro.DataAlteracao = DateTime.Now;
                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Livro/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Autores = new SelectList(db.Autores.ToList(), "AutorId", "NomeAutor");
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "CategoriaId", "NomeCategoria");
            Livro livro = db.Livros.FirstOrDefault(x => x.AutorId == id);            
            return View(livro);
        }

        //
        // POST: /Livro/Edit/5

        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            try
            {
                var l = db.Livros.Find(livro.LivroId);
                l.NomeLivro = livro.NomeLivro;
                l.Editora = livro.Editora;
                l.Edicao = livro.Edicao;
                l.AnoPublicacao = livro.AnoPublicacao;
                l.AutorId = livro.AutorId;
                l.CategoriaId = livro.CategoriaId;
                l.DataAlteracao = DateTime.Now;
                db.SaveChanges();               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Livro/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Livro/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
