using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;

namespace RestaurantSystem.ViewModels.RestaurantTables
{
    public class AddRestaurantTableViewModel : ANewViewModel<RestaurantTable>
    {
        private string name;
        private string description;
        private string photoUrl;
        private int maxCapacity;


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
        public int MaxCapacity
        {
            get => maxCapacity;
            set => SetProperty(ref maxCapacity, value);
        }

        public AddRestaurantTableViewModel()
            : base()
        {
        }

        public override RestaurantTable SetItem()
        {
            return new RestaurantTable
            {
                Name = this.name,
                Description = this.description,
                PhotoUrl = this.photoUrl,
                MaxCapacity = this.maxCapacity,
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(description);
        }
    }
}
