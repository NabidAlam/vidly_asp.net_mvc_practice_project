using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class BirthDateRequiredIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else { 
                if(customer.BirthDate == null)
                {
                    return new ValidationResult("Birthdate is required if going on a membership.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

        }
    }
}