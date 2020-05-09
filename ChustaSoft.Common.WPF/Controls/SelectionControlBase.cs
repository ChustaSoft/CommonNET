using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ChustaSoft.Common.Controls
{
    public class SelectionControlBase<TControl> : UserControl
    {

        public static DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(nameof(DefaultText), typeof(string), typeof(Selection));

        public static DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(Items), typeof(IEnumerable<SelectableOption>), typeof(Selection));


        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }

        public IEnumerable<SelectableOption> Items
        {
            get { return (IEnumerable<SelectableOption>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

    }
}
