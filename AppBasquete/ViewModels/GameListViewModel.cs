using AppBasquete.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBasquete.ViewModels
{
    class GameListViewModel : BaseViewModel
    {
        public Command RefreshCommand { get; }
        public ObservableCollection<Game> Games { get; }
        public GameListViewModel()
        {
            Title = "Lista de jogos";
            Games = new ObservableCollection<Game>();
            RefreshCommand = new Command(async () => await LoadGames());
        }

        private async Task LoadGames()
        {
            Games.Clear();
            IsBusy = true;
            var games = await GamesStore.GetItemsAsync();
            foreach (Game game in games)
            {
                Games.Add(game);
            }
            IsBusy = false;
        }
    }
}
