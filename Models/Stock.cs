using System.ComponentModel.DataAnnotations;

namespace stockValues_backend.Models
{
    public class Stock
    {
        [Key]
        public string Name { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Market { get; set; }
        
        [Required]
        public string Hours { get; set; }
    }
}