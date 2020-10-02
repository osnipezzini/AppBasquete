using AppBasquete.Services;
using Xamarin.Forms;

namespace AppBasquete
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DbDataStore>();
            DependencyService.Register<PlayerDataStore>();
            DependencyService.Register<GameDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
