using AppBasquete.Views;
using System;
using Xamarin.Forms;

namespace AppBasquete
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(GameFormPage), typeof(GameFormPage));
            Routing.RegisterRoute(nameof(GameListPage), typeof(GameListPage));
            Routing.RegisterRoute(nameof(PlayerFormPage), typeof(PlayerFormPage));
            Routing.RegisterRoute(nameof(PlayerListPage), typeof(PlayerListPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
