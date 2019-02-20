using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Objects
{
    public class ProductAbstract
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
