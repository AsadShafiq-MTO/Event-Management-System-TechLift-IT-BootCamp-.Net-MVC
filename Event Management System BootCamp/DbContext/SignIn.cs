//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Event_Management_System_BootCamp.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class SignIn
    {
        public int id { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public Nullable<bool> RememberMe { get; set; }
    }
}