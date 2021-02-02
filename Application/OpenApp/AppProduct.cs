using ApplicationApp.interfaces.Generics;
using Domain.interfaces.interfaceProduct;
using Domain.interfaces.interfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : IProductApp
    {
        private readonly IProduct _Product;
        private readonly IServiceProduct _ServiceProduct;


        public AppProduct(IProduct product, IServiceProduct ServiceProduct)
        {
            _Product = product;
            _ServiceProduct = ServiceProduct;
        }

        public async Task Add(Product Objeto)
        {
            await _Product.Add(Objeto);
        }



        public async Task Delete(Product Objeto)
        {
            await _Product.Delete(Objeto);
        }

        public async Task<Product> GetEntityById(int? id)
        {
            return await _Product.GetEntityById((int)id);
        }

        public async Task<List<Product>> List()
        {
            return await _Product.List();
        }

        public async Task Update(Product Objeto)
        {
            await _Product.Update(Objeto);
        }

        public async Task AddProduct(Product product)
        {
            await _ServiceProduct.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _ServiceProduct.UpdateProduct(product);
        }
    }
}
