using System.Collections.Generic;
using System.Linq;
using CommonClasses;

namespace DataAccessForBillingApplication
{
    public class AdminDataSection
    {
        public List<AdminLoginDetail> AccessUserCredentials()
        {
            using (DataEntitiesForBilling entities = new DataEntitiesForBilling())
            {
                entities.SaveChanges();
                return entities.AdminLoginDetails.ToList();               
            }

        }       
    }
}
