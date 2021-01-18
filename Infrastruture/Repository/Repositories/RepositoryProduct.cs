using Domain.interfaces.interfaceProduct;
using Entities.Entities;
using Infrastruture.Repository.Generics;

namespace Infrastruture.Repository.Repositories
{
    public  class RepositoryProduct : GenericRepository<Product> , IProduct
    {
    }
}
