//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommonClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserLoggedInDetail
    {
        public int SI_No { get; set; }
        public int UserID { get; set; }
        public System.DateTime LoggedInTime { get; set; }
    
        public virtual UserLoginCredential UserLoginCredential { get; set; }
    }
}
