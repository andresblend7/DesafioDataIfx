using DesafioDataIfx.Core.Helpers.Attributes;
using DesafioDataIfx.Core.ModelStructure.Dictionaries;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioDataIfx.Core.ModelStructure.App
{
    /// <summary>
    /// Modelo de petición para unirse a una casa
    /// </summary>
    public class HouseRequest
    {
        [Required]
        [MaxLength(20, ErrorMessage = "La longitud máxima permita es de 20 carácteres")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Solo es permitido usar letras")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "La longitud máxima permita es de 20 carácteres")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Solo es permitido usar letras")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 9999999999, ErrorMessage = "La longitud máxima permita es de 10 dígitos")]
        public int Id { get; set; }
        
        [Required]
        [Range(1, 99, ErrorMessage = "Solo se permite un rago de edad de 1 a 99")]
        public int Age { get; set; }

        [Required]
        [ValidateHouseName]
        public string House { get; set; }

        [JsonIgnore]
        public int HouseId { get; set; }
    }
}
