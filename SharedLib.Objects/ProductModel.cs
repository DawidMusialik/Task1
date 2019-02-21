using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib.Objects
{
    [Table("Product", Schema = "Task")]
    public class ProductModel: ProductAbstract 
    {
        [Key]
        public override Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public override string Name { get; set; }

        [Required]
        public override decimal Price { get; set; }
    }
}
