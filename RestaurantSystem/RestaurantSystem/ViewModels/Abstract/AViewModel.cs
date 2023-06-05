using Xamarin.Forms;

namespace RestaurantSystem.ViewModels.Abstract
{
    public class AViewModel<T> where T : class
    {
        public T DataStore => DependencyService.Get<T>();
    }
}
