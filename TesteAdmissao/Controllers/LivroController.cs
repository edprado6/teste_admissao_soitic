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
            ViewBag.Title = "Livros";
            return View(livros);
        }

        //
        // GET: /Livro/Details/5

        public ActionResult Details(int LivroId)
        {
            var livro = db.Livros.FirstOrDefault(x => x.LivroId == LivroId);
            if (livro == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Detalhes";
            return View(livro);
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
                _Mensagem("OK", " Livro cadastrado com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                _Mensagem("FAILED", " Problema ao cadastrar.");
                return View();
            }
        }

        //
        // GET: /Livro/Edit/5

        public ActionResult Edit(int LivroId)
        {            
            var livro = db.Livros.FirstOrDefault(x => x.LivroId == LivroId);
            if (livro == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Autores = new SelectList(db.Autores.ToList(), "AutorId", "NomeAutor");
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "CategoriaId", "NomeCategoria");
            ViewBag.Title = "Editar Livro";
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
                _Mensagem("OK", " Livro editado com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                _Mensagem("FAILED", " Problema ao editar.");
                return View();
            }
        }

        
        //
        // POST: /Livro/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var livro = db.Livros.Find(id);
                db.Livros.Remove(livro);
                db.SaveChanges();
                _Mensagem("OK", " Livro excluído com sucesso.");
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
