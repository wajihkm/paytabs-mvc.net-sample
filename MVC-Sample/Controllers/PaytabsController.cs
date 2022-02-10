using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Sample.Helpers;

namespace MVC_Sample.Controllers
{
    public class PaytabsController : Controller
    {

        // GET: PaytabsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaytabsController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: PaytabsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(float amount, string currency, string order_id, string desc, bool frammed)
        {
            //"Id,ProfileId,Endpoint,ServerKey,TranType,TranClass,CartId,CartCurrency,CartAmount,CartDescription,PaypageLang,HideShipping,IsFramed,ReturnURL,CallbackURL"
            try
            {
                string return_url = this.Url.Action(nameof(Webhook), null, null, Request.Scheme)!;
                string callback_url = this.Url.Action(nameof(Ipn), null, null, Request.Scheme)!;

                PaypageResponse res = await PTConnector.CreatePayment(amount, currency, order_id, desc, frammed, return_url, callback_url);

                if (res.IsSuccessful())
                {
                    ViewData["Frammed"] = frammed;

                    return View("Paypage", res);
                }

                ViewData["Message"] = res.message;

                return View();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View();
            }
        }


        //

        [HttpPost]
        public IActionResult Webhook([FromForm] PaytabsReturnResponse content)
        {
            System.Console.WriteLine(content);

            return View(content);
        }

        //

        [HttpPost]
        public void Ipn([FromBody] PaytabsIPNResponse ipn)
        {
            //using var reader = new StreamReader(Request.Body);
            //string? body = await reader.ReadToEndAsync();
            //System.Console.WriteLine(body);
            //return body;

            System.Console.WriteLine(ipn);

            return;
        }

    }
}
