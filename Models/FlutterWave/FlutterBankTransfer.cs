using System;
using System.Collections.Generic;
using System.Text;

namespace Models.FlutterWave
{
    public class FlutterBankTransfer
    {
        public string Email { get; set; }                 // Endpoint = https://api.flutterwave.com/v3/charges?type=bank_transfer
        public string Currency { get => "NGN"; }
        public string Amount { get; set; }
        public string Tx_Ref { get; set; }
    }

    public class FlutterWaveCard
    {
        public string Card_Number { get; set; }
        public string CVV { get; set; }
        public string Expiry_Month { get; set; }
        public string Expiry_Year { get; set; }
        public string Currency { get => "NGN"; }
        public string Amount { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Tx_Ref { get; set; }
        public string Redirect_Url { get; set; }
        public Authorization Authorization { get; set; }
                                                                    //         "card_number": "4556052704172643",
                                                                    //  "cvv": "899",
                                                                    //  "expiry_month": "01",
                                                                    //  "expiry_year": "23",
                                                                    //  "currency": "NGN",
                                                                    //  "amount": "7500",
                                                                    //  "email": "developers@flutterwavego.com",
                                                                    //  "fullname": "Flutterwave Developers",
                                                                    //  "tx_ref": "MC-3243e",
                                                                    //  "redirect_url":"https://your-awesome.app/payment-redirect",
                                                                    //+  "authorization": {
                                                                    //+    "mode": "pin",
                                                                    //+    "pin": "3310"

    }

    public class Authorization
    {
        public string Mode { get => "pin"; }
        public string Pin { get; set; }
    }
}
