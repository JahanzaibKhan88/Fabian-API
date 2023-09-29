using AutoMapper;
using Fabian.Domain.Entities;
using Fabian.Domain.Repository;
using Fabian.Infrastructure.Models;
using FluentValidation;

namespace Fabian.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FabianContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Models.Product> _validator;
        public ProductRepository(FabianContext context, IMapper mapper, IValidator<Models.Product> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public Domain.Entities.Product? GetProductById(Guid productId)
        {
            var prod = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (prod == null)
            {
                return null;
            }
            return _mapper.Map<Domain.Entities.Product>(prod);

        }
        public Domain.Entities.Product? GetProductByName(string name)
        {
            var prod = _context.Products.FirstOrDefault(product => product.Name == name);
            if (prod == null)
                return null;
            return _mapper.Map<Domain.Entities.Product>(prod);
        }
        public Domain.Entities.Product GetProductBySku(int sku)
        {
            var prod = _context.Products.FirstOrDefault(product => product.Sku == sku);
            if (prod == null)
                return null;
            return _mapper.Map<Domain.Entities.Product>(prod);
        }
        public List<Domain.Entities.Product> GetAllActiveProducts()
        {
            var prods = _context.Products.Where(prod => prod.Active == true).ToList();
            List<Domain.Entities.Product> products = new List<Domain.Entities.Product>();
            foreach (var prod in prods)
            {
                products.Add(_mapper.Map<Domain.Entities.Product>(prod));
            }
            return products;
        }
        public List<Domain.Entities.Product> GetAllProducts()
        {
            var prods = _context.Products.ToList();
            List<Domain.Entities.Product> products = new List<Domain.Entities.Product>();
            foreach (var prod in prods)
            {
                products.Add(_mapper.Map<Domain.Entities.Product>(prod));
            }
            return products;
        }
        public Domain.Entities.Product? RemoveProduct(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(prod => prod.ProductId == productId);
            if (product == null)
                return null;
            _context.Products.Remove(product);
            _context.SaveChanges();
            return _mapper.Map<Domain.Entities.Product>(product);
        }
        public Domain.Entities.Product AddNewProduct(Domain.Entities.Product product)
        {
            var mappedProduct = _mapper.Map<Models.Product>(product);
            var result = _validator.Validate(mappedProduct);
            if (!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors.Select(error => error.ErrorMessage).ToList()));
            }
            _context.Products.Add(mappedProduct);
            _context.SaveChanges();
            return _mapper.Map<Domain.Entities.Product>(mappedProduct);
        }
        public Domain.Entities.Product? UpdateProduct(Domain.Entities.Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate == null)
                return null;
            productToUpdate.Expiry = product.Expiry;
            productToUpdate.Sku = product.Sku;
            productToUpdate.Price = product.Price;
            productToUpdate.Description = product.Description;
            productToUpdate.Active = product.Active;
            productToUpdate.Name = product.Name;
            productToUpdate.Uom = product.Uom;
            var result = _validator.Validate(productToUpdate);
            if(!result.IsValid)
            {
                throw new Exception(string.Join("\n", result.Errors.Select(error => error.ErrorMessage)));
            }
            _context.Products.Update(productToUpdate);
            _context.SaveChanges(); 
            return _mapper.Map<Domain.Entities.Product>(productToUpdate);
        }
    }
}
