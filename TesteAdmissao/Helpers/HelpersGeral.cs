using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteAdmissao.Helpers
{
    /*
     * A classe HelpersGeral possui métodos que são constantemente usados.
     * Podem ser ecssados em qualquer Controller.
     */
    public class HelpersGeral
    {

        /*
         * Método que retorna TempData com mensagem, classe para exbição e ícone.         
         */
        public static void MensagensDeStatus(Controller controller, string status, string mensagem)
        {

            if (status == "OK")
            {
                controller.TempData["mensagem"] = mensagem;
                controller.TempData["classe"] = "alert alert-success";
                controller.TempData["icone"] = "fa fa-check";
            }
            else
            {
                controller.TempData["mensagem"] = mensagem;
                controller.TempData["classe"] = "alert alert-danger";
                controller.TempData["icone"] = "fa fa-ban";
            }           
        }
    }
}