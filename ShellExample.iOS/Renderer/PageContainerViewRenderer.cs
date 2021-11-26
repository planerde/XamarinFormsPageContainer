using System;
using ShellExample.iOS.Renderer;
using ShellExample.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PageContainerView), typeof(PageContainerViewRenderer))]
namespace ShellExample.iOS.Renderer
{
    public class PageContainerViewRenderer : ViewRenderer<PageContainerView, ViewControllerContainer>
    {
        public PageContainerViewRenderer() { }

        // This method needs to be called from the ExampleApp.iOS AppDelegate so this class doesn't get linked out
        // https://forums.xamarin.com/discussion/comment/198852/#Comment_198852
        public new static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<PageContainerView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ViewController = null;
            }

            if (e.NewElement != null)
            {
                var viewControllerContainer = new ViewControllerContainer();
                SetNativeControl(viewControllerContainer);
            }
        }

        // Displays the Page (or NagivationPage) that is stored in the Content property of the PCV
        private void DisplayPCVContent(Page pageToDisplay)
        {
            pageToDisplay.Parent = Element.GetParentPage();

            var pageRenderer = Platform.GetRenderer(pageToDisplay); // TODO: this is always null. The new page hasn't been rendered yet.

            UIViewController viewController = null;
            if (pageRenderer != null && pageRenderer.ViewController != null)
                viewController = pageRenderer.ViewController;
            else
                viewController = pageToDisplay.CreateViewController();

            var parentPage = Element.GetParentPage();
            var parentPageRenderer = Platform.GetRenderer(parentPage);

            Control.ParentViewController = parentPageRenderer.ViewController;
            Control.ViewController = viewController;

            viewController.ViewDidLayoutSubviews();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Content" || e.PropertyName == "Renderer")
            {
                if (Element != null && Element?.Content != null) // don't attempt to change the page if the PCV.Content property doesn't have a page to display
                {
                    // We must call this when Element.Content is a NavigationPage otherwise Platform.GetRenderer(parentPage) will return null in ChangePage()
                    try
                    {
                        Device.BeginInvokeOnMainThread(() => DisplayPCVContent(Element.Content));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
