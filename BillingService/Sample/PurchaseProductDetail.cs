//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sample
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseProductDetail
    {
        public long purchaseProductID { get; set; }
        public string Customer_Name { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int Total_Bill_Amount { get; set; }
        public string Discount_Percentage { get; set; }
        public int Discounted_Amount { get; set; }
        public int Discounted_Bill { get; set; }
    
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
