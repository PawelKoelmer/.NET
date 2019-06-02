using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Projekt.Validation
{
    public class UserNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var regex = @"^[A-Z]";
                var match = Regex.Match(value.ToString(), regex);

                if (!match.Success)
                {
                    return new ValidationResult("Imię piszemy z dużej litery");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Pole Imię nie może być puste");
        }
    }
    public class UserLastNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var regex = @"^[A-Z]";
                var match = Regex.Match(value.ToString(), regex);

                if (!match.Success)
                {
                    return new ValidationResult("Nazwisko piszemy z dużej litery");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Pole Nazwisko nie może być puste");
        }
    }
    public class UserEmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var regex = @"^[a-zA-Z.]*@[a-zA-z]*[.][a-z]{3}";
                var match = Regex.Match(value.ToString(), regex);

                if (!match.Success)
                {
                    return new ValidationResult("Niepoprawny email");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Pole Email nie może być puste");
        }
    }
    public class UserZipCodeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           if(value!= null)
            {

           
                var regex = @"^[0-9]{2}[-][0-9]{3}";
                var match = Regex.Match(value.ToString(), regex);

                if (!match.Success)
                {
                    return new ValidationResult("Niepoprawny kod pocztowy");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Brak kodu pocztowego");
        }
    }
}