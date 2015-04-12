using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HomeSupply.Utils;
using SimplifyCommerce.Payments;

namespace HomeSupply.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index(string cardToken, string amount, string name, string email, string reference)
        {
            if (!String.IsNullOrEmpty(cardToken) && !String.IsNullOrEmpty(amount) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(email))
            {
                var array = reference.Split('_');
                string id = array[0];
                string frequency = string.Empty;
                if (array.Count() > 1)
                {
                    frequency = array[1];
                }
                if (Pagamento(cardToken, amount, name, email, frequency))
                {
                    ViewBag.Id = id;
                    ViewBag.Mensagem = "Pagamento Realizado com Sucesso!";
                }
                else
                {
                    ViewBag.Mensagem = "Ocorreu um erro durante o pagamento!";
                }
            }

            return View();
        }
        public bool Pagamento(string token, string amount, string name, string email, string frequency)
        {
            PaymentsApi.PrivateApiKey = SimplifyKeys.PrivateKey;
            PaymentsApi.PublicApiKey = SimplifyKeys.PublicKey;

            PaymentsApi api = new PaymentsApi();

            // Pontual
            if (String.IsNullOrEmpty(frequency))
            {
                Payment payment = new Payment();
                payment.Amount = Convert.ToInt64(amount);
                payment.Currency = CurrencyInfo.Currency;
                payment.Description = CurrencyInfo.DescriptionPayment;
                payment.Token = token;

                try
                {
                    payment = (Payment)api.Create(payment);
                    this.enviarEmail();
                    return payment.PaymentStatus.Equals("APPROVED");
                }
                catch
                {
                    ViewBag.Mensagem = "Houve um erro na execução. Não processado!";
                    return false;
                }
            }
            else
            {
                Plan plan = new Plan();
                plan.Amount = Convert.ToInt64(amount);
                plan.Frequency = frequency;
                plan.Name = "Recurring Payment";

                try
                {
                    plan = (Plan)api.Create(plan);
                }
                catch
                {
                    ViewBag.Mensagem = "Houve um erro na execução. Não processado!";
                    return false;
                }

                Customer customer = new Customer();
                customer.Token = token;
                customer.Email = email;
                customer.Name = name;
                List<Subscription> subscriptions = new List<Subscription>();
                Subscription subscription = new Subscription();
                subscription.Plan = plan;
                subscriptions.Add(subscription);
                customer.Subscriptions = subscriptions;

                try
                {
                    api.Create(customer);
                    this.enviarEmail();
                }
                catch
                {
                    ViewBag.Mensagem = "Houve um erro na execução. Não processado!";
                    return false;
                }

                return true;
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
            catch
            {
                return false;
            }
        }

        public void enviarEmail()
        {
            String mensagem = String.Empty;
            Email email = new Email();
            
            if ( email.enviarEmail() )
            {
                mensagem = "Enviado com sucesso.";
            }
            
            if (String.IsNullOrEmpty(mensagem))
            {
                mensagem = "Houve um erro ao enviar o email";
            }

            ViewBag.Mensagem = mensagem;
            //return mensagem;
        }

    }
}
