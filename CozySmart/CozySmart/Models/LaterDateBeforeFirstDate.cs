using CozySmart.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class LaterDateBeforeFirstDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var search = (SearchFormViewModel)validationContext.ObjectInstance;

            if(search.SearchArrival.Day < DateTime.Now.Day)
            {
                return new ValidationResult("Arrival Date must be at least Today");
            }

            int? dateDifference = search.SearchDeparture.Day - search.SearchArrival.Day;

            if ((dateDifference != null) && (dateDifference <= 0))
            {
                return new ValidationResult("Departure Date must be later than Arrival Date");
            }

            return ValidationResult.Success;
        }
    }
}