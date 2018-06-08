using DataAccessForBillingApplication;
using System;
using System.Collections.Generic;
using CommonClasses;

namespace DataRetrivingForBillingApplication
{
    public class CustomerDataSection : Billing
    {
        public List<ProductDetail> removingUnAvailableProducts = new List<ProductDetail>();
        public List<ProductDetail> details = new List<ProductDetail>();
        public List<PurchaseProductDetail> purchasedProducts = new List<PurchaseProductDetail>();

        public override List<PurchaseProductDetail> BillingDetails(string customerChoice, int productID, int quantity, string customerName)
        {
            foreach (ProductDetail productsAvailable in details)
            {
                if (productID == productsAvailable.productID)
                {
                    if (quantity <= productsAvailable.quantity)
                    {
                        PurchaseProductDetail purchased = new PurchaseProductDetail();
                        purchased.productID = productsAvailable.productID;
                        purchased.productName = productsAvailable.productName;
                        purchased.price = Convert.ToInt32((productsAvailable.price * quantity));
                        purchased.quantity = quantity;
                        purchased.Customer_Name = customerName;
                        productsAvailable.quantity -= quantity;

                        if (purchasedProducts.Count == 0)
                        {
                            purchasedProducts.Add(purchased);
                            break;
                        }
                        if (purchasedProducts.Count > 0)
                        {
                            foreach (PurchaseProductDetail quantityAddition in purchasedProducts)
                            {
                                if (quantityAddition.productID == productID)
                                {
                                    quantityAddition.quantity += quantity;
                                    quantityAddition.price = Convert.ToInt32((purchased.price + quantityAddition.price));
                                    break;
                                }
                                else
                                {
                                    purchasedProducts.Add(purchased);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return purchasedProducts;
        }

        public List<PurchaseProductDetail> DeletingProducts(int productID)
        {
            bool isQuantityAdded = false;
            bool isProductAdded = false;
            PurchaseProductDetail productsRemoving = null;
            ProductDetail addingProductsAgain = new ProductDetail();
            foreach (PurchaseProductDetail deletingProducts in purchasedProducts)
            {
                if (productID.Equals(deletingProducts.productID))
                {
                    productsRemoving = deletingProducts;
                    foreach (ProductDetail addProduct in details)
                    {
                        if (addProduct.productID == productID)
                        {
                            addProduct.quantity += deletingProducts.quantity;
                            isQuantityAdded = true;
                            break;
                        }
                        else
                        {

                            addingProductsAgain.productID = deletingProducts.productID;
                            addingProductsAgain.productName = deletingProducts.productName;
                            addingProductsAgain.price = deletingProducts.price;
                            addingProductsAgain.quantity = deletingProducts.quantity;
                            removingUnAvailableProducts.Remove(addingProductsAgain);
                            isProductAdded = true;
                        }
                    }

                }

            }
            if (isQuantityAdded)
            {
                purchasedProducts.Remove(productsRemoving);
            }
            if (isProductAdded)
            {
                details.Add(addingProductsAgain);
            }
            return purchasedProducts;
        }

        public override List<ProductDetail> BalanceAvailableProducts()
        {
            ProductDetail remainedProduct = null;
            bool isNotAvailable = false;

            foreach (ProductDetail remainingProducts in details)
            {
                if (remainingProducts.quantity == 0)
                {
                    isNotAvailable = true;
                    remainedProduct = remainingProducts;
                    removingUnAvailableProducts.Add(remainingProducts);
                }
            }
            if (isNotAvailable)
            {
                details.Remove(remainedProduct);
            }
            return details;
        }
        public List<ProductDetail> ProductsInStore()
        {
            DataHandling dataHandling = new DataHandling();
            List<ProductDetail> StoreProducts = dataHandling.productRetrieval();
            foreach (ProductDetail productsFromStore in StoreProducts)
            {
                details.Add(productsFromStore);
            }
            return StoreProducts;
        }
    }
}
