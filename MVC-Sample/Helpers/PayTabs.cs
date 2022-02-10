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
        public string? tranRef;

        public string? respCode;
        public string? respMessage;
        public string? respStatus;

        public string? acquirerMessage;
        public string? acquirerRRN;

        public string? cartId;
        public string? customerEmail;

        public string? signature;

        public string? token;
    }

    public class PaytabsIPNResponse
    {
        public int merchant_id;
        public int profile_id;

        public string? tran_ref;
        public string? tran_type;

        public float cart_amount;
        public string? cart_currency;
        public string? cart_id;
        public string? cart_description;

        public string? tran_class;
        public string? tran_currency;
        public float tran_total;

        public PaymentResult? payment_result;

        //public CustomerDetails customer_details;
        //public Payment_Info payment_info;
    }

    public class PaymentResult
    {
        public string? response_status;
        public string? response_code;
        public string? response_message;

        public string? cvv_result;
        public string? avs_result;

        public DateTime transaction_time;
    }
}
