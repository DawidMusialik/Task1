using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib.Objects
{
    [Table("Product", Schema = "Task")]
    public class ProductModel: ProductAbstract 
    {
        [Key]
        public override Guid Id { get; set; }

        public override string Name { get; set; }

        public override decimal Price { get; set; }
    }
}
