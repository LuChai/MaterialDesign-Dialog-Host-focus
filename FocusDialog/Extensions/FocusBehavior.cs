using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Controls;


namespace FocusDialog.Extensions
{
    public class FocusBehavior : Behavior<Button>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.IsVisibleChanged += AssociatedObjectOnIsVisibleChanged;

        }

        protected override void OnDetaching()
        {
            AssociatedObject.IsVisibleChanged -= AssociatedObjectOnIsVisibleChanged;
            base.OnDetaching();
        }

        private void AssociatedObjectOnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            AssociatedObject.Focus();
        }
    }
}
