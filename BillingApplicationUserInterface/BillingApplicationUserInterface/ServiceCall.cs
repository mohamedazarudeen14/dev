using System.Collections.Generic;
using BillingApplicationUserInterface.CustomerService;
using BillingApplicationUserInterface.AdminService;

namespace BillingApplicationUserInterface
{
    public class ServiceCall
    {
        CustomerServiceClient customerService = new CustomerServiceClient();
        AdminServiceClient adminService = new AdminServiceClient();
        public List<CustomerService.ProductDetail> AvailableProductsServiceCall()
        {
            if(customerService != null)
            {
                return customerService.GetAllProducts();
            }
            return new List<CustomerService.ProductDetail>();         
        }

        public List<CustomerService.PurchaseProductDetail> CustomerPurchasedProductDetails()
        {
            if(customerService != null)
            {
                return customerService.PurchasedProducts();
            }
            return new List<CustomerService.PurchaseProductDetail>();
        }

        public List<CustomerService.PurchaseProductDetail> FinalBillingForCustomer()
        {
            if(customerService != null)
            {
                return customerService.FinalBillForCurrentCustomer();
            }
            return new List<CustomerService.PurchaseProductDetail>();
        }

        public List<CustomerService.PurchaseProductDetail> DeleteProductsFromCurrentBill(int productID)
        {
            if(customerService != null)
            {
                return customerService.DeleteProductFromCurrentPurchase(productID);
            }
            return new List<CustomerService.PurchaseProductDetail>();
        }

        public List<CustomerService.PurchaseProductDetail> CurrentProductsPurchasedDetails(string customerChoice, int productID, int quantity, string customerName)
        {
            if (customerService != null)
            {
                return customerService.CurrentCustomerPurchasedDetails(customerChoice,productID,quantity,customerName);
            }
            return new List<CustomerService.PurchaseProductDetail>();
        }

        public List<CustomerService.ProductDetail> AvailableProductsAfterCurrentPurchase()
        {
            if(customerService!= null)
            {
                return customerService.AvailableProductsAfterCurrentPurchase();
            }
            return new List<CustomerService.ProductDetail>();
        }

        public string UserValidation(int userID, string password)
        {
            if(adminService != null)
            {
                return adminService.AdminValidation(userID, password);
            }
            return string.Empty;
        }

        public List<AdminService.ProductDetail> ProductsAvailableInStore()
        {
            if (adminService != null)
            {
                return adminService.AvailableProductsInStore();
            }
            return new List<AdminService.ProductDetail>();
        }

        public string NewProductsAdditionToStore(AdminService.ProductDetail productDetails)
        {
            if(adminService != null)
            {
               return adminService.NewProductsAddedByAdmin(productDetails);
            }
            return string.Empty;
        }

        public void DetailsOfNewProductAddition(int userID, AdminService.ProductDetail productDetails)
        {
            if(adminService != null)
            {
                adminService.DetailsOfNewProductsAddedToStore(userID, productDetails);
            }
        }

        public List<AdminService.ProductDetail> CurrentProductsAfterAdditionToStore()
        {
            if(adminService != null)
            {
                return adminService.AvailableProductsInStore();
            }
            return new List<AdminService.ProductDetail>();
        }

    }
}
