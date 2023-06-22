using RestaurantSystem.Service.Reference;
using RestaurantSystem.ViewModels.Abstract;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Products
{
    public class AddProductViewModel : ANewViewModel<Product>
    {
        private string name;
        private string description;
        private string photoUrl;
        private int categoryId;
        private double unitPriceGross;
        private int vat;
        private int unitsInStock;

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

        public int CategoryId
        {
            get => categoryId;
            set => SetProperty(ref categoryId, value);
        }

        public double UnitPriceGross
        {
            get => unitPriceGross;
            set => SetProperty(ref unitPriceGross, value);
        }

        public int Vat
        {
            get => vat;
            set => SetProperty(ref vat, value);
        }

        public int UnitsInStock
        {
            get => unitsInStock;
            set => SetProperty(ref unitsInStock, value);
        }
        public AddProductViewModel()
            : base()
        {
        }

        public override Product SetItem()
        {
            return new Product
            {
                Name = this.name,
                Description = this.description,
                PhotoUrl = this.photoUrl,
                CategoryID = this.categoryId,
                UnitPriceGross = this.UnitPriceGross,
                Vat = this.Vat,
                UnitsInStock = this.UnitsInStock,
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(description);
        }

        public override async void BackToMainPageWithEntities()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
