using RestaurantSystem.Services.Abstract;
using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Abstract
{
    public abstract class ANewViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public ANewViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public abstract bool ValidateSave();
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public abstract void BackToMainPageWithEntities();
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            BackToMainPageWithEntities();
        }
        public abstract T SetItem();
        private async void OnSave()
        {
            await DataStore.AddItemAsync(SetItem());
            // This will pop the current page off the navigation stack
            BackToMainPageWithEntities();
        }
    }
}