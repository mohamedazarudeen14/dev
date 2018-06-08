using System;
using System.Collections.Generic;

namespace BillingApplicationUserInterface
{
    public class CustomerSection
    {
        public string customerName;
        public int productID;
        public string customerChoice;
        public int quantity;

        ServiceCall serviceCall = new ServiceCall();
        public void productSelection()
        {
            Console.WriteLine("Enter Customer Name");
            customerName = Console.ReadLine();
            customerPurchaseSelection();
        }
        public void BillingDetails()
        {
            try
            {
                if (customerChoice.Equals("p"))
                {
                    Console.WriteLine("Enter the ProductID");
                    productID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter The Quantity You Want To Purchase");
                    quantity = Convert.ToInt32(Console.ReadLine());
            
                    List<CustomerService.PurchaseProductDetail> customerPurchased = serviceCall.CurrentProductsPurchasedDetails(customerChoice, productID, quantity, customerName);

                    if (customerPurchased.Count > 0)
                    {
                        currentPurchasedBill();
                    }
                    else
                    {
                        Console.WriteLine("Product Not Avaialble");
                    }
                }

                if (customerChoice.Equals("*"))
                {
                    BillingMainPage mainPage = new BillingMainPage();
                    mainPage.startingPage();
                }
                if (customerChoice.Equals("#"))
                {
                    if (serviceCall.CustomerPurchasedProductDetails().Count == 0)
                    {
                        Console.WriteLine("Not Purchased AnyThing Please Purchase");
                    }
                    else
                    {
                        Console.WriteLine("Enter product Id Which u Purchased");
                        productID = Convert.ToInt32(Console.ReadLine());
                        List<CustomerService.PurchaseProductDetail> purchaseAfterDeleting = serviceCall.DeleteProductsFromCurrentBill(productID);
                        Console.WriteLine("CURRENT PURCHASED PRODUCT");
                        foreach (CustomerService.PurchaseProductDetail purchaseProductDeleting in purchaseAfterDeleting)
                        {
                            Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} PRICE : {2} AVAILABLEQTY : {3}", purchaseProductDeleting.productID,
                                purchaseProductDeleting.productName, purchaseProductDeleting.price, purchaseProductDeleting.quantity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                customerPurchaseSelection();
            }
            BalanceProductAvailable();
            customerPurchaseSelection();
        }
        public void BalanceProductAvailable()
        {
            Console.WriteLine("\n");
            Console.WriteLine("BALANCE AVAILABLE PRODUCT");
            List<CustomerService.ProductDetail> Products = serviceCall.AvailableProductsAfterCurrentPurchase();
            foreach (CustomerService.ProductDetail remainingProducts in Products)
            {
                Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} PRICE : {2} AVAILABLEQTY : {3}", remainingProducts.productID, remainingProducts.productName,
             remainingProducts.price, remainingProducts.quantity);

            }
        }

        public void finalBill()
        {
            int totalBill = 0;
            string discountPercent = null;
            int discountAmount = 0;
            int discountBill = 0;
            if (serviceCall.CustomerPurchasedProductDetails().Count == 0)
            {
                Console.WriteLine("Not Yet Purchased Anything");
            }
            else
            {
                Console.WriteLine("Your Total Bill");
                List<CustomerService.PurchaseProductDetail> finalBillDetails = serviceCall.FinalBillingForCustomer();
                foreach (CustomerService.PurchaseProductDetail bill in finalBillDetails)
                {
                    Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} (1QTY)PRICE : {2}  PRICEFORPURCHASED : {3}  QTY : {4}", bill.productID,
                                bill.productName, (bill.price / bill.quantity), bill.price, bill.quantity);
                    totalBill = bill.Total_Bill_Amount;
                    discountPercent = bill.Discount_Percentage;
                    discountAmount = bill.Discounted_Amount;
                    discountBill = bill.Discounted_Bill;
                }

                Console.WriteLine("Total Product Purchased : {0}", finalBillDetails.Count);
                Console.WriteLine("Your Total Bill is : {0}", totalBill);
                Console.WriteLine("Discount Percentage : {0}", discountPercent);
                Console.WriteLine("Discount Amount : {0}", discountAmount);
                Console.WriteLine("DisCounted Bill : {0}", discountBill);
            }
            BillingMainPage mainPage = new BillingMainPage();
            mainPage.startingPage();

        }

        public void currentPurchasedBill()
        {
            Console.WriteLine("CURRENT PURCHASED PRODUCT");

            foreach (CustomerService.PurchaseProductDetail productsPurchasedTillNow in serviceCall.CustomerPurchasedProductDetails())
            {
                Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} (1QTY)PRICE : {2}  PRICEFORPURCHASED : {3}  QTY : {4}", productsPurchasedTillNow.productID,
                               productsPurchasedTillNow.productName, (productsPurchasedTillNow.price / productsPurchasedTillNow.quantity), productsPurchasedTillNow.price, productsPurchasedTillNow.quantity);
            }
        }
        public void availableProducts()
        {
            List<CustomerService.ProductDetail> products = serviceCall.AvailableProductsServiceCall();
            Console.WriteLine("PRODUCTS AVAILABLE IN STORE");
            foreach (CustomerService.ProductDetail availProducts in products)
            {
                Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} PRICE : {2} AVAILABLEQTY : {3} ", availProducts.productID,
                    availProducts.productName, availProducts.price, availProducts.quantity);
            }
        }

        public void customerPurchaseSelection()
        {
            Console.WriteLine("Enter 'p' To Start Purchase");
            Console.WriteLine("Enter 0 To Complete Your Billing And To Show the Products Which You Purchased");
            Console.WriteLine("Enter '*' to back to main page");
            Console.WriteLine("Enter '#' to Delete Product Which You Purchased");

            customerChoice = Console.ReadLine();
            switch (customerChoice)
            {
                case "0":
                    finalBill();
                    break;
                case "#":
                    BillingDetails();
                    break;
                case "p":
                    BillingDetails();
                    break;
                case "*":
                    BillingDetails();
                    break;
                default:
                    Console.WriteLine("Please Make A Good Selection");
                    customerPurchaseSelection();
                    break;
            }
        }
    }
}
