namespace AppBasquete.ViewModels
{
    class PlayerFormViewModel : BaseViewModel
    {

        private string name;
        private string team;
        public PlayerFormViewModel()
        {
            Title = "Cadastro de jogador";
        }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Team { get => team; set => SetProperty(ref team, value); }
    }
}
