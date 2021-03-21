using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gadget {
    public enum ToneMode {
        Shadow, Light, Dark
    }

    /// <summary>
    /// Lógica de interacción para ColorTone.xaml
    /// </summary>
    public partial class ColorTone : GroupColor {
        public ColorTone() {
            InitializeComponent();
        }

        public static readonly DependencyProperty BaseColorProperty = DependencyProperty.Register(
            "BaseColor", typeof(Color), typeof(ColorTone), new PropertyMetadata(OnPropertyChange));

        public static readonly DependencyProperty ToneModeProperty = DependencyProperty.Register(
            "ToneMode", typeof(ToneMode), typeof(ColorTone), new PropertyMetadata(OnPropertyChange));

        private static void OnPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            (d as ColorTone).OnPropertyChanged(d, e);
        }

        protected override void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            base.OnPropertyChanged(d, e);
            if (e.Property == GroupColor.GroupNameProperty) {
                foreach (RadioButton rb in _base_.Children) rb.GroupName = (string)e.NewValue;
            } else if (e.Property == ColorTone.BaseColorProperty || e.Property == ColorTone.ToneModeProperty) {
                Color color = BaseColor;
                float r = BaseColor.ScR;
                float g = BaseColor.ScG;
                float b = BaseColor.ScB;
                float _r = (1f - BaseColor.ScR);
                float _g = (1f - BaseColor.ScG);
                float _b = (1f - BaseColor.ScB);
                var rb = _base_.Children[0] as RadioButton;
                switch (ToneMode) {
                    case Gadget.ToneMode.Shadow:
                        _r = -BaseColor.ScR / 7.2f;
                        _g = -BaseColor.ScG / 7.2f;
                        _b = -BaseColor.ScB / 7.2f;
                        break;
                    case Gadget.ToneMode.Light:
                        _r = (1f - BaseColor.ScR) / 12f;
                        _g = (1f - BaseColor.ScG) / 12f;
                        _b = (1f - BaseColor.ScB) / 12f;
                        break;
                    case Gadget.ToneMode.Dark:
                        _r = (Colors.DarkGray.ScR - BaseColor.ScR) / 9f;
                        _g = (Colors.DarkGray.ScG - BaseColor.ScG) / 9f;
                        _b = (Colors.DarkGray.ScB - BaseColor.ScB) / 9f;
                        break;
                }
                rb.Background = new SolidColorBrush(Color.FromScRgb(1f, r, g, b));
                for (int i = 0; i < _base_.Children.Count; i++) {
                    rb = _base_.Children[i] as RadioButton;
                    r += _r;
                    g += _g;
                    b += _b;
                    rb.Background = new SolidColorBrush(Color.FromScRgb(1f, r, g, b));
                }
                //if (e.Property == ColorTone.BaseColorProperty)
                //    (_base_.Children[0] as RadioButton).IsChecked = true;

                //if (ColorChanged != null) ColorChanged(this, new EventArgs());
            }
        }

        public Color BaseColor {
            get { return (Color)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }

        public ToneMode ToneMode {
            get { return (ToneMode)GetValue(ToneModeProperty); }
            set { SetValue(ToneModeProperty, value); }
        }

        private void color_Select(object sender, RoutedEventArgs e) {
            SetValue(GroupColor.SelectedColorProperty, ((sender as RadioButton).Background as SolidColorBrush).Color);
        }

        private void GroupColor_ColorChanged(object sender, EventArgs e) {
            foreach (RadioButton r in _base_.Children) {
                if ((r.Background as SolidColorBrush).Color == this.SelectedColor) {
                    r.IsChecked = true;
                    break;
                }
            }
        }
    }
}
