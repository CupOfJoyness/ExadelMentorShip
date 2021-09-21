using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace BusinessLayer
{
    public class CityInfo
    {
        [Required]
        public string CityName { get; set; }
    }
}
