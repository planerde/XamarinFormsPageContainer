using System.ComponentModel;
using Xamarin.Forms;
using ShellExample.ViewModels;

namespace ShellExample.Views
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
