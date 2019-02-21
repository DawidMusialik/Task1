using System;
using System.Collections.Generic;
using DbLib.DbService;
using Microsoft.AspNetCore.Mvc;
using SharedLib.Objects;
using Task1.Interface;

namespace Task1.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller, IProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _productService.GetProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public ProductModel Get(Guid id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost] //JSON
        public Guid? PostFromBody([FromBody] ProductCreateInputModel model)
        { 
            return ModelState.IsValid  ? _productService.InserProduct(new ProductModel() { Id = model.Id, Name = model.Name, Price = model.Price }).Id : null as Guid?;
        }

        // PUT: api/Product/5
        [HttpPut]
        public void Put([FromBody] ProductUpdateInputModel model)
        {
            if (ModelState.IsValid) _productService.UpdateProduct(new ProductModel() { Id = model.Id, Name = model.Name, Price = model.Price });
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
