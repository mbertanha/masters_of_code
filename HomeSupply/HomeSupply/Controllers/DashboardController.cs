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
        public ActionResult pagamento(String token, String amount)
        {
            PaymentsApi.PrivateApiKey = SimplifyKeys.PrivateKey;
            PaymentsApi.PublicApiKey = SimplifyKeys.PublicKey;

            PaymentsApi paymentApi = new PaymentsApi();

            Authorization auth = new Authorization();
            auth.Amount = long.Parse(amount);
            auth.Currency = CurrencyInfo.Currency;
            auth.Description = CurrencyInfo.DescriptionPayment;
            //auth.Reference = "7a6ef6be31";
            auth.Token = token;

            try
            {
                auth = (Authorization)paymentApi.Create(auth);

                if (!String.IsNullOrEmpty(auth.PaymentStatus))
                {
                    if (auth.PaymentStatus.Equals(""))
                    {
                        ViewBag.Mensagem = PaymentInfo.payment_success;
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = PaymentInfo.payment_success;
                Console.WriteLine(e.GetBaseException());
            }

            return View();
        }

        private Boolean verifyLostStolenCard(String id)
        {
            PaymentsApi paymentApi = new PaymentsApi();

            CardToken cardToken = (CardToken)paymentApi.Find(typeof(CardToken), id);

            try
            {
                //CODE API LOST STOLEN

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
