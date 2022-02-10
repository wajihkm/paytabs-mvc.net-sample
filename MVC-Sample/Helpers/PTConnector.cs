using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Text.Json;

namespace MVC_Sample.Helpers
{
    public class PTConnector
    {
        static string pt_endpoint = "https://secure-jordan.paytabs.com/";
        static int pt_profile_id = 50115;
        static string pt_server_key = "S2JNLWNLTL-HZTBTZ2R6J-NR6NDZ9G2M";


        //

        public static async Task<PaypageResponse> CreatePayment(
            float amount, string currency, string order_id, string desc, bool frammed, string return_url, string callback_url)
        {
            var client = new RestClient(pt_endpoint);

            var args = new PaypageParams
            {
                profile_id = pt_profile_id,

                cart_amount = amount,
                cart_currency = currency,
                cart_id = order_id,
                cart_description = desc,

                framed = frammed,

                return_url = return_url,
                callback = callback_url
            };

            var request = new RestRequest("payment/request");
            request.AddHeader("Authorization", pt_server_key);

            var body = JsonConvert.SerializeObject(args);
            //request.AddJsonBody(body);
            request.AddParameter("text/plain", body, ParameterType.RequestBody);


            try
            {
                var response = await client.PostAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    var pt_paypage = JsonConvert.DeserializeObject<PaypageResponse>(response.Content);
                    if (pt_paypage != null && pt_paypage.IsSuccessful())
                    {
                        return pt_paypage;
                    }
                }

                Console.Error.WriteLine(response.Content);
                Console.Error.WriteLine(response.ErrorMessage);

                return new PaypageResponse { message = response.Content };
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return new PaypageResponse { message = ex.Message };
            }
        }
    }
}
