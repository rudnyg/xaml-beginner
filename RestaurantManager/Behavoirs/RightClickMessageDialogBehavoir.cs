using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;

namespace RestaurantManager.Behavoirs
{
    public class RightClickMessageDialogBehavoir : DependencyObject, IBehavior
    {
        public string Message { get; set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page)
            {
                AssociatedObject = associatedObject;
                ((Page) AssociatedObject).RightTapped += Page_RightTapped;
            }
        }

        public void Detach()
        {
            if (AssociatedObject is Page)
            {
                AssociatedObject = null;
                var associatedObject = (Page) AssociatedObject;
                if (associatedObject != null) associatedObject.RightTapped -= Page_RightTapped;
            }
        }

        private void Page_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            new MessageDialog(Message).ShowAsync();
        }

        public DependencyObject AssociatedObject { get; private set; }
    }
}
