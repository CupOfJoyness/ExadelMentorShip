using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class CityInfo
    {
        [Required]
        public string CityName { get; set; }
    }
}