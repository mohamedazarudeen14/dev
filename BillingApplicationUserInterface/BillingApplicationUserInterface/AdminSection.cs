using System;
using System.Collections.Generic;

namespace BillingApplicationUserInterface
{
    public class AdminSection : IAdmin
    {
        public int adminChoice;
        public int userID;
        public string password;

        AdminService.ProductDetail productDetails = new AdminService.ProductDetail();
        ServiceCall serviceCall = new ServiceCall();

        public void AdminCheck()
        {
            try
            {
                Console.WriteLine("Enter '1' To Login");
                Console.WriteLine("Enter '0' to GOTO MainPage");
                adminChoice = Convert.ToInt32(Console.ReadLine());
                if (adminChoice == 1)
                {
                    Console.WriteLine("Enter Your UserID");
                    userID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Your Password");
                    password = Console.ReadLine();
                    string accessGranted = serviceCall.UserValidation(userID, password);
                    if (accessGranted.Equals("YES"))
                    {
                        Console.WriteLine("LoggedIn Successfully");
                        Console.WriteLine("Products Available");
                        Console.WriteLine("\n");
                        List<AdminService.ProductDetail> productsAvailable = serviceCall.ProductsAvailableInStore();
                        foreach (AdminService.ProductDetail products in productsAvailable)
                        {
                            Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} PRICE : {2} AVAILABLEQTY : {3}", products.productID, products.productName,
                                                 products.price, products.quantity);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Correct UserName And Password");
                        AdminCheck();
                    }
                }

                if (adminChoice == 0)
                {
                    BillingMainPage billingMainPage = new BillingMainPage();
                    billingMainPage.startingPage();
                }
                productAddition();
            }

            catch
            {
                Console.WriteLine("Enter Correct Choice");
                AdminCheck();
            }
        }

        public void productAddition()
        {
            bool isProductAdded = false;
            try
            {
                Console.WriteLine("Enter '1' To Add Products");
                Console.WriteLine("Enter '0' to GOTO MainPage");
                adminChoice = Convert.ToInt32(Console.ReadLine());

                if (adminChoice == 1)
                {
                    Console.WriteLine("Enter productName To Add");
                    productDetails.productName = Console.ReadLine();
                    Console.WriteLine("Enter price To Add");
                    productDetails.price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter Quantity To Add");
                    productDetails.quantity = Convert.ToInt32(Console.ReadLine());

                    string productAddingMessage = serviceCall.NewProductsAdditionToStore(productDetails);
                    if (productAddingMessage.Equals("Product Added SuccessFully"))
                    {
                        Console.WriteLine(productAddingMessage);
                        isProductAdded = true;
                    }
                }

                if (isProductAdded)
                {
                    serviceCall.DetailsOfNewProductAddition(userID, productDetails);
                }

                if (adminChoice == 0)
                {
                    BillingMainPage billingMainPage = new BillingMainPage();
                    billingMainPage.startingPage();
                }

                if (adminChoice != 0 && adminChoice != 1)
                {
                    Console.WriteLine("Choose The Correct Selection");
                    AdminCheck();
                }
                currentProducts();
                productAddition();

            }
            catch
            {
                Console.WriteLine("Enter the Correct Choice");
                productAddition();
            }
        }

        public void currentProducts()
        {
            List<AdminService.ProductDetail> productsAfterAddition = serviceCall.CurrentProductsAfterAdditionToStore();
            Console.WriteLine("Products Available In Store");
            Console.WriteLine("\n");
            foreach (AdminService.ProductDetail products in productsAfterAddition)
            {
                Console.WriteLine("PRODUCTID : {0} PRODUCTNAME : {1} PRICE : {2} AVAILABLEQTY : {3}", products.productID, products.productName,
                                             products.price, products.quantity);
            }
        }
    }
}
