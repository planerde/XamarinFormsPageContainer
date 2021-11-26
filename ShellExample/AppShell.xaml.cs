using System;
using System.Collections.Generic;
using ShellExample.ViewModels;
using ShellExample.Views;
using Xamarin.Forms;

namespace ShellExample
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
