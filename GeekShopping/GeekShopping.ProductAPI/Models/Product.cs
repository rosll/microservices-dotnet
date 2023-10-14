using GeekShopping.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name"), StringLength(150), Required]
        public string Name { get; set; }

        [Column("price"), Range(1, 10000), Required]
        public decimal Price { get; set; }

        [Column("description"), StringLength(500)]
        public string Description { get; set; }

        [Column("category"), StringLength(50)]
        public string Category { get; set; }

        [Column("image_url"), StringLength(300)]
        public string ImageURL { get; set; }
    }
}
