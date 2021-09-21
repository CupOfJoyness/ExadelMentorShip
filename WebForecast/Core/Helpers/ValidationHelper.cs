using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Helpers
{
    public static class ValidationHelper
    {
        public static void Validate(object objectToValidate)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(objectToValidate);

            if (!Validator.TryValidateObject(objectToValidate, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

        }
    }
}
