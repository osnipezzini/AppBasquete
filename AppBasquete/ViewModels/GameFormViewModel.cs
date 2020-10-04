using AppBasquete.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBasquete.ViewModels
{
    class GameFormViewModel : BaseViewModel
    {
        private DateTime date;
        private int placar;
        private Player player;
        public ObservableCollection<Player> Players { get; }
        public Command<Game> SaveCommand { get; }
        public GameFormViewModel()
        {
            Title = "Cadastro de jogo";
            SaveCommand = new Command<Game>(OnSaveCommand, CanSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Date = DateTime.Today;
            Players = new ObservableCollection<Player>();
            Task.Run(async () => await LoadPlayers());
        }

        private bool CanSave(Game arg)
        {
            return placar >= 0 && placar <= 1000 && player != null;
        }
        private async Task LoadPlayers()
        {
            foreach (Player obj in await PlayerStore.GetItemsAsync())
            {
                Players.Add(obj);
            }
        }
        private async void OnSaveCommand(Game obj)
        {
            var game = new Game()
            {
                Id = Guid.NewGuid().ToString(),
                Date = date,
                PlayerId = player.Id,
                Placar = placar
            };
            var games = await GamesStore.GetItemsAsync();
            
            if (games.Count() > 0)
            {
                int maxRecord = games.Max(x => x.Placar);
                int minRecord = games.Min(x => x.Placar);
                int minQuebra = games.Last().MinRecordBroken;
                int maxQuebra = games.Last().MaxRecordBroken;
                if (placar > maxRecord)
                {
                    game.MaxRecord = placar;
                    game.MaxRecordBroken = maxQuebra + 1;
                }
                else
                {
                    game.MaxRecord = maxRecord;
                    game.MaxRecordBroken = maxQuebra;
                }

                if (placar < minRecord)
                {
                    game.MinRecord = placar;
                    game.MinRecordBroken = minQuebra + 1;
                }
                else
                {
                    game.MinRecord = minRecord;
                    game.MinRecordBroken = minQuebra;
                }
            }
            else
            {
                game.MaxRecord = placar;
                game.MaxRecordBroken = 0;
                game.MinRecord = placar;
                game.MinRecordBroken = 0;
            }
            try
            {
                await GamesStore.AddItemAsync(game);
                await Shell.Current.DisplayAlert("Sucesso", "Jogo adicionado com sucesso", "OK");
                Placar = 0;
                Player = null;
                Date = DateTime.Today;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                await Shell.Current.DisplayAlert("ERRO FATAL", "Não foi possível salvar os dados", "OK");
            }
            
        }

        public Player Player { get => player; set => SetProperty(ref player, value); }
        public DateTime Date { get => date; set => SetProperty(ref date, value); }
        public int Placar { get => placar; set => SetProperty(ref placar, value); }
    }
}
