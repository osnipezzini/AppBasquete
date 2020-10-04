using AppBasquete.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace AppBasquete.ViewModels
{
    class PlayerFormViewModel : BaseViewModel
    {

        private string name;
        private string team;
        private DateTime birthday;

        public Command<Player> SaveCommand { get; }
        public PlayerFormViewModel()
        {
            Title = "Cadastro de jogador";
            SaveCommand = new Command<Player>(OnSaveCommand, CanSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Birthday = DateTime.Today;
        }

        private bool CanSave(Player arg)
        {
            var years = DateTime.Today.Year - birthday.Year;
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(team) && years > 16 ;
        }

        private async void OnSaveCommand(Player obj)
        {
            var player = new Player()
            { 
                Id = Guid.NewGuid().ToString(),
                Birthday = birthday,
                Name = name,
                Team = team
            };

            try
            {
                await PlayerStore.AddItemAsync(player);
                await Shell.Current.DisplayAlert("Salvo", "Cadastro salvo com sucesso", "OK");
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                await Shell.Current.DisplayAlert("ERRO", "Ocorreu o seguinte erro ao salvar os dados:\n" + exc.Message, "OK");
            }
            
        }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Team { get => team; set => SetProperty(ref team, value); }
        public DateTime Birthday { get => birthday; set => SetProperty(ref birthday, value); }
    }
}
