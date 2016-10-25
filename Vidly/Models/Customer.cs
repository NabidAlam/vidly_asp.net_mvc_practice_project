using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter customer's name")] //col no longer nullable and override default validation message
        [StringLength(255)] //specify max string length
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage ="Please select a membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //MembershipTypeId is required by default because type is byte, not nullable byte (i.e., byte?)

        [Display(Name = "Date of Birth")]
        [BirthDateRequiredIfMember]
        public string BirthDate { get; set; }
    }
}