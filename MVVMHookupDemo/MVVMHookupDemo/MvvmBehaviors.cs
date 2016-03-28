using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMHookupDemo
{
    public static class MvvmBehaviors
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadedMethodNameProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(MvvmBehaviors), new PropertyMetadata(null, OnLoadedMethodNameChanged));

        private static void OnLoadedMethodNameChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            FrameworkElement frameworkElement = dependencyObj as FrameworkElement;
            if (frameworkElement == null)
                return;

            frameworkElement.Loaded += (ignoredObject, ignoredRoutedEventArgs) =>
            {
                var viewModel = frameworkElement.DataContext;
                if (viewModel == null) return;

                var methodInfo = viewModel.GetType().GetMethod(dependencyPropertyChangedEventArgs.NewValue.ToString());
                if (methodInfo != null)
                    methodInfo.Invoke(viewModel, null);
            };
        }
    }
}
