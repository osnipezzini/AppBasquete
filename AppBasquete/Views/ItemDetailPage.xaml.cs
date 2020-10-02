using System.ComponentModel;
using Xamarin.Forms;
using AppBasquete.ViewModels;

namespace AppBasquete.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}