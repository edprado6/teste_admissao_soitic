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
        
        /* GET: /Autor/Details/5
         *
         */
        public ActionResult Details(int AutorId)
        {
            var autor = db.Autores.ToList().FirstOrDefault(c => c.AutorId == AutorId);            
            if (autor == null)
            {
                return HttpNotFound(); // Personalizar página de erro.
            }            
            ViewBag.Title = "Detalhes";            
            return View(autor);
        }

        //
        // GET: /Autor/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Cadastrar Autor";  
            return View();
        }

        //
        // POST: /Autor/Create
        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            autor.DataInsercao = DateTime.Now;
            autor.DataAlteracao = DateTime.Now;

            if(ModelState.IsValid)
            {                
                db.Autores.Add(autor);
                db.SaveChanges();
                _Mensagem("OK", " Autor cadastrado com sucesso.");
                return RedirectToAction("Index");
            }
            _Mensagem("FAILED", " Problema ao cadastrar."); 
            return View();
            
        }

        //
        // GET: /Autor/Edit/5

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

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {            
            try
            {
                var a = db.Autores.Find(autor.AutorId);
                a.NomeAutor = autor.NomeAutor;
                a.DataAlteracao = DateTime.Now;                
                db.SaveChanges();
                _Mensagem("OK", " Autor editado com sucesso.");
                return RedirectToAction("Index");
            }
            catch
            {
                _Mensagem("FAILED", " Problema ao editar."); 
                return View();
            }
        }
                
        /* POST: /Autor/Delete/5
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
                _Mensagem("OK"," Autor excluído com sucesso.");                
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
