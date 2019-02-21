using SharedLib.Objects;
using System;
using System.Collections.Generic;

namespace DbLib.DbService
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProduct(Guid id);
        ProductModel InserProduct(ProductModel product);
        ProductModel UpdateProduct(ProductModel product);
        bool DeleteProduct(Guid id);
    }
}
