using RestaurantSystem.Service.Reference;
using RestaurantSystem.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.Services
{
    public class ProductsDataStore : AListDataStore<Product>
    {
        public ProductsDataStore()
            : base()
        {
        }

        public override async Task AddItemToService(Product item)
        {
            await _service.Products2Async(new AddProductCommand
            {
                Name = item.Name,
                Description = item.Description,
                PhotoUrl = item.PhotoUrl,
                CategoryID = item.CategoryID,
                UnitPriceGross = item.UnitPriceGross,
                Vat = item.Vat,
                UnitsInStock = item.UnitsInStock
            });
        }

        public override async Task DeleteItemFromService(Product item)
        {
            await _service.Products5Async(item.Id);
        }

        public override async Task<Product> Find(Product item)
        {
            var tmp = await _service.Categories4Async(item.Id);
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                PhotoUrl = item.PhotoUrl,
                CategoryID = item.CategoryID,
                UnitPriceGross = item.UnitPriceGross,
                Vat = item.Vat,
                UnitsInStock = item.UnitsInStock
            };
        }

        public override async Task<Product> Find(int id)
        {
            var tmp = await _service.Products4Async(id);
            return new Product
            {
                Id = tmp.Product.Id,
                Name = tmp.Product.Name,
                Description = tmp.Product.Description,
                PhotoUrl = tmp.Product.PhotoUrl,
                CategoryID = tmp.Product.CategoryID,
                UnitPriceGross = tmp.Product.UnitPriceGross,
                Vat = tmp.Product.Vat,
                UnitsInStock = tmp.Product.UnitsInStock
            };
        }

        public override async Task RefreshListFromService()
        {
            var tmp = _service.ProductsAsync(new GetProducts()).Result.Products;
            items = tmp.Select(item => new Product
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                PhotoUrl = item.PhotoUrl,
                CategoryID = item.CategoryID,
                UnitPriceGross = item.UnitPriceGross,
                Vat = item.Vat,
                UnitsInStock = item.UnitsInStock
            }).ToList();
        }

        public override async Task UpdateItemInService(Product item)
        {
            await _service.Products3Async(new UpdateProductCommand
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                PhotoUrl = item.PhotoUrl,
                CategoryID = item.CategoryID,
                UnitPriceGross = item.UnitPriceGross,
                Vat = item.Vat,
                UnitsInStock = item.UnitsInStock
            });
        }
    }
}
