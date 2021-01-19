using System;

namespace shop_backend.Services.Interfaces
{
    public interface IDotPayService
    {
        string CreatePaymentTransactionUri(int transactionId, int amount, string userEmail, string callbackUrl);
        string GenerateChk(string parameters, bool includeShopId);
    }
}
