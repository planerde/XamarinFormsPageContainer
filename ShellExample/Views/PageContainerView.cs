using Xamarin.Forms;

namespace ShellExample.Views
{
    public class PageContainerView : View
    {
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content),
            typeof(Page),
            typeof(PageContainerView));

        public Page Content
        {
            get { return (Page)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
