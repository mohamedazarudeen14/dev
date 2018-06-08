using System.Collections.Generic;
using CommonClasses;
using data = DataRetrivingForBillingApplication;

namespace BillingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        static data.CustomerDataSection customerDataSection;
        static data.FinalBilling finalBilling;
       
        public List<ProductDetail> GetAllProducts()
        {
            if (customerDataSection == null)
            {
                customerDataSection = new data.CustomerDataSection();
            }
            customerDataSection.details = new List<ProductDetail>();
            customerDataSection.removingUnAvailableProducts = new List<ProductDetail>();
            customerDataSection.purchasedProducts = new List<PurchaseProductDetail>();
            return customerDataSection.ProductsInStore();
        }

        public List<PurchaseProductDetail> CurrentCustomerPurchasedDetails(string customerChoice, int productID, int quantity, string customerName)
        {
            return customerDataSection.BillingDetails(customerChoice, productID, quantity, customerName);
        }

        public List<ProductDetail> AvailableProductsAfterCurrentPurchase()
        {
            return customerDataSection.BalanceAvailableProducts();
        }

        public List<PurchaseProductDetail> DeleteProductFromCurrentPurchase(int productID)
        {
            return customerDataSection.DeletingProducts(productID);
        }

        public List<PurchaseProductDetail> FinalBillForCurrentCustomer()
        {
            if (finalBilling == null)
            {
                finalBilling = new data.FinalBilling();
            }
            return finalBilling.billForCurrentCustomer(customerDataSection.purchasedProducts, customerDataSection.details, customerDataSection.removingUnAvailableProducts);
        }

        public List<PurchaseProductDetail> PurchasedProducts()
        {
            return customerDataSection.purchasedProducts;
        }
    }
}
