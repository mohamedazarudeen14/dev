using System;

namespace BillingApplicationUserInterface
{
    public class BillingMainPage
    {
        public volatile int selection;

        public void startingPage()
        {
            try
            {
                Console.WriteLine("Enter Your Selection");
                Console.WriteLine("1.PURCHASE");
                Console.WriteLine("2.ADMIN");
                selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        CustomerSection customerSection = new CustomerSection();
                        customerSection.availableProducts();
                        customerSection.productSelection();                        
                        break;

                    case 2:
                        AdminSection adminSection = new AdminSection();
                        adminSection.AdminCheck();
                        break;

                    default:
                        Console.WriteLine("wrong selection");
                        startingPage();

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Action Not Valid!...Do proper selection" + ex.Message);
                startingPage();
            }
        }
    }
}
