using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMHookupDemo
{
    public static class ViewModelLocator
    {
        public static readonly DependencyProperty AutoWireViewModelProperty = 
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoWireViewModelChanged));
        
        public static bool GetAutoWireViewModel (DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        /// <summary>
        /// Note that this ViewModelLocator implementation only works if you follow the convention of having viewmodels named as ViewName + Model.
        /// </summary>
        private static void AutoWireViewModelChanged(DependencyObject view, DependencyPropertyChangedEventArgs args)
        {
            if (DesignerProperties.GetIsInDesignMode(view))
                return;

            var viewType = view.GetType();
            var viewTypeName = viewType.FullName;
            var viewModelTypeName = viewTypeName + "Model";
            var viewModelType = Type.GetType(viewModelTypeName);
            var viewModel = Activator.CreateInstance(viewModelType);
            ((FrameworkElement)view).DataContext = viewModel;
        }
    }
}
