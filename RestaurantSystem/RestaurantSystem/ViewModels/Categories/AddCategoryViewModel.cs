using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;

namespace RestaurantSystem.ViewModels.Categories
{
    public class AddCategoryViewModel : ANewViewModel<AddCategoryCommand>
    {
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

        public AddCategoryViewModel()
            : base()
        {
        }

        public override AddCategoryCommand SetItem()
        {
            return new AddCategoryCommand
            {
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
