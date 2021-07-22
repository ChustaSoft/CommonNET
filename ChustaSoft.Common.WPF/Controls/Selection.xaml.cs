using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ChustaSoft.Common.Controls
{
    public partial class Selection : UserControl
    {

        public static DependencyProperty DefaultTextProperty =
            DependencyProperty.Register(nameof(DefaultText), typeof(string), typeof(Selection));

        public static DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(Items), typeof(IEnumerable<SelectableOption>), typeof(Selection));

        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(ItemSelected), typeof(SelectableOption), typeof(Selection));


        public string DefaultText
        {
            get => (string)GetValue(DefaultTextProperty);
            set => SetValue(DefaultTextProperty, value);
        }

        public IEnumerable<SelectableOption> Items
        {
            get => (IEnumerable<SelectableOption>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public SelectableOption ItemSelected
        {
            get => (SelectableOption)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }


        public Selection()
        {
            InitializeComponent();
        }

    }
}
