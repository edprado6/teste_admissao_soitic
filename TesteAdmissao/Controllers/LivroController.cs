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
        /*
        * A classe que representa o DB é instanciada.
        */
        private DBLivro db = new DBLivro();

        /* GET: /Livro/
         * Exibe lista com todos autores cadastrados.
         */
        public ActionResult Index()
        {
            var livros = db.Livros.ToList();
            ViewBag.Title = "Livros";
            return View(livros);
        }

        /* GET: /Livro/Create
          * Abre o formulário para cadastro de livros.
          */
        public ActionResult Create()
        {
            ViewBag.Autores = new SelectList(db.Autores.ToList(), "AutorId", "NomeAutor");
            ViewBag.Categorias = new SelectList(db.Categorias.ToList(), "CategoriaId", "NomeCategoria");
            ViewBag.Title = "Cadastrar Livros";
            return View();
        }


        /* POST: /Livro/Create
         * recebe o POST do formulário de cadastro de livros.
         */
        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            try
            {
                livro.DataInsercao = DateTime.Now;
                livro.DataAlteracao = DateTime.Now;
                db.Livros.Add(livro);
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Livro cadastrado com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao cadastrar.");
                return View();
            }
        }

        /*  GET: /Livro/Edit/5
         * Recebe um id e busca um livro no bd. Se um livro for 
         * encontrado, abre o formulário para edição.
         */
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

        /* POST: /Livro/Edit/5
         * Recebe o post do formulário de edição de livros.
         */
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
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Livro editado com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao editar.");
                return View();
            }
        }

        /*
         * Método de visualização de detalhes do livro. 
         * Não utiliza view. 
         * O retorno é Json que será exibido em uma janela modal. 
         */
        [HttpGet]
        public JsonResult Detalhes(int id)
        {
            Livro livro = new Livro();
            livro = db.Livros.Find(id);

            if (livro == null)
            {
                var response = new
                {
                    Status = "FAILED",
                    Mensagem = "Não foi encontrado nenhum livro com o código informado."
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = new
                    {
                        LivroId = livro.LivroId,
                        NomeLivro = livro.NomeLivro,
                        AnoPublicacao = livro.AnoPublicacao,
                        DataInsercao = livro.DataInsercao,
                        DataAlteracao = livro.DataAlteracao,
                        Edicao = livro.Edicao,
                        Editora = livro.Editora,
                        NomeAutor = livro.Autor.NomeAutor,
                        NomeCategoria = livro.Categoria.NomeCategoria
                    };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }


        /* GET: /Autor/Delete/5
         * Recebe id e executa o método responsável pela
         * exclusão de elementos.
         */
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var livro = db.Livros.Find(id);
                db.Livros.Remove(livro);
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Livro excluído com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao excluir.");
                return View();
            }
        }
    }
}
