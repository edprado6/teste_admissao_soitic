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
        /*
        * A classe que representa o DB é instanciada.
        */
        private DBLivro db = new DBLivro();

        /* GET: /Categoria/
         * Exibe lista com todos autores cadastrados.
         */
        public ActionResult Index()
        {
            var categorias = db.Categorias.ToList();
            ViewBag.Title = "Categorias";
            return View(categorias);
        }

        /* GET: /Categoria/Create
         * Abre o formulário para cadastro de categorias.
         */
        public ActionResult Create()
        {
            ViewBag.Title = "Cadastrar Categoria";
            return View();
        }

        /* POST: /Categoria/Create
         * Recebe o POST do formulário de cadastro de livros.
         */
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                categoria.DataInsercao = DateTime.Now;
                categoria.DataAlteracao = DateTime.Now;
                db.Categorias.Add(categoria);
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Categoria editada com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao cadastrar.");
                return View();
            }
        }
                
        /* GET: /Categoria/Edit/5
         * Recebe um id e busca uma categoria no bd. Se uma categoria for 
         * encontrada, abre o formulário para edição.
         */
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
               
        /* POST: /Categoria/Edit/5
         * Recebe o post do formulário de edição de livros.
         */
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                var c = db.Categorias.Find(categoria.CategoriaId);
                c.NomeCategoria = categoria.NomeCategoria;
                c.DataAlteracao = DateTime.Now;
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Categoria editada com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao editar.");
                return View();
            }
        }

        /*
         * Método de visualização de detalhes da categoria. 
         * Não utiliza view. 
         * O retorno é Json que será exibido em uma janela modal. 
         */
        [HttpGet]
        public JsonResult Detalhes(int id)
        {
            var categoria = db.Categorias.ToList().FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null)
            {
                var response = new
                {
                    Status = "FAILED",
                    Mensagem = "Não foi encontrado nenhuma categoria com o código informado."
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = new
                {
                    CategoriaId = categoria.CategoriaId,
                    NomeCategoria = categoria.NomeCategoria,
                    DataInsercao = categoria.DataInsercao,
                    DataAlteracao = categoria.DataAlteracao
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
               
        /* GET: /Categoria/Delete/5
         * Recebe id e executa o método responsável pela
         * exclusão de elementos.
         */
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var categoria = db.Categorias.Find(id);
                db.Categorias.Remove(categoria);
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Categoria excluída com sucesso.");
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
