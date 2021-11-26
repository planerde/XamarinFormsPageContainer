using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellExample.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.SizeChanged += Page_SizeChanged;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.SizeChanged -= Page_SizeChanged;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            AdaptLayout();
        }

        private void Page_SizeChanged(object sender, EventArgs e)
        {
            AdaptLayout();
        }

        private void AdaptLayout()
        {
            string visualState = (Device.Idiom == TargetIdiom.Tablet && Width > Height) ? "Landscape" : "Portrait";

            VisualStateManager.GoToState(MainContent, visualState);
        }
    }
}