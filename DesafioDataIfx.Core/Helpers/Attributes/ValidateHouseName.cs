using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioDataIfx.Core.Helpers.Attributes
{
    public class ValidateHouseName : ValidationAttribute
    {
        private List<string> AvailableHouses = new List<string> { "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            

            if (AvailableHouses?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Solo se permiten las siguientes opciones: {string.Join(", ", (AvailableHouses))}";
            return new ValidationResult(msg);
        }
    }
}
