using System.Collections.Generic;
using System.Linq;
using CommonClasses;
using Data = DataAccessForBillingApplication;

namespace DataRetrivingForBillingApplication
{
    public class AdminAccessPage
    {
        Data.AdminDataSection AccessingCredentials = new Data.AdminDataSection();
        Data.DataHandling dataHandling = new Data.DataHandling();
        public string AccessingProducts(int userID, string password)
        {
            List<CommonClasses.AdminLoginDetail> userCredentials = AccessingCredentials.AccessUserCredentials();
            foreach(CommonClasses.AdminLoginDetail credentials in userCredentials)
            {
                if(credentials.userID == userID && credentials.password == password)
                {
                    return "YES";
                }
            }
            return "NO";
            
        }

        public List<ProductDetail> productsDetailsForAdmin()
        {
            return dataHandling.productRetrieval().ToList();
        }

        public string productAdditionToStore(CommonClasses.ProductDetail productsAddingDetails)
        {
            if (string.IsNullOrEmpty(productsAddingDetails.productName))
            {
                return "Product Name Should Not Be Empty";

            }
            else if (productsAddingDetails.price == 0)
            {
                return "Price Should Not Be Zero";

            }
            else if (productsAddingDetails.quantity == 0)
            {
                return "Quantity Should Not Be Zero";

            }
            else
            {
                dataHandling.productAdding(productsAddingDetails);
                return "Product Added SuccessFully";
            }           
        }

        public void adminProductChange(int userID, CommonClasses.ProductDetail productsAdded)
        {
            CommonClasses.AdminProductChanx adminAdded = new CommonClasses.AdminProductChanx();
            List<ProductDetail> listOfProducts = dataHandling.productRetrieval();
            foreach (ProductDetail productsInStore in listOfProducts)
            {
                if (productsInStore.productName.Equals(productsAdded.productName))
                {
                    adminAdded.productID = productsInStore.productID;
                }
            }
            adminAdded.userID = userID;
            adminAdded.productName = productsAdded.productName;
            adminAdded.price = productsAdded.price;
            adminAdded.quantity = productsAdded.quantity;
            dataHandling.adminChanges(adminAdded);
        }

           
    }
}
