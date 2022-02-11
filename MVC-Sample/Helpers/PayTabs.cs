using Newtonsoft.Json;

namespace MVC_Sample.Helpers
{
    public class PayTabs
    {
    }

    public class PaypageParams
    {
        public int profile_id = 0;

        public string tran_type = "sale";
        public string tran_class = "ecom";

        public float cart_amount = 0;
        public string cart_currency = "JOD";
        public string cart_id = "biolab_id_";
        public string cart_description = "";

        public bool framed = false;
        public bool framed_return_top = true;

        public bool hide_shipping = true;

        [JsonProperty("return")]
        public string return_url = "";

        public string callback = "";
    }

    public class PaypageResponse
    {
        public string? tran_ref;
        public string? cart_id;
        public string? redirect_url;
        public string? trace;

        public string? message;

        public bool IsSuccessful()
        {
            return redirect_url != null;
        }
    }


    public class PaytabsReturnResponse
    {
        public string? tranRef { get; set; }

        public string? respCode { get; set; }
        public string? respMessage { get; set; }
        public string? respStatus { get; set; }

        public string? acquirerMessage { get; set; }
        public string? acquirerRRN { get; set; }

        public string? cartId { get; set; }
        public string? customerEmail { get; set; }

        public string? signature { get; set; }

        public string? token { get; set; }
    }

    public class PaytabsIPNResponse
    {
        public int merchant_id { get; set; }
        public int profile_id { get; set; }

        public string? tran_ref { get; set; }
        public string? tran_type { get; set; }

        public float cart_amount { get; set; }
        public string? cart_currency { get; set; }
        public string? cart_id { get; set; }
        public string? cart_description { get; set; }

        public string? tran_class { get; set; }
        public string? tran_currency { get; set; }
        public float tran_total { get; set; }

        public PaymentResult? payment_result { get; set; }

        //public CustomerDetails customer_details;
        //public Payment_Info payment_info;
    }

    public class PaymentResult
    {
        public string? response_status{ get; set; }
        public string? response_code{ get; set; }
        public string? response_message{ get; set; }

        public string? cvv_result{ get; set; }
        public string? avs_result{ get; set; }

        public DateTime transaction_time{ get; set; }
    }
}
