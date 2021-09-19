using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ChustaSoft.Common.Controls
{
    public partial class Loading : UserControl
    {

        public Loading()
        {
            InitializeComponent();
        }


        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(Loading), new PropertyMetadata(null));


        public Brush BackgroundColor
        {
            get => (Brush)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register(nameof(BackgroundColor), typeof(Brush), typeof(Loading), new PropertyMetadata(null));


        public string TextColor
        {
            get => (string)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register(nameof(TextColor), typeof(string), typeof(Loading), new PropertyMetadata(null));


        public float PanelOpacity
        {
            get => (float)GetValue(PanelOpacityProperty);
            set => SetValue(PanelOpacityProperty, value);
        }

        public static readonly DependencyProperty PanelOpacityProperty =
            DependencyProperty.Register(nameof(PanelOpacity), typeof(float), typeof(Loading), new PropertyMetadata(null));


        public LoadingPosition LoadingPosition
        {
            get => (LoadingPosition)GetValue(LoadingPositionProperty);
            set => SetValue(LoadingPositionProperty, value);
        }

        public static readonly DependencyProperty LoadingPositionProperty =
            DependencyProperty.Register(nameof(LoadingPosition), typeof(LoadingPosition), typeof(Loading), new PropertyMetadata(null));

        public LoadingType LoadingType
        {
            get => (LoadingType)GetValue(LoadingTypeProperty);
            set => SetValue(LoadingTypeProperty, value);
        }

        public static readonly DependencyProperty LoadingTypeProperty =
            DependencyProperty.Register(nameof(LoadingType), typeof(LoadingType), typeof(Loading), new PropertyMetadata(null));


        public bool Visible
        {
            get => (bool)GetValue(VisibleProperty);
            set => SetValue(VisibleProperty, value);
        }

        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register(nameof(Visible), typeof(bool), typeof(Loading), new PropertyMetadata(null));
    }
}
