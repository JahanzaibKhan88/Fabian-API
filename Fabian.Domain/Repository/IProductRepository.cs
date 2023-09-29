using Fabian.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabian.Domain.Repository
{
    public interface IProductRepository
    {
         Product? GetProductById(Guid productId);
         Product? GetProductByName(string name);
         Product? GetProductBySku(int sku);
         List<Product> GetAllActiveProducts();
         List<Product> GetAllProducts();
         Product? RemoveProduct(Guid productId);
         Product AddNewProduct(Product product);
         Product? UpdateProduct(Product product);
    }
}
