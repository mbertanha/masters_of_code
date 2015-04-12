using System;
using System.Collections.Generic;
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
                if (Pagamento(cardToken, amount, name, email, reference))
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
        public bool Pagamento(string token, string amount, string name, string email, string reference)
        {
            PaymentsApi.PrivateApiKey = SimplifyKeys.PrivateKey;
            PaymentsApi.PublicApiKey = SimplifyKeys.PublicKey;

            PaymentsApi api = new PaymentsApi();

            // Pontual
            if (String.IsNullOrEmpty(reference))
            {
                Payment payment = new Payment();
                payment.Amount = Convert.ToInt64(amount);
                payment.Currency = CurrencyInfo.Currency;
                payment.Description = CurrencyInfo.DescriptionPayment;
                payment.Token = token;

                try
                {
                    payment = (Payment) api.Create(payment);

                    return payment.PaymentStatus.Equals("APPROVED");
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                Plan plan = new Plan();
                plan.Amount = Convert.ToInt64(amount);
                plan.Frequency = reference;
                plan.Name = "Recurring Payment";

                try
                {
                    plan = (Plan)api.Create(plan);
                }
                catch
                {
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
                }
                catch (Exception e)
                {
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
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
