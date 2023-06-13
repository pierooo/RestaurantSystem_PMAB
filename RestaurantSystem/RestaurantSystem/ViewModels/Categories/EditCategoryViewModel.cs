using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;

namespace RestaurantSystem.ViewModels.Categories
{
    public class EditCategoryViewModel : AEditViewModel<Category>
    {
        private readonly int id;
        private string name;
        private string description;
        private string photoUrl;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string PhotoUrl
        {
            get => photoUrl;
            set => SetProperty(ref photoUrl, value);
        }

        public EditCategoryViewModel(Category category)
            : base()
        {
            this.id = category.Id;
            this.name = category.Name;
            this.description = category.Description;
            this.photoUrl = category.PhotoUrl;
        }

        public override Category SetItem()
        {
            return new Category
            {
                Id = this.id,
                Name = this.name,
                Description = this.description,
                PhotoUrl = this.photoUrl,
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(description);
        }
    }
}
