using Fabian.Application.Services.LoggerService;
using Fabian.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ILoggerService _loggerService;
        public ProductController(IProductRepository productRepository, ILoggerService loggerService)
        {
            _productRepository = productRepository;
            _loggerService = loggerService;
        }


        [HttpGet]
        [Route("getProductById")]
        public IActionResult GetProductById(Guid productId)
        {
            try
            {
                _loggerService.LogInformation("START GET getProductById");
                var product = _productRepository.GetProductById(productId);
                if(product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch(Exception ex)
            {
                _loggerService.LogError(ex, "ERROR GET getProductById");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END GET getProductById");
            }
        }


        [HttpGet]
        [Route("getProductByName")]
        public IActionResult GetProductByName(string name)
        {
            try
            {
                _loggerService.LogInformation("START GET getProductByName");
                var product = _productRepository.GetProductByName(name);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR GET getProductByName");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END GET getProductByName");
            }
        }


        [HttpGet]
        [Route("getProductBySku")]
        public IActionResult GetProductBySku(int sku)
        {
            try
            {
                _loggerService.LogInformation("START GET getProductBySku");
                var product = _productRepository.GetProductBySku(sku);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR GET getProductBySku");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END GET getProductBySku");
            }
        }


        [HttpGet]
        [Route("getAllActiveProducts")]
        public IActionResult GetAllActiveProducts()
        {
            try
            {
                _loggerService.LogInformation("START GET getAllActiveProducts");
                var products = _productRepository.GetAllActiveProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR GET getAllActiveProducts");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END GET getAllActiveProducts");
            }
        }


        [HttpGet]
        [Route("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                _loggerService.LogInformation("START GET getAllProducts");
                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR GET getAllProducts");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END GET getAllProducts");
            }
        }


        [HttpDelete]
        [Route("removeProduct")]
        public IActionResult RemoveProduct(Guid productId)
        {
            try
            {
                _loggerService.LogInformation("START DELETE removeProduct");
                var product = _productRepository.RemoveProduct(productId);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR DELETE removeProduct");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END DELETE removeProduct");
            }
        }


        [HttpPost]
        [Route("addNewProduct")]
        public IActionResult AddNewProduct(Domain.Entities.Product product)
        {
            try
            {
                _loggerService.LogInformation("START POST addNewProduct");
                var prod = _productRepository.AddNewProduct(product);
                return Ok(prod);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR POST addNewProduct");
                return StatusCode(403);
            }
            finally
            {
                _loggerService.LogInformation("END POST addNewProduct");
            }
        }

        [HttpPut]
        [Route("updateProduct")]
        public IActionResult UpdateProduct(Domain.Entities.Product product)
        {
            try
            {
                _loggerService.LogInformation("START PUT updateProduct");
                var prod = _productRepository.UpdateProduct(product);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(prod);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex, "ERROR PUT updateProduct");
                return StatusCode(500);
            }
            finally
            {
                _loggerService.LogInformation("END PUT updateProduct");
            }
        }
    }
}
