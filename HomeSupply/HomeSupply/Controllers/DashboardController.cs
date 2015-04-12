using System;
using System.Web.Mvc;
using HomeSupply.Utils;
using SimplifyCommerce.Payments;

namespace HomeSupply.Controllers
{
    public class DashboardController : Controller
    {

        public ActionResult Index(string cardToken, string amount)
        {
            //ViewBag.Mensagem = "Olá mundo!";
            if (!String.IsNullOrEmpty(cardToken) && !String.IsNullOrEmpty(amount))
            {
                Pagamento(cardToken, amount);
            }
            
            return View();
        }
        public void Pagamento(string token, string amount)
        {
            PaymentsApi.PrivateApiKey = SimplifyKeys.PrivateKey;
            PaymentsApi.PublicApiKey = SimplifyKeys.PublicKey;

            PaymentsApi api = new PaymentsApi();

            Payment payment = new Payment();
            payment.Amount = Convert.ToInt64("10");
            payment.Currency = "USD";
            payment.Description = "LearningSimplify";
            payment.Reference = "7a6ef6be31";
            payment.Token = token;

            try
            {
                payment = (Payment)api.Create(payment);

                if (!String.IsNullOrEmpty(payment.PaymentStatus))
                {
                    if (payment.PaymentStatus.Equals(""))
                    {
                        ViewBag.Mensagem = PaymentInfo.PaymentSuccess;
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = PaymentInfo.PaymentSuccess;
                Console.WriteLine(e.GetBaseException());
            }
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
