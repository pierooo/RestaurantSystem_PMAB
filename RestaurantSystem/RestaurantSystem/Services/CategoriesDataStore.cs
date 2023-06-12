using RestaurantSystem.Service.Reference;
using RestaurantSystem.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.Services
{
    public class CategoriesDataStore : AListDataStore<Category>
    {
        public CategoriesDataStore()
            : base()
        {
        }

        public override async Task AddItemToService(Category item)
        {
            await _service.Categories2Async(new AddCategoryCommand
            {
                Name = item.Name,
                Description = item.Description,
                PhotoUrl = item.PhotoUrl,
            });
        }

        public override async Task DeleteItemFromService(Category item)
        {
            await _service.Categories5Async(item.Id);
        }

        public override async Task<Category> Find(Category item)
        {
            var tmp = await _service.Categories4Async(item.Id);
            return new Category
            {
                Name = tmp.Category.Name,
                Description = tmp.Category.Description,
                PhotoUrl = tmp.Category.PhotoUrl,
            };
        }

        public override async Task<Category> Find(int id)
        {
            var tmp = await _service.Categories4Async(id);
            return new Category
            {
                Name = tmp.Category.Name,
                Description = tmp.Category.Description,
                PhotoUrl = tmp.Category.PhotoUrl,
            };
        }

        public override async Task RefreshListFromService()
        {
            var tmp = _service.CategoriesAsync(new GetCategories()).Result.Categories;
            items = tmp.Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PhotoUrl = x.PhotoUrl
            }).ToList();
        }

        public override async Task UpdateItemInService(Category item)
        {
            await _service.Categories3Async(new UpdateCategoryCommand
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                PhotoUrl = item.PhotoUrl,
            });
        }
    }
}
