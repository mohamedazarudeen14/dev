using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ServiceCheck.CustomerService;
using CommonClasses;
using System.Runtime.Serialization;

namespace ServiceCheck
{
    class Program
    {
        static BillingService.CustomerService service = null;
        static List<int> dr = new List<int>();
        static void Main(string[] args)
        {
            //int val = Convert.ToInt32(Console.ReadLine());

            //if(val.Equals(1))
            //{
            //    if(service == null)
            //    {
            //        service = new BillingService.CustomerService();
            //    }
            //    List<ProductDetail> products = service.GetAllProducts();
            //    Main(args);
            //}
            //if(val.Equals(2))
            //{
            //        List<PurchaseProductDetail> purchased = service.PurchasedProducts();

            //}
            dr.Add(5);
            dr.Add(6);
            dr.Add(7);
            dr.Add(8);
            dr.Clear();

            Console.Read();
        }
    }
}
