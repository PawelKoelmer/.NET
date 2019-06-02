using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Validation
{
    public class ProductNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                return ValidationResult.Success;
            }  
            return new ValidationResult("Nazwa nie może być pusta");
        }
    }
    public class ProductPriceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Decimal.Parse(value.ToString()) > 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Wartość musi być większa od 0");
                }
                
            }
            return new ValidationResult("Cena nie może być pusta");
        }
    }

    
}
