using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp7.Extensions
{
    public class FocusBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty FocusTriggerProperty = DependencyProperty.Register(
            nameof(FocusTrigger), typeof(bool), typeof(FocusBehavior), new PropertyMetadata(default(bool), OnFocusTriggerChanged));

        private static async void OnFocusTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool b && b)
            {
                await ((FocusBehavior)d).FocusElement();
            }
        }

        public bool FocusTrigger
        {
            get => (bool)GetValue(FocusTriggerProperty);
            set => SetValue(FocusTriggerProperty, value);
        }

        public static readonly DependencyProperty FocusDelayProperty = DependencyProperty.Register(
            nameof(FocusDelay), typeof(int), typeof(FocusBehavior), new PropertyMetadata(300));

        public int FocusDelay
        {
            get => (int)GetValue(FocusDelayProperty);
            set => SetValue(FocusDelayProperty, value);
        }

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

        private async void AssociatedObjectOnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            await FocusElement();
        }

        private async Task FocusElement()
        {
            if (FocusDelay > 0)
            {
                await Task.Delay(FocusDelay);
            }
            await Dispatcher.InvokeAsync(() => { AssociatedObject?.Focus(); }, DispatcherPriority.Background);
        }
    }
}