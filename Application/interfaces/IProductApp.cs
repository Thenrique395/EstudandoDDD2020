using Entities.Entities;
using System.Threading.Tasks;

namespace ApplicationApp.interfaces.Generics
{
    public interface IProductApp: IGenericApp<Product>
    {
        Task UpdateProduct(Product product);
        Task AddProduct(Product product);
    }
}
