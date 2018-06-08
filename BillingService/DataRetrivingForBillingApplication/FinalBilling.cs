using System;
using System.Collections.Generic;
using CommonClasses;


namespace DataRetrivingForBillingApplication
{
    public class FinalBilling
    {
        double totalBillAmount = 0;
        double discountedPrice = 0;
        public List<PurchaseProductDetail> billForCurrentCustomer(List<PurchaseProductDetail> productsBought, List<ProductDetail> balanceProduct, List<ProductDetail> removeUnavailableProducts)
        {
            foreach (PurchaseProductDetail billedProducts in productsBought)
            {
                if (productsBought.Count > 2 && productsBought.Count <= 5)
                {
                    totalBillAmount += billedProducts.price;
                }

                if (productsBought.Count > 5)
                {
                    totalBillAmount += billedProducts.price;

                }
                if (productsBought.Count <= 2)
                {
                    totalBillAmount += billedProducts.price;

                }

            }

            if (productsBought.Count <= 2)
            {
                foreach (PurchaseProductDetail billedProducts in productsBought)
                {
                    billedProducts.Total_Bill_Amount = Convert.ToInt32(totalBillAmount);
                    billedProducts.Discount_Percentage = 0.ToString();
                    billedProducts.Discounted_Amount = Convert.ToInt32(discountedPrice);
                    billedProducts.Discounted_Bill = Convert.ToInt32(totalBillAmount - discountedPrice);

                }
            }

            if (productsBought.Count > 2 && productsBought.Count <= 5)
            {
                discountedPrice = totalBillAmount * 10 / 100;
                foreach (PurchaseProductDetail billedProducts in productsBought)
                {
                    billedProducts.Total_Bill_Amount = Convert.ToInt32(totalBillAmount);
                    billedProducts.Discount_Percentage = 10.ToString();
                    billedProducts.Discounted_Amount = Convert.ToInt32(discountedPrice);
                    billedProducts.Discounted_Bill = Convert.ToInt32(totalBillAmount - discountedPrice);
                }

            }
            if (productsBought.Count > 5)
            {
                discountedPrice = totalBillAmount * 30 / 100;
                foreach (PurchaseProductDetail billedProducts in productsBought)
                {
                    billedProducts.Total_Bill_Amount = Convert.ToInt32(totalBillAmount);
                    billedProducts.Discount_Percentage = 30.ToString();
                    billedProducts.Discounted_Amount = Convert.ToInt32(discountedPrice);
                    billedProducts.Discounted_Bill = Convert.ToInt32(totalBillAmount - discountedPrice);
                }

            }
            DataAccessForBillingApplication.DataHandling purchaseDetailUpdate = new DataAccessForBillingApplication.DataHandling();
            if (productsBought.Count == 0 || productsBought.Count > 0)
            {
                PurchaseProductDetail updateAboutPurchase = new PurchaseProductDetail();
                foreach (PurchaseProductDetail previousPurchase in productsBought)
                {

                    updateAboutPurchase.Customer_Name = previousPurchase.Customer_Name;
                    updateAboutPurchase.productID = previousPurchase.productID;
                    updateAboutPurchase.productName = previousPurchase.productName;
                    updateAboutPurchase.price = previousPurchase.price;
                    updateAboutPurchase.quantity = previousPurchase.quantity;
                    updateAboutPurchase.Total_Bill_Amount = previousPurchase.Total_Bill_Amount;
                    updateAboutPurchase.Discount_Percentage = previousPurchase.Discount_Percentage;
                    updateAboutPurchase.Discounted_Amount = previousPurchase.Discounted_Amount;
                    updateAboutPurchase.Discounted_Bill = previousPurchase.Discounted_Bill;
                    purchaseDetailUpdate.productPurchaseDetails(updateAboutPurchase);

                }

            }
            if (removeUnavailableProducts.Count > 0)
            {
                foreach (ProductDetail ProductToBeRemoved in removeUnavailableProducts)
                {
                    ProductDetail productsNotAvailable = new ProductDetail();
                    productsNotAvailable.productID = ProductToBeRemoved.productID;
                    productsNotAvailable.productName = ProductToBeRemoved.productName;
                    productsNotAvailable.price = ProductToBeRemoved.price;
                    productsNotAvailable.quantity = ProductToBeRemoved.quantity;
                    purchaseDetailUpdate.ProductRemoving(productsNotAvailable);
                }

            }
            if (balanceProduct.Count > 0)
            {
                ProductDetail productsInStoreAfterPurchase = new ProductDetail();
                foreach (ProductDetail balance in balanceProduct)
                {
                    productsInStoreAfterPurchase.productID = balance.productID;
                    productsInStoreAfterPurchase.productName = balance.productName;
                    productsInStoreAfterPurchase.price = balance.price;
                    productsInStoreAfterPurchase.quantity = balance.quantity;

                    purchaseDetailUpdate.RemainingProductsAvailable(productsInStoreAfterPurchase);
                }
            }
            return productsBought;
        }
    }
}


