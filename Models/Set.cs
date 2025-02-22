using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamTreasures.Models
{

    public class Set
    {
        public int ID { get; set; }

        [Display(Name = "Denumire")]
        [StringLength(100)]
        public string Denumire { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, 100000.00)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

    }

}