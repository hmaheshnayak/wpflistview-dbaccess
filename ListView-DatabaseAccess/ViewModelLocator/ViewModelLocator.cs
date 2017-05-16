using System;
using System.ComponentModel;
using System.Windows;

namespace ListView_DatabaseAccess.ViewModelLocator
{
    public static class ViewModelLocator
    {
        public static bool GetAutoHookedUpViewModel(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(AutoHookedUpViewModelProperty);
        }

        public static void SetAutoHookedUpViewModel(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(AutoHookedUpViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoHookedUpViewModelProperty =
            DependencyProperty.RegisterAttached("AutoHookedUpViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoHookedUpViewModelPropertyChanged));

        private static void AutoHookedUpViewModelPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(dependencyObject) == true)
                return;

            var viewType = dependencyObject.GetType();
            var viewTypeFullName = viewType.FullName;
            var viewModelTypeFullName = viewTypeFullName.Replace(".Views.", ".ViewModels.") + "Model";

            var viewModelType = Type.GetType(viewModelTypeFullName);
            var viewModelInstance = Activator.CreateInstance(viewModelType);

            ((FrameworkElement)dependencyObject).DataContext = viewModelInstance;
        }
    }
}
