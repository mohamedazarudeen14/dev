using System.Collections.Generic;
using CommonClasses;

namespace DataRetrivingForBillingApplication
{
    public abstract class Billing
    {
        public abstract List<ProductDetail> BalanceAvailableProducts();

        public abstract List<PurchaseProductDetail> BillingDetails(string customerChoice, int productID, int quantity, string customerName);
    }
}
