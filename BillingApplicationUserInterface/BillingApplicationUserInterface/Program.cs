using System;

namespace BillingApplicationUserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingMainPage billingMainPage = new BillingMainPage();
            billingMainPage.startingPage();
            Console.Read();
        }
    }
}
