using System.ComponentModel.DataAnnotations;

namespace GlamTreasures.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Description { get; set; }

        public ICollection<JewelryItem>? JewelryItems { get; set; }
    }
}