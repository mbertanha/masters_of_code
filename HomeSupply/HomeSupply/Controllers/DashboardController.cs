using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeSupply.Utils;
using SimplifyCommerce.Payments;

namespace HomeSupply.Controllers
{
    public class DashboardController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Mensagem = "Olá mundo!";
            return View();
        }

        [HttpPost]
        public ActionResult pagamento()
        {

            try
            {
                
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Compra efetuada com sucesso";
                Console.WriteLine(e.GetBaseException());
            }

            return View();
        }

    }
}
