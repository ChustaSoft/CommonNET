using ChustaSoft.Common.Models;
using System.Windows;

namespace ChustaSoft.Common.Controls
{
    public partial class Selection : SelectionBase
    {

        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(ItemSelected), typeof(SelectableOption), typeof(Selection));


        public SelectableOption ItemSelected
        {
            get { return (SelectableOption)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }


        public Selection()
        {
            InitializeComponent();
        }

    }

    public class SelectionBase : SelectionControlBase<Selection> { }
}
