using Microsoft.AspNetCore.Mvc;
using SharedLib.Objects;
using System;
using System.Collections.Generic;

namespace Task1.Interface
{
    public interface IProductController
    {
        IEnumerable<ProductModel> Get();
        ProductModel Get(Guid id);
        Guid? PostFromBody([FromBody] ProductCreateInputModel model);
        void Put([FromBody] ProductUpdateInputModel model);
        void Delete(Guid id);
    }
}
