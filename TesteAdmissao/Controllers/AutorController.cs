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
        /*
         * A classe que representa o DB é instanciada.
         */
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

        /* GET: /Autor/Details/5
         * Método de visualização de detalhes usando view.
         * Obs: Esse método foi substituído pelo método "Detalhes".
         */
        //public ActionResult Details(int AutorId)
        //{
        //    var autor = db.Autores.ToList().FirstOrDefault(c => c.AutorId == AutorId);            
        //    if (autor == null)
        //    {
        //        return HttpNotFound(); // Personalizar página de erro.
        //    }            
        //    ViewBag.Title = "Detalhes";            
        //    return View(autor);
        //}

        /* GET: /Autor/Create
         * Abre o formulário para cadastro de autores.
         */
        public ActionResult Create()
        {
            ViewBag.Title = "Cadastrar Autor";
            return View();
        }

        /* POST: /Autor/Create
         * recebe o POST do formulário de cadastro de autores.
         */
        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            autor.DataInsercao = DateTime.Now;
            autor.DataAlteracao = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Autores.Add(autor);
                db.SaveChanges();               
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Autor cadastrado com sucesso.");
                return RedirectToAction("Index");
            }            
            Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao cadastrar.");
            return View();
        }

        /* GET: /Autor/Edit/5
         * Recebe um id e busca um autor no bd. Se um autor for 
         * encontrado, abre o formulário para edição.
         */
        public ActionResult Edit(int AutorId)
        {
            var autor = db.Autores.ToList().FirstOrDefault(c => c.AutorId == AutorId);
            if (autor == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }
            ViewBag.Title = "Editar Autor";
            return View(autor);
        }


        /* POST: /Autor/Edit/5
         * Recebe o post do formulário de edição de autores.
         */
        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            try
            {
                var a = db.Autores.Find(autor.AutorId);
                a.NomeAutor = autor.NomeAutor;
                a.DataAlteracao = DateTime.Now;
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Autor editado com sucesso.");               
                return RedirectToAction("Index");
            }
            catch
            {               
                Helpers.HelpersGeral.MensagensDeStatus(this, "FAILED", " Problema ao editar.");
                return View();
            }
        }

        /*
         * Método de visualização de detalhes do autor. 
         * Não utiliza view. 
         * O retorno é Json que será exibido em uma janela modal. 
         */
        [HttpGet]
        public JsonResult Detalhes(int id)
        {
            var autor = db.Autores.ToList().FirstOrDefault(c => c.AutorId == id);

            if (autor == null)
            {
                var response = new 
                { 
                    Status = "FAILED",
                    Mensagem = "Não foi encontrado nenhum autor com o código informado."
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = new
                {
                    AutorId = autor.AutorId,
                    NomeAutor = autor.NomeAutor,
                    DataInsercao = autor.DataInsercao,
                    DataAlteracao = autor.DataAlteracao
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
                var autor = db.Autores.Find(id);
                db.Autores.Remove(autor);
                db.SaveChanges();
                Helpers.HelpersGeral.MensagensDeStatus(this, "OK", " Autor excluído com sucesso.");
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
