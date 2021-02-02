using Entities.Entities;
using System.Threading.Tasks;

namespace Domain.interfaces.interfaceServices
{
    public interface IServiceProduct
    {
        Task UpdateProduct(Product product);
        Task AddProduct(Product product);

    }
}
