using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantSystem.ViewModels.RestaurantTables
{
    public class EditRestaurantTableViewModel : AEditViewModel<RestaurantTable>
    {
        private readonly int id;
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

        public EditRestaurantTableViewModel(RestaurantTable restaurantTable)
            : base()
        {
            this.id = restaurantTable.Id;
            this.name = restaurantTable.Name;
            this.description = restaurantTable.Description;
            this.photoUrl = restaurantTable.PhotoUrl;
            //this.maxCapacity = restaurantTable.maxCapacity;
        }

        public override RestaurantTable SetItem()
        {
            return new RestaurantTable
            {
                Id = this.id,
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
