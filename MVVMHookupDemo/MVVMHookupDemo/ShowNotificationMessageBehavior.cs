using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace MVVMHookupDemo
{
    public class ShowNotificationMessageBehavior : Behavior<ContentControl>
    {
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShowNotificationMessageBehavior), new PropertyMetadata(null, OnMessageChanged));

        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += (ignoredObject, mouseButtonEventArgs) =>
                AssociatedObject.Visibility = Visibility.Collapsed;
        }

        private static void OnMessageChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {
            var behavior = ((ShowNotificationMessageBehavior)dependencyObj);
            behavior.AssociatedObject.Content = args.NewValue;
            behavior.AssociatedObject.Visibility = Visibility.Visible;
        }
    }
}
