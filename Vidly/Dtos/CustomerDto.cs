using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto { 
        public int Id { get; set; }

        [Required] //col no longer nullable and override default validation message
        [StringLength(255)] //specify max string length
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; } //MembershipTypeId is required by default because type is byte, not nullable byte (i.e., byte?)

        [BirthDateRequiredIfMember]
        public string BirthDate { get; set; }
    }
}