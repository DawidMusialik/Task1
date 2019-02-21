using System;

namespace SharedLib.Objects
{
    public abstract class ProductAbstract
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
