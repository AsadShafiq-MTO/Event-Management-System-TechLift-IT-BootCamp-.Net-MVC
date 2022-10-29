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
    using System.ComponentModel.DataAnnotations;

    public partial class HallBooking
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Please Enter Hall Name")]
        [Display(Name = "Hall Name")]
        public string HallName { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Please Enter Event Name")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Event Date")]
        [Required(ErrorMessage = "Please Enter Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string EventDate { get; set; }

        [Display(Name = "Booking Date")]
        [Required(ErrorMessage = "Please Enter Booking Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string BookingDate { get; set; }

        [Display(Name = "Total Payment")]
        [Required(ErrorMessage = "Please Enter Total Payment")]
        public Nullable<int> TotalPayment { get; set; }

        [Display(Name = "Addvance Payment")]
        [Required(ErrorMessage = "Please Enter Addvance Payment")]
        public Nullable<int> AddvancePayment { get; set; }

        [Display(Name = "Number 0f Guest")]
        [Required(ErrorMessage = "Please Enter Number 0f Guest")]
        public Nullable<int> No0fAudience { get; set; }
        public int Service_id { get; set; }
        public string User_ID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Services Services { get; set; }
    }
}
