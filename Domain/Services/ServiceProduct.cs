using Domain.interfaces.interfaceProduct;
using Domain.interfaces.interfaceServices;
using Entities.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _product;

        public ServiceProduct(IProduct product)
        {
            _product = product;
        }

        public async Task AddProduct(Product product)
        {
            var validarNome = product.ValidarPropriedadeString(product.Nome, "Nome");
            var validarPreco = product.ValidarPropriedadeDecimal(product.Preco, "Preco");

            if (validarNome && validarPreco)
            {
                product.Ativo = true;
                await _product.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validarNome = product.ValidarPropriedadeString(product.Nome, "Nome");
            var validarPreco = product.ValidarPropriedadeDecimal(product.Preco, "Preco");

            if (validarNome && validarPreco)
            {
                await _product.Update(product);
            }
        }
    }
}
