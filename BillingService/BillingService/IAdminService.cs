using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BillingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        List<ProductDetail> AvailableProductsInStore();

        [OperationContract]
        string AdminValidation(int userID, string password);

        [OperationContract]
        string NewProductsAddedByAdmin(ProductDetail productsAddingDetails);

        [OperationContract]
        void DetailsOfNewProductsAddedToStore(int userID, ProductDetail productsAdded);
    }
}
