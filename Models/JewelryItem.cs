using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamTreasures.Models
{
    public class JewelryItem
    {
        public int ID { get; set; }

        [Display(Name = "Jewelry Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, 100000.00)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        [Required]
        [StringLength(50)]
        public string Material { get; set; }

        [Display(Name = "In Stock")]
        [Required]
        [Range(0, 1000)]
        public int StockQuantity { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Added Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}