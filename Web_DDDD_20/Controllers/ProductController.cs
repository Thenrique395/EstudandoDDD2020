using ApplicationApp.interfaces.Generics;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Web_DDDD_20.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApp _productApp;

        public ProductController(IProductApp productApp)
        {
            _productApp = productApp;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productApp.List());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Preco,Ativo,Nome")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productApp.AddProduct(product);
                if (product.notitycoes.Any())
                {
                    foreach (var item in product.notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    return View("Create", product);
                }
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productApp.GetEntityById((int)id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productApp.GetEntityById((int)id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Preco,Ativo,Id,Nome")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productApp.UpdateProduct(product);
                    if (product.notitycoes.Any())
                    {
                        foreach (var item in product.notitycoes)
                        {
                            ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                        }
                        return View("Edit", product);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists((int)product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(product);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productApp.GetEntityById((int)id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productApp.GetEntityById(id);
            await _productApp.Delete(product);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var product = await _productApp.GetEntityById(id);
            if (product == null)
            {
                return false;
            }
            return true;
        }


    }
}
