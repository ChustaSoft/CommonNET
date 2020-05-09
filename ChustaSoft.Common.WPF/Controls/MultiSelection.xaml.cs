using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ChustaSoft.Common.Controls
{
    public partial class MultiSelection : UserControl
    {

        public static DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(nameof(DefaultText), typeof(string), typeof(MultiSelection));

        public static DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(Items), typeof(IEnumerable<SelectableOption>), typeof(MultiSelection));


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


        public MultiSelection()
        {
            InitializeComponent();
        }

    }
}
