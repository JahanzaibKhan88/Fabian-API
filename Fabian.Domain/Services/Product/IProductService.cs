using Fabian.Domain.Entities;

namespace Fabian.Domain.Services.Product
{
    public interface IProductService
    {
        bool ValidateProductSku(string productSku);
    }
}
