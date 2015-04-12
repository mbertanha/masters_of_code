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
            if (!String.IsNullOrEmpty(cardToken) && !String.IsNullOrEmpty(amount))
            {
                if (Pagamento(cardToken, amount))
                {
                    ViewBag.Mensagem = "Pagamento Realizado com Sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Ocorreu um erro durante o pagamento!";
                }
            }
            
            return View();
        }
        public bool Pagamento(string token, string amount)
        {
            PaymentsApi.PrivateApiKey = SimplifyKeys.PrivateKey;
            PaymentsApi.PublicApiKey = SimplifyKeys.PublicKey;

            PaymentsApi api = new PaymentsApi();

            Payment payment = new Payment();
            payment.Amount = Convert.ToInt64(amount);
            payment.Currency = CurrencyInfo.Currency;
            payment.Description = CurrencyInfo.DescriptionPayment;
            payment.Token = token;

            try
            {
                payment = (Payment)api.Create(payment);

                return payment.PaymentStatus.Equals("APPROVED");
            }
            catch
            {
                return false;
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
