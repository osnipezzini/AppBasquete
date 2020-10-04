using AppBasquete.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBasquete.ViewModels
{
    class PlayerListViewModel : BaseViewModel
    {
        private Player selectedPlayer;
        public ObservableCollection<Player> Players { get; set; }
        public Command RefreshCommand { get; }
        public PlayerListViewModel()
        {
            Title = "Lista de jogadores";
            RefreshCommand = new Command(async () => await Load());
            Players = new ObservableCollection<Player>();
            Task.Run(async () => await Load());
        }

        public Player SelectedPlayer { get => selectedPlayer; set => SetProperty(ref selectedPlayer, value); }
        public async Task Load()
        {
            IsBusy = true;
            var players = await PlayerStore.GetItemsAsync();
            foreach (Player player in players)
            {
                Players.Add(player);
            }
            IsBusy = false;
        }
    }
}