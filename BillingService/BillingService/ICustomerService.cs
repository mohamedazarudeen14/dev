using System.Collections.Generic;
using System.ServiceModel;
using CommonClasses;

namespace BillingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<ProductDetail> GetAllProducts();

        [OperationContract]
        List<PurchaseProductDetail> CurrentCustomerPurchasedDetails(string customerChoice, int productID, int quantity, string customerName);

        [OperationContract]
        List<ProductDetail> AvailableProductsAfterCurrentPurchase();

        [OperationContract]
        List<PurchaseProductDetail> DeleteProductFromCurrentPurchase(int productID);

        [OperationContract]
        List<PurchaseProductDetail> FinalBillForCurrentCustomer();

        [OperationContract]
        List<PurchaseProductDetail> PurchasedProducts();
    }
}
