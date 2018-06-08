using System.Collections.Generic;
using System.Linq;
using CommonClasses;

namespace DataAccessForBillingApplication
{
    public class DataHandling
    {
        public List<ProductDetail> productRetrieval()
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                return entities.ProductDetails.ToList();
            }
        }

        public void productPurchaseDetails(CommonClasses.PurchaseProductDetail purchaseUpdate)
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                entities.PurchaseProductDetails.Add(purchaseUpdate);

                entities.SaveChanges();
            }
        }

        public void RemainingProductsAvailable(CommonClasses.ProductDetail remainingProducts)
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                foreach (CommonClasses.ProductDetail productsAvailable in entities.ProductDetails)
                {
                    if (remainingProducts.productID == productsAvailable.productID && remainingProducts.quantity != productsAvailable.quantity)
                    {
                        productsAvailable.quantity = remainingProducts.quantity;
                    }
                }
                entities.SaveChanges();
            }

        }

        public void ProductRemoving(CommonClasses.ProductDetail removeProducts)
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                entities.ProductDetails.Attach(removeProducts);
                entities.ProductDetails.Remove(removeProducts);
                entities.SaveChanges();
            }
        }

        public void productAdding(CommonClasses.ProductDetail productsAddition)
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                entities.ProductDetails.Add(productsAddition);
                entities.SaveChanges();
            }


        }

        public void adminChanges(CommonClasses.AdminProductChanx adminProductAdded)
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                entities.AdminProductChanges.Add(adminProductAdded);
                entities.SaveChanges();
            }
        }
    }
}
