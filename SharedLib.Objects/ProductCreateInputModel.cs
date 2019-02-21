using System.ComponentModel.DataAnnotations;

namespace SharedLib.Objects
{
    public class ProductCreateInputModel: ProductAbstract
    {

        [Required(ErrorMessage = "Product must have name")]
        [StringLength(100, ErrorMessage = "Name of product max lenght is 100")]
        public override string Name { get; set; }

        [Required(ErrorMessage = "Product must have price")]
        public override decimal Price { get; set; }
    }
}
