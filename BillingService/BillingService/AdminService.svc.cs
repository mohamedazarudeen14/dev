using System.Collections.Generic;
using CommonClasses;
using data = DataRetrivingForBillingApplication;

namespace BillingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService.svc or AdminService.svc.cs at the Solution Explorer and start debugging.
    public class AdminService : IAdminService
    {
        data.AdminAccessPage adminAccessPage = new data.AdminAccessPage();

        public List<ProductDetail> AvailableProductsInStore()
        {
            return adminAccessPage.productsDetailsForAdmin();
        }

        public string AdminValidation(int userID, string password)
        {
            return adminAccessPage.AccessingProducts(userID, password);
        }

        public string NewProductsAddedByAdmin(ProductDetail productsAddingDetails)
        {
            return adminAccessPage.productAdditionToStore(productsAddingDetails);
        }

        public void DetailsOfNewProductsAddedToStore(int userID, ProductDetail productsAdded)
        {
            adminAccessPage.adminProductChange(userID, productsAdded);
        }
    }
}
