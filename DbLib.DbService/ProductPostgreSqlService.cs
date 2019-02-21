using System;
using System.Collections.Generic;
using System.Linq;
using DbLib.DbPostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using SharedLib.Objects;

namespace DbLib.DbService
{
    public class ProductPostgreSqlService : IProductService
    {

        public bool DeleteProduct(Guid id)
        {
            using (var context = new PostgreSqlContext())
            {
                var itemToDelete = context.Product.Where(x => x.Id == id).FirstOrDefault();

                if (itemToDelete != null)
                {
                    context.Product.Remove(itemToDelete);
                    context.SaveChanges();

                    return true;
                }
                else return false;
            }
        }

        public ProductModel GetProduct(Guid id)
        {
            using (var context = new PostgreSqlContext())
            {
                var test = context.Product.Where(x => x.Id == id).FirstOrDefault();
                return context.Product.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            using (var context = new PostgreSqlContext())
            {
                var test = context.Product.ToListAsync().Result;
                return context.Product.ToListAsync().Result;
            }
        }

        public ProductModel InserProduct(ProductModel product)
        {
            using (var context = new PostgreSqlContext())
            {
                context.Product.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        public ProductModel UpdateProduct(ProductModel product)
        {
            using (var context = new PostgreSqlContext())
            {
                var oryginalProduct = context.Product.Where(x=>x.Id == product.Id).FirstOrDefault();

                if (oryginalProduct != null)
                {
                    context.Entry(oryginalProduct).CurrentValues.SetValues(product);
                    context.SaveChanges();
                    return product;
                }
                else return null;
            }
        }
    }
}
