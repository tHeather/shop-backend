using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using shop_backend.Services.Interfaces;

namespace shop_backend.Services
{
    public class DotPayService : IDotPayService
    {
        private const string currency = "pln";
        private const string description = "Opłata doładowująca konto.";
        private const string shopName = "Study Online";
        private const string shopEmail = "support@study-online.pl";
        private readonly string dotpayShopId;
        private readonly string dotpayShopPin;

        public DotPayService(IConfiguration configuration)
        {
            dotpayShopId = configuration[ConfigurationKeys.DOTPAY_SHOP_ID] ?? throw new ArgumentNullException(dotpayShopId);
            dotpayShopPin = configuration[ConfigurationKeys.DOTPAY_SHOP_PIN] ?? throw new ArgumentNullException(dotpayShopPin);
        }

        public string CreatePaymentTransactionUri(int transactionId, int amount, string userEmail, string callbackUrl)
        {
            var paymentParams = new Dictionary<string, string>()
            {
                { "id", dotpayShopId },
                { "amount", amount.ToString() },
                { "currency", currency },
                { "description", description },
                { "control", transactionId.ToString() },
                //{ "urlc", callbackUrl }, //TODO Used on production to callback our endpoint to confirm transaction
                { "email", userEmail },
                { "p_info", shopName },
                { "p_email", shopEmail }
            };

            var chk = GenerateChk(string.Join("", paymentParams.Select(x => x.Value).ToList()), false);
            var linkParams = string.Join("", paymentParams.Select(x => $"&{x.Key}={x.Value}")).Remove(0,1);
            return $"{Constants.DOTPAY_URI}?{linkParams}&chk={chk}";
        }

        public string GenerateChk(string parameters, bool includeShopId)
        {
            string concatString = dotpayShopPin + (includeShopId ? dotpayShopId : "") + parameters;
            StringBuilder hash = new StringBuilder();
            using (SHA256 sha256 = SHA256.Create())
            {
                var result = sha256.ComputeHash(Encoding.UTF8.GetBytes(concatString));
                foreach (var b in result)
                    hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
